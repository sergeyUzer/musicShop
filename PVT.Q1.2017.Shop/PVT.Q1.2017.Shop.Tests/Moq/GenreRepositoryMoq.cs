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

    public class GenreRepositoryMoq
    {
        private readonly Mock<IGenreRepository> _mock;
        private readonly List<Genre> _genres = new List<Genre>();

        public GenreRepositoryMoq()
        {
            _mock = new Mock<IGenreRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_genres);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Genre, BaseEntity>>[]>()))
                 .Returns(_genres);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Genre, bool>>>()))
                 .Returns(_genres);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Genre, bool>>>(),
                                     It.IsAny<Expression<Func<Genre, BaseEntity>>[]>()))
                 .Returns(_genres);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<Genre, bool>>>()))
                 .Returns(() => _genres.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Genre, bool>>>(),
                                             It.IsAny<Expression<Func<Genre, BaseEntity>>[]>()))
                 .Returns(() => _genres.FirstOrDefault());

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _genres.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<Genre, BaseEntity>>[]>()))
                 .Returns(() => _genres.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<Genre, bool>>>()))
                 .Returns(() => _genres.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<Genre, bool>>>()))
                 .Returns(() => _genres.Count);

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<Genre>())).Callback(() => _genres.Add(new Genre
            {
                Id = _genres.Count + 1,
                Name = $"Genre{_genres.Count + 1}"
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<Genre>())).Callback(() =>
            {
                if (_genres.Any())
                {
                    _genres.RemoveAt(_genres.Count - 1);
                }
            });
        }

        public IGenreRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}