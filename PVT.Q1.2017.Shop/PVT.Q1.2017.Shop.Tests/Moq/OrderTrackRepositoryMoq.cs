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

    class OrderTrackRepositoryMoq
    {
        private readonly List<OrderTrack> _orderTrack = new List<OrderTrack>();
        private readonly Mock<IOrderTrackRepository> _mock;

        public OrderTrackRepositoryMoq()
        {
            _mock = new Mock<IOrderTrackRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_orderTrack);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<OrderTrack, BaseEntity>>[]>()))
                .Returns(_orderTrack);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<OrderTrack, bool>>>()))
                .Returns((Expression<Func<OrderTrack, bool>> exp) => _orderTrack.Where(exp.Compile()).ToList());

            _mock.Setup(
                    m =>
                        m.GetAll(It.IsAny<Expression<Func<OrderTrack, bool>>>(),
                            It.IsAny<Expression<Func<OrderTrack, BaseEntity>>[]>()))
                .Returns(_orderTrack);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<OrderTrack, bool>>>()))
                .Returns((Expression<Func<OrderTrack, bool>> exp) => _orderTrack.FirstOrDefault(exp.Compile()));

            _mock.Setup(
                    m =>
                        m.FirstOrDefault(It.IsAny<Expression<Func<OrderTrack, bool>>>(),
                            It.IsAny<Expression<Func<OrderTrack, BaseEntity>>[]>()))
                .Returns((Expression<Func<OrderTrack, bool>> exp, Expression<Func<OrderTrack, BaseEntity>>[] exp2) => 
                _orderTrack.FirstOrDefault(exp.Compile()));

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int id) => _orderTrack.FirstOrDefault(a => a.Id == id));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                    It.IsAny<Expression<Func<OrderTrack, BaseEntity>>[]>()))
                .Returns(() => _orderTrack.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<OrderTrack, bool>>>()))
                .Returns((Expression<Func<OrderTrack, bool>> exp) => _orderTrack.Any(exp.Compile()));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<OrderTrack>()))
                .Callback((OrderTrack orderTrack) =>
                {
                    orderTrack.Id = _orderTrack.Count + 1;
                    _orderTrack.Add(orderTrack);
                });

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<OrderTrack, bool>>>()))
                 .Returns(() => _orderTrack.Count);

        _mock.Setup(m => m.Delete(It.IsNotNull<OrderTrack>())).Callback((OrderTrack orderTrack) =>
            {
                if (_orderTrack.Any(o => o.Id == orderTrack.Id))
                {
                    _orderTrack.Remove(orderTrack);
                }
            });
        }

        public IOrderTrackRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}
