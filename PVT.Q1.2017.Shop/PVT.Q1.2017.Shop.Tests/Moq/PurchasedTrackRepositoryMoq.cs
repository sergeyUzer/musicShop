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

    class PurchasedTrackRepositoryMoq
    {
        private readonly List<PurchasedTrack> _purchasedTrack = new List<PurchasedTrack>();
        private readonly Mock<IPurchasedTrackRepository> _mock;

        public PurchasedTrackRepositoryMoq()
        {
            _mock = new Mock<IPurchasedTrackRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_purchasedTrack);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PurchasedTrack, BaseEntity>>[]>()))
                 .Returns(_purchasedTrack);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PurchasedTrack, bool>>>()))
                 .Returns(_purchasedTrack);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<PurchasedTrack, bool>>>(),
                                     It.IsAny<Expression<Func<PurchasedTrack, BaseEntity>>[]>()))
                 .Returns(_purchasedTrack);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<PurchasedTrack, bool>>>()))
                 .Returns((Func<PurchasedTrack, bool> exp) => _purchasedTrack.FirstOrDefault(exp));

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<PurchasedTrack, bool>>>(),
                                             It.IsAny<Expression<Func<PurchasedTrack, BaseEntity>>[]>()))
                 .Returns(() => _purchasedTrack.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns((int id) => _purchasedTrack.FirstOrDefault(a => a.Id == id));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<PurchasedTrack, BaseEntity>>[]>()))
                 .Returns(() => _purchasedTrack.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<PurchasedTrack, bool>>>()))
                 .Returns((Expression<Func<PurchasedTrack, bool>> exp) => _purchasedTrack.Any(exp.Compile()));

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<PurchasedTrack, bool>>>()))
                 .Returns(() => _purchasedTrack.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<PurchasedTrack>())).Callback((PurchasedTrack pTrack) =>
            {
                pTrack.Id = _purchasedTrack.Count + 1;
                _purchasedTrack.Add(pTrack);
            });

            _mock.Setup(m => m.Delete(It.IsNotNull<PurchasedTrack>())).Callback((PurchasedTrack pTrack) =>
            {
                if (_purchasedTrack.Any(p => p.Id == pTrack.Id))
                {
                    _purchasedTrack.RemoveAt(pTrack.Id - 1);
                }
            });
        }

        public IPurchasedTrackRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}
