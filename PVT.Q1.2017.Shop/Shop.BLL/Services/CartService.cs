using System;
using System.Text;
using System.Web.Management;
using Castle.Core.Internal;
using Ninject.Infrastructure.Language;

namespace Shop.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Models;
    using DAL.Infrastruture;
    using Infrastructure;
    using Exceptions;
    using Common.ViewModels;
    using System.Collections;
    using System.Data.SqlClient;


    /// <summary>
    /// The Cart Service
    /// </summary>
    public class CartService : BaseService, ICartService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartService"/> class.
        /// </summary>
        /// <param name="factory">The  repositories factory</param>
        public CartService(IRepositoryFactory factory) : base(factory)
        {
        }

        /// <summary> 
        /// Add track to User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackId">Added Track ID</param> 
        public void AddTrack(int userId, int trackId)
        {
            this.CheckInputId(userId, trackId, "Track");
            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                var orderTrack = new OrderTrack() { UserId = userId, TrackId = trackId };
                try
                {
                    orderTrackRepository.AddOrUpdate(orderTrack);
                    orderTrackRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary> 
        /// Add track list to User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackIds">Added Tracks IDs</param> 
        public void AddTrack(int userId, IEnumerable<int> trackIds)
        {
            this.CheckInputIds(userId, trackIds, "Track");
            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                try
                {
                    foreach (var trackId in trackIds)
                    {
                        var orderTrack = new OrderTrack() { UserId = userId, TrackId = trackId };
                        orderTrackRepository.AddOrUpdate(orderTrack);
                    }
                    orderTrackRepository.SaveChanges();
                }
                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary> 
        /// Remove track from User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackId">Removed Track ID</param> 
        public void RemoveTrack(int userId, int trackId)
        {
            this.CheckInputId(userId, trackId, "Track");
            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                var orderTrack = orderTrackRepository.FirstOrDefault(o =>
                    o.UserId == userId
                    && o.TrackId == trackId);
                if (orderTrack == null)
                {
                    return;
                }

                try
                {
                    orderTrackRepository.Delete(orderTrack);
                    orderTrackRepository.SaveChanges();
                }
                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary> 
        /// Remove track list from User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackIds">Removed Tracks IDs</param> 
        public void RemoveTrack(int userId, IEnumerable<int> trackIds)
        {
            this.CheckInputIds(userId, trackIds, "Track");
            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                var orderTracks = new List<OrderTrack>();
                orderTracks.AddRange(orderTrackRepository.GetAll(o => o.UserId == userId && trackIds.Contains(o.TrackId)));
                try
                {
                    foreach (var orderTrack in orderTracks)
                    {
                        orderTrackRepository.Delete(orderTrack);
                    }

                    orderTrackRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Add album to User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumId">Added Album ID</param>
        public void AddAlbum(int userId, int albumId)
        {
            this.CheckInputId(userId, albumId, "Album");
            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                var orderAlbum = new OrderAlbum() { UserId = userId, AlbumId = albumId };
                try
                {
                    orderAlbumRepository.AddOrUpdate(orderAlbum);
                    orderAlbumRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Add albums to User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumIds">Added Albums IDs</param>
        public void AddAlbum(int userId, IEnumerable<int> albumIds)
        {
            this.CheckInputIds(userId, albumIds, "Album");
            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                try
                {
                    foreach (var albumId in albumIds)
                    {
                        var orderAlbum = new OrderAlbum() { UserId = userId, AlbumId = albumId };
                        orderAlbumRepository.AddOrUpdate(orderAlbum);
                    }
                    orderAlbumRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Remove album from User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumId">Removed Album ID</param>
        public void RemoveAlbum(int userId, int albumId)
        {
            this.CheckInputId(userId, albumId, "Album");
            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                var orderAlbum = orderAlbumRepository.FirstOrDefault(o =>
                    o.UserId == userId
                    && o.AlbumId == albumId);
                if (orderAlbum == null)
                {
                    return;
                }

                try
                {
                    orderAlbumRepository.Delete(orderAlbum);
                    orderAlbumRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Remove album list from User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumIds">Removed Albums IDs</param>
        public void RemoveAlbum(int userId, IEnumerable<int> albumIds)
        {
            this.CheckInputIds(userId, albumIds, "Album");
            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                var orderAlbums = new List<OrderAlbum>();
                orderAlbums.AddRange(orderAlbumRepository.GetAll(o => o.UserId == userId && albumIds.Contains(o.AlbumId)));
                try
                {
                    foreach (var orderAlbum in orderAlbums)
                    {
                        orderAlbumRepository.Delete(orderAlbum);
                    }

                    orderAlbumRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Get chosen to purchase Track's IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns Array of IDs</returns>
        public IEnumerable<int> GetOrderTracksIds(int userId)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            var returnResult = new List<int>();
            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                returnResult.AddRange(orderTrackRepository.GetAll(o => o.UserId == userId).Select(o => o.TrackId));
            }

            return returnResult;
        }

        /// <summary>
        /// Get collection of chosen to purchase Tracks
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns List of Tracks</returns>
        public ICollection<TrackDetailsViewModel> GetOrderTracks(int userId, int? currencyCode = null)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            var result = new List<TrackDetailsViewModel>();
            using (var trackRepository = Factory.GetTrackRepository())
            {
                var trackService = new TrackService(Factory);
                using (var orderTrackRepository = Factory.GetOrderTrackRepository())
                {
                    var tracksIds = orderTrackRepository.GetAll(o => o.UserId == userId).Select(o => o.TrackId);
                    result =
                        trackRepository.GetAll(t => tracksIds.Contains(t.Id))
                            .Select(t => trackService.GetTrackDetails(t.Id, currencyCode)).ToList();
                }
            }
            
            return result;
        }

        /// <summary>
        /// Get chosen to purchase Album's IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns Array of IDs</returns>
        public IEnumerable<int> GetOrderAlbumsIds(int userId)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            var returnResult = new List<int>();
            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                returnResult.AddRange(orderAlbumRepository.GetAll(o => o.UserId == userId).Select(o => o.AlbumId));
            }

            return returnResult;
        }

        /// <summary>
        /// Get collection of chosen to purchase Albums
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns List of Albums</returns>
        public ICollection<AlbumDetailsViewModel> GetOrderAlbums(int userId, int? currencyCode = null)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            var result = new List<AlbumDetailsViewModel>();
            using (var albumRepository = Factory.GetAlbumRepository())
            {
                var albumService = new AlbumService(Factory);
                using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
                {
                    var albumsIds = orderAlbumRepository.GetAll(o => o.UserId == userId).Select(o => o.AlbumId);
                    result =
                        albumRepository.GetAll(a => albumsIds.Contains(a.Id))
                            .Select(a => albumService.GetAlbumDetails(a.Id, currencyCode)).ToList();
                }
            }

            return result;
        }

        /// <summary>
        /// Remove All items from User's Cart
        /// </summary>
        /// <param name="userId">User ID</param>
        public void RemoveAll(int userId)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            using (var orderTrackRepository = Factory.GetOrderTrackRepository())
            {
                var orderTracks = new List<OrderTrack>();
                orderTracks.AddRange(orderTrackRepository.GetAll(o => o.UserId == userId));
                try
                {
                    foreach (var orderTrack in orderTracks)
                    {
                        orderTrackRepository.Delete(orderTrack);
                    }

                    orderTrackRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }

            using (var orderAlbumRepository = Factory.GetOrderAlbumRepository())
            {
                var orderAlbums = new List<OrderAlbum>();
                orderAlbums.AddRange(orderAlbumRepository.GetAll(o => o.UserId == userId));
                try
                {
                    foreach (var orderAlbum in orderAlbums)
                    {
                        orderAlbumRepository.Delete(orderAlbum);
                    }

                    orderAlbumRepository.SaveChanges();
                }

                catch (SqlException ex)
                {
                    throw new CartServiceException(this.CheckSqlExceptions(ex));
                }
            }
        }

        /// <summary>
        /// Accept Payment of All User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        public void AcceptPayment(int userId)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }

            this.RemoveAll(userId);
        }

        /// <summary>
        /// Cheking input IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="itemId">Item's ID</param>
        /// <param name="itemType">Type of Item ("Track" or "Album")</param>
        private void CheckInputId(int userId, int itemId, string itemType)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }
            if (itemId <= 0)
            {
                throw new CartServiceException($"Некорректный {itemType} ID={itemId} при работе с корзиной пользователя ID={userId}");
            }
        }

        /// <summary>
        /// Cheking input IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="itemIds">Collection of Item's ID</param>
        /// <param name="itemType">Type of Item ("Track" or "Album")</param>
        private void CheckInputIds(int userId, IEnumerable<int> itemIds, string itemType)
        {
            if (userId <= 0)
            {
                throw new CartServiceException($"Неккоректный User ID={userId}");
            }
            foreach (var itemId in itemIds)
            {
                if (itemId <= 0)
                {
                    throw new CartServiceException($"Некорректный {itemType} ID={itemId} при работе с корзиной пользователя ID={userId}");
                }
            }
        }

        /// <summary>
        /// Combine all SQL Exceptions in one String
        /// </summary>
        /// <param name="ex">SQL Exception</param>
        /// <returns>String with all SQL Exception's messages</returns>
        private string CheckSqlExceptions(SqlException ex)
        {
            var eMessages = new StringBuilder();
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                eMessages.Append($"SQL Ошибка #{i + 1}: {Environment.NewLine}" +
                                 $"Сообщение: {ex.Errors[i].Message} {Environment.NewLine}" +
                                 $"Источник: {ex.Errors[i].Source} {Environment.NewLine}");
            }

            if (ex.InnerException != null)
            {
                eMessages.Append($"Другая ошибка: {Environment.NewLine}" +
                                 $"Сообщение: {ex.InnerException.Message} {Environment.NewLine}" +
                                 $"Источник: {ex.InnerException.Source} {Environment.NewLine}");
            }

            return eMessages.ToString();
        }
    }
}
