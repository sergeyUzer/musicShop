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

    public class VoteRepositoryMoq
    {
        private readonly Mock<IVoteRepository> _mock;
        private readonly List<Vote> _votes = new List<Vote>();

        public VoteRepositoryMoq()
        {
            _mock = new Mock<IVoteRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_votes);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Vote, BaseEntity>>[]>()))
                 .Returns(_votes);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Vote, bool>>>()))
                 .Returns(_votes);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Vote, bool>>>(),
                                     It.IsAny<Expression<Func<Vote, BaseEntity>>[]>()))
                 .Returns(_votes);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<Vote, bool>>>()))
                 .Returns(() => _votes.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Vote, bool>>>(),
                                             It.IsAny<Expression<Func<Vote, BaseEntity>>[]>()))
                 .Returns(() => _votes.FirstOrDefault());

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<Vote, bool>>>()))
                 .Returns(() => _votes.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<Vote, bool>>>()))
                 .Returns(() => _votes.Count);

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _votes.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<Vote, BaseEntity>>[]>()))
                 .Returns(() => _votes.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<Vote>())).Callback(() => _votes.Add(new Vote
            {
                Id = _votes.Count + 1,
                Mark = (_votes.Count % 5) + 1
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<Vote>())).Callback(() =>
            {
                if (_votes.Any())
                {
                    _votes.RemoveAt(_votes.Count - 1);
                }
            });
        }

        public IVoteRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}