namespace PVT.Q1._2017.Shop.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Shop.BLL.Services;
    using global::Shop.BLL.Services.Infrastructure;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using global::Moq;

    [TestClass]
    public class FeedbackServiceTest
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IRepositoryFactory _factory;

        public FeedbackServiceTest()
        {
            _factory = new RepositoryFactoryMoq();
            _feedbackService = new FeedbackService(_factory);
        }

        [TestMethod]
        public void AddFeedbackTest()
        {
            var track = new Track { ArtistId = 1, Name = "track" };
            using (var repository = _factory.GetTrackRepository())
            {
                repository.AddOrUpdate(track);
            }

            var userData = new UserData { User = new User { Login = "user" } };
            using (var repository = _factory.GetUserDataRepository())
            {
                repository.AddOrUpdate(userData);
            }

            using (var repository = _factory.GetFeedbackRepository())
            {
                repository.AddOrUpdate(new Feedback
                {
                    Comments = "Some comments",
                    User = userData,
                    Track = track
                });
                repository.SaveChanges();

                Assert.IsTrue(repository.GetAll().Any());
            }
        }

        [TestMethod]
        public void GetFeedbackTest()
        {
            AddFeedbackTest();
            Assert.IsNotNull(_feedbackService.GetTrackFeedback(1, 1));

            Mock.Get(_factory.GetFeedbackRepository())
                .Verify(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Feedback, bool>>>(),
                                             It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()), Times.Once);
        }

        [TestMethod]
        public void FeedbackExistsTest()
        {
            AddFeedbackTest();
            Assert.IsTrue(_feedbackService.FeedbackExists(1, 1));

            Mock.Get(_factory.GetFeedbackRepository()).Verify(m => m.Exist(It.IsAny<Expression<Func<Feedback, bool>>>()), Times.Once);
        }

        [TestMethod]
        public void GetTrackFeedbacksTest()
        {
            AddFeedbackTest();

            var feedbacks = _feedbackService.GetTrackFeedbacks(1);
            Assert.IsNotNull(feedbacks);
            Assert.IsNotNull(feedbacks.Feedbacks);
            Assert.IsTrue(feedbacks.Feedbacks.Any());

            Mock.Get(_factory.GetTrackRepository())
                .Verify(
                        m =>
                            m.GetById(It.IsAny<int>(), It.IsAny<Expression<Func<Track, BaseEntity>>[]>()), Times.Once);

            Mock.Get(_factory.GetFeedbackRepository())
                .Verify(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Feedback, bool>>>(),
                                     It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()), Times.Once);
        }
    }
}
