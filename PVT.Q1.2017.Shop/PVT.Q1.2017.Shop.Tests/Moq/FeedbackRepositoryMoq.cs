namespace PVT.Q1._2017.Shop.Tests.Moq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using global::Moq;
    using global::Shop.Common.Models;
    using global::Shop.DAL.Infrastruture;
    using global::Shop.Infrastructure.Models;

    public class FeedbackRepositoryMoq
    {
        private readonly Mock<IFeedbackRepository> _mock;
        private readonly List<Feedback> _feedbacks = new List<Feedback>();

        public FeedbackRepositoryMoq()
        {
            _mock = new Mock<IFeedbackRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_feedbacks);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()))
                 .Returns(_feedbacks);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Feedback, bool>>>()))
                 .Returns(_feedbacks);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Feedback, bool>>>(),
                                     It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()))
                 .Returns(_feedbacks);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<Feedback, bool>>>()))
                 .Returns(() => _feedbacks.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Feedback, bool>>>(),
                                             It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()))
                 .Returns(() => _feedbacks.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _feedbacks.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<Feedback, BaseEntity>>[]>()))
                 .Returns(() => _feedbacks.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<Feedback, bool>>>()))
                 .Returns(() => _feedbacks.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<Feedback, bool>>>()))
                 .Returns(() => _feedbacks.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<Feedback>())).Callback(() => _feedbacks.Add(new Feedback
            {
                Id = _feedbacks.Count + 1,
                Comments = $"Comment{_feedbacks.Count + 1}"
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<Feedback>())).Callback(() =>
            {
                if (_feedbacks.Any())
                {
                    _feedbacks.RemoveAt(_feedbacks.Count - 1);
                }
            });
        }

        public IFeedbackRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}