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

    public class ArtistRepositoryMoq
    {
        private readonly List<Artist> _artists = new List<Artist>();
        private readonly Mock<IArtistRepository> _mock;

        public ArtistRepositoryMoq()
        {
            _mock = new Mock<IArtistRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_artists);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Artist, BaseEntity>>[]>()))
                 .Returns(_artists);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<Artist, bool>>>()))
                 .Returns(_artists);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<Artist, bool>>>(),
                                     It.IsAny<Expression<Func<Artist, BaseEntity>>[]>()))
                 .Returns(_artists);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<Artist, bool>>>()))
                 .Returns(() => _artists.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<Artist, bool>>>(),
                                             It.IsAny<Expression<Func<Artist, BaseEntity>>[]>()))
                 .Returns(() => _artists.FirstOrDefault());

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<Artist, bool>>>()))
                 .Returns(() => _artists.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<Artist, bool>>>()))
                 .Returns(() => _artists.Count);

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _artists.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<Artist, BaseEntity>>[]>()))
                 .Returns(() => _artists.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<Artist>())).Callback(() => _artists.Add(new Artist
            {
                Id = _artists.Count + 1,
                Name = $"Artist{_artists.Count + 1}"
            }));

            _mock.Setup(m => m.Delete(It.IsNotNull<Artist>())).Callback(() =>
            {
                if (_artists.Any())
                {
                    _artists.RemoveAt(_artists.Count - 1);
                }
            });
        }

        public IArtistRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}