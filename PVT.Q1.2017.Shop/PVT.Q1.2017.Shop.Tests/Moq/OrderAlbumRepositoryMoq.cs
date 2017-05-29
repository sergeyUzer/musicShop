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

    class OrderAlbumRepositoryMoq
    {
        private readonly List<OrderAlbum> _orderAlbum = new List<OrderAlbum>();
        private readonly Mock<IOrderAlbumRepository> _mock;

        public OrderAlbumRepositoryMoq()
        {
            _mock = new Mock<IOrderAlbumRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_orderAlbum);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<OrderAlbum, BaseEntity>>[]>()))
                .Returns(_orderAlbum);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<OrderAlbum, bool>>>()))
                .Returns((Expression<Func<OrderAlbum, bool>> exp) => _orderAlbum.Where(exp.Compile()).ToList());

            _mock.Setup(
                    m =>
                        m.GetAll(It.IsAny<Expression<Func<OrderAlbum, bool>>>(),
                            It.IsAny<Expression<Func<OrderAlbum, BaseEntity>>[]>()))
                .Returns(_orderAlbum);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<OrderAlbum, bool>>>()))
                .Returns((Expression<Func<OrderAlbum, bool>> exp) => _orderAlbum.FirstOrDefault(exp.Compile()));

            _mock.Setup(
                    m =>
                        m.FirstOrDefault(It.IsAny<Expression<Func<OrderAlbum, bool>>>(),
                            It.IsAny<Expression<Func<OrderAlbum, BaseEntity>>[]>()))
                .Returns((Expression<Func<OrderAlbum, bool>> exp, Expression<Func<OrderAlbum, BaseEntity>>[] exp2) => 
                _orderAlbum.FirstOrDefault(exp.Compile()));

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int id) => _orderAlbum.FirstOrDefault(a => a.Id == id));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                    It.IsAny<Expression<Func<OrderAlbum, BaseEntity>>[]>()))
                .Returns(() => _orderAlbum.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<OrderAlbum, bool>>>()))
                .Returns((Expression<Func<OrderAlbum, bool>> exp) => _orderAlbum.Any(exp.Compile()));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<OrderAlbum>()))
                .Callback((OrderAlbum orderAlbum) =>
                {
                    orderAlbum.Id = _orderAlbum.Count + 1;
                    _orderAlbum.Add(orderAlbum);
                });

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<OrderAlbum, bool>>>()))
                 .Returns(() => _orderAlbum.Count);

            _mock.Setup(m => m.Delete(It.IsNotNull<OrderAlbum>())).Callback((OrderAlbum orderAlbum) =>
            {
                if (_orderAlbum.Any(o => o.Id == orderAlbum.Id))
                {
                    _orderAlbum.Remove(orderAlbum);
                }
            });
        }

        public IOrderAlbumRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}
