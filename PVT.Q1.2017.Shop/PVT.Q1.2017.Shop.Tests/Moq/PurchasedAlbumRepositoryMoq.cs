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

    class PurchasedAlbumRepositoryMoq
    {
        private readonly List<PurchasedAlbum> _purchasedAlbum = new List<PurchasedAlbum>();
        private readonly Mock<IPurchasedAlbumRepository> _mock;

        public PurchasedAlbumRepositoryMoq()
        {
            _mock = new Mock<IPurchasedAlbumRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_purchasedAlbum);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PurchasedAlbum, BaseEntity>>[]>()))
                 .Returns(_purchasedAlbum);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>()))
                 .Returns(_purchasedAlbum);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>(),
                                     It.IsAny<Expression<Func<PurchasedAlbum, BaseEntity>>[]>()))
                 .Returns(_purchasedAlbum);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>()))
                 .Returns((Func<PurchasedAlbum, bool> exp) => _purchasedAlbum.FirstOrDefault(exp));

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>(),
                                             It.IsAny<Expression<Func<PurchasedAlbum, BaseEntity>>[]>()))
                 .Returns(() => _purchasedAlbum.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns((int id) => _purchasedAlbum.FirstOrDefault(a => a.Id == id));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<PurchasedAlbum, BaseEntity>>[]>()))
                 .Returns(() => _purchasedAlbum.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>()))
                 .Returns((Expression<Func<PurchasedAlbum, bool>> exp) => _purchasedAlbum.Any(exp.Compile()));

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<PurchasedAlbum, bool>>>()))
                 .Returns(() => _purchasedAlbum.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<PurchasedAlbum>())).Callback((PurchasedAlbum pAlbum) =>
            {
                pAlbum.Id = _purchasedAlbum.Count + 1;
                _purchasedAlbum.Add(pAlbum);
            });

            _mock.Setup(m => m.Delete(It.IsNotNull<PurchasedAlbum>())).Callback((PurchasedAlbum pAlbum) =>
            {
                if (_purchasedAlbum.Any(p => p.Id == pAlbum.Id))
                {
                    _purchasedAlbum.RemoveAt(pAlbum.Id - 1);
                }
            });
        }

        public IPurchasedAlbumRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}
