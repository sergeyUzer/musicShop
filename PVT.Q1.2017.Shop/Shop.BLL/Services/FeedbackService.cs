namespace Shop.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using Common.ViewModels;
    using DAL.Infrastruture;
    using Helpers;
    using Infrastructure;

    /// <summary>
    /// The feedback service
    /// </summary>
    public class FeedbackService : BaseService, IFeedbackService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackService"/> class.
        /// </summary>
        /// <param name="repositoryFactory">
        /// The repository factory.
        /// </param>
        public FeedbackService(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
        }

        /// <summary>
        /// Returns the feedback which have made the specified user for the track.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="userDataId">
        /// The user who have left a comment and/or a vote for the track.
        /// </param>
        /// <returns>
        /// The feedback for the <paramref name="trackId"/> which have made the specified <paramref name="userDataId"/>
        /// or <b>null</b> in case if feedback doesn't exist.
        /// </returns>
        public FeedbackViewModel GetTrackFeedback(int trackId, int userDataId)
        {
            Feedback feedback;
            using (var repository = Factory.GetFeedbackRepository())
            {
                feedback = repository.FirstOrDefault(f => f.TrackId == trackId && f.UserId == userDataId, f => f.User, f => f.User.User);
            }

            Vote vote;
            using (var repository = Factory.GetVoteRepository())
            {
                vote = repository.FirstOrDefault(v => v.TrackId == trackId && v.UserId == userDataId);
            }

            FeedbackViewModel feedbackViewModel = null;

            // if user comments exist for this feedback
            if (feedback != null)
            {
                feedbackViewModel = ModelsMapper.GetFeedbackViewModel(feedback);
            }

            // if a user mark exists for this feedback
            if (vote != null)
            {
                if (feedbackViewModel == null)
                {
                    // this is a feedback only with mark
                    feedbackViewModel = new FeedbackViewModel
                    {
                        Mark = vote.Mark,
                        UserDataId = vote.UserId
                    };
                }
                else
                {
                    // this is a feedback with comments and mark
                    feedbackViewModel.Mark = vote.Mark;
                }
            }

            return feedbackViewModel;
        }

        /// <summary>
        /// Determines whether the specified user have made a feedback for the track.
        /// </summary>
        /// <param name="trackId">
        ///     The track id.
        /// </param>
        /// <param name="userDataId">
        ///     The user data id.
        /// </param>
        /// <returns>
        /// <b>true</b> if the specified user have made a feedback for the track;
        /// otherwise <b>false</b>.
        /// </returns>
        public bool FeedbackExists(int trackId, int userDataId)
        {
            bool feedbackCommentsExist;
            using (var repository = Factory.GetFeedbackRepository())
            {
                feedbackCommentsExist = repository.Exist(f => f.TrackId == trackId && f.UserId == userDataId);
            }

            bool voteExists;
            using (var repository = Factory.GetVoteRepository())
            {
                voteExists = repository.Exist(v => v.TrackId == trackId && v.UserId == userDataId);
            }

            return feedbackCommentsExist || voteExists;
        }

        /// <summary>
        /// Returns all track feedbacks.
        /// </summary>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <returns>
        /// All track feedbacks.
        /// </returns>
        public TrackFeedbacksListViewModel GetTrackFeedbacks(int trackId)
        {
            TrackFeedbacksListViewModel trackFeedbacksListViewModel = CreateTrackFeedbacksListViewModel(trackId);
            trackFeedbacksListViewModel.Feedbacks = GetTrackFeedbacksList(trackId);
            return trackFeedbacksListViewModel;
        }

        /// <summary>
        /// Adds a new feedback or updates existent feedback for the specified track.
        /// </summary>
        /// <param name="feedbackViewModel">
        /// The user feedback.
        /// </param>
        public void AddOrUpdateFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (feedbackViewModel == null)
            {
                throw new ArgumentNullException(nameof(feedbackViewModel));
            }

            using (var repository = Factory.GetFeedbackRepository())
            {
                var feedback = repository.FirstOrDefault(f => f.TrackId == feedbackViewModel.TrackId && f.UserId == feedbackViewModel.UserDataId);

                if (feedback == null)
                {
                    if (!string.IsNullOrWhiteSpace(feedbackViewModel.Comments))
                    {
                        feedback = ModelsMapper.GetFeedback(feedbackViewModel);
                    }
                }
                else
                {
                    feedback.Comments = feedbackViewModel.Comments;
                }

                if (feedback != null)
                {
                    if (!string.IsNullOrWhiteSpace(feedback.Comments))
                    {
                        repository.AddOrUpdate(feedback);
                    }
                    else
                    {
                        repository.Delete(feedback);
                    }
                    repository.SaveChanges();
                }
            }

            if (feedbackViewModel.Mark > 0)
            {
                using (var repository = Factory.GetVoteRepository())
                {
                    var vote = repository.FirstOrDefault(v => v.TrackId == feedbackViewModel.TrackId && v.UserId == feedbackViewModel.UserDataId);

                    if (vote == null)
                    {
                        vote = ModelsMapper.GetVote(feedbackViewModel);
                    }
                    else
                    {
                        vote.Mark = feedbackViewModel.Mark;
                    }

                    repository.AddOrUpdate(vote);
                    repository.SaveChanges();
                }
            }
        }

        private TrackFeedbacksListViewModel CreateTrackFeedbacksListViewModel(int trackId)
        {
            Track track;
            using (var repository = Factory.GetTrackRepository())
            {
                track = repository.GetById(trackId, t => t.Artist, t => t.Genre);
            }

            var trackViewModel = ModelsMapper.GetTrackFeedbacksListViewModel(track);

            trackViewModel.TrackDetails.Rating = ServiceHelper.CalculateTrackRating(Factory, trackId);

            return trackViewModel;
        }

        private ICollection<FeedbackViewModel> GetTrackFeedbacksList(int trackId)
        {
            ICollection<Feedback> feedbacks;
            using (var repository = Factory.GetFeedbackRepository())
            {
                feedbacks = repository.GetAll(f => f.TrackId == trackId, f => f.User, f => f.User.User);
            }

            ICollection<Vote> votes;
            using (var repository = Factory.GetVoteRepository())
            {
                votes = repository.GetAll(v => v.TrackId == trackId, f => f.User, f => f.User.User);
            }

            ICollection<FeedbackViewModel> feedbackViewModels = feedbacks.Select(ModelsMapper.GetFeedbackViewModel).ToList();

            // find marks for feedbacks with comments
            foreach (var feedbackViewModel in feedbackViewModels)
            {
                var userVote = votes.FirstOrDefault(v => v.UserId == feedbackViewModel.UserDataId);
                if (userVote != null)
                {
                    feedbackViewModel.Mark = userVote.Mark;
                    votes.Remove(userVote);
                }
            }

            // add feedbacks without comments
            foreach (var vote in votes)
            {
                var feedbackViewModel = new FeedbackViewModel
                {
                    Mark = vote.Mark,
                    UserDataId = vote.UserId,
                    UserName = vote.User.User.Login
                };
            
                feedbackViewModels.Add(feedbackViewModel);
            }

            return feedbackViewModels;
        }
    }
}