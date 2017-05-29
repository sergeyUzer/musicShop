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

    public class AlbumTrackRelationRepositoryMoq
    {
        private readonly Mock<IAlbumTrackRelationRepository> _mock;
        private readonly List<AlbumTrackRelation> _albumTrackRelations = new List<AlbumTrackRelation>();

        public AlbumTrackRelationRepositoryMoq()
        {
            _mock = new Mock<IAlbumTrackRelationRepository>();

            _mock.Setup(m => m.GetAll()).Returns(_albumTrackRelations);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<AlbumTrackRelation, BaseEntity>>[]>()))
                 .Returns(_albumTrackRelations);

            _mock.Setup(m => m.GetAll(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>()))
                 .Returns(_albumTrackRelations);

            _mock.Setup(
                        m =>
                            m.GetAll(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>(),
                                     It.IsAny<Expression<Func<AlbumTrackRelation, BaseEntity>>[]>()))
                 .Returns(_albumTrackRelations);

            _mock.Setup(m => m.FirstOrDefault(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>()))
                 .Returns(() => _albumTrackRelations.FirstOrDefault());

            _mock.Setup(
                        m =>
                            m.FirstOrDefault(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>(),
                                             It.IsAny<Expression<Func<AlbumTrackRelation, BaseEntity>>[]>()))
                 .Returns(() => _albumTrackRelations.FirstOrDefault());

            _mock.Setup(m => m.Exist(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>()))
                 .Returns(() => _albumTrackRelations.Any());

            _mock.Setup(m => m.Count(It.IsAny<Expression<Func<AlbumTrackRelation, bool>>>()))
                 .Returns(() => _albumTrackRelations.Count);

            _mock.Setup(m => m.GetById(It.IsAny<int>()))
                 .Returns(() => _albumTrackRelations.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.GetById(It.IsAny<int>(),
                                       It.IsAny<Expression<Func<AlbumTrackRelation, BaseEntity>>[]>()))
                 .Returns(() => _albumTrackRelations.FirstOrDefault(a => a.Id > 0));

            _mock.Setup(m => m.AddOrUpdate(It.IsNotNull<AlbumTrackRelation>()))
                 .Callback(() => _albumTrackRelations.Add(new AlbumTrackRelation
                 {
                     Id = _albumTrackRelations.Count + 1,
                     TrackId = _albumTrackRelations.Count + 1,
                     AlbumId = 2
                 }));

            _mock.Setup(m => m.Delete(It.IsNotNull<AlbumTrackRelation>())).Callback(() =>
            {
                if (_albumTrackRelations.Any())
                {
                    _albumTrackRelations.RemoveAt(_albumTrackRelations.Count - 1);
                }
            });
        }

        public IAlbumTrackRelationRepository Repository
        {
            get { return _mock.Object; }
        }
    }
}