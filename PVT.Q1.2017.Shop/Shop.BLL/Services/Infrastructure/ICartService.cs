using Shop.Common.Models;

namespace Shop.BLL.Services.Infrastructure
{
    using Common.ViewModels;
    using System.Collections.Generic;

    /// <summary>
    /// The Cart Service
    /// </summary>
    public interface ICartService
    {
        /// <summary> 
        /// Add track to User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackId">Added Track ID</param> 
        void AddTrack(int userId, int trackId);

        /// <summary> 
        /// Add track list to User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackIds">Added Tracks IDs</param>
        void AddTrack(int userId, IEnumerable<int> trackIds);

        /// <summary> 
        /// Remove track from User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackId">Removed Track ID</param>
        void RemoveTrack(int userId, int trackId);

        /// <summary> 
        /// Remove track list from User's Cart 
        /// </summary> 
        /// <param name="userId">User's ID</param> 
        /// <param name="trackIds">Removed Tracks IDs</param> 
        void RemoveTrack(int userId, IEnumerable<int> trackIds);

        /// <summary>
        /// Add album to User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumId">Added Album ID</param>
        void AddAlbum(int userId, int albumId);

        /// <summary>
        /// Add albums to User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumIds">Added Albums IDs</param>
        void AddAlbum(int userId, IEnumerable<int> albumIds);

        /// <summary>
        /// Remove album from User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumId">Removed Album ID</param>
        void RemoveAlbum(int userId, int albumId);

        /// <summary>
        /// Remove album list from User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <param name="albumIds">Removed Albums IDs</param>
        void RemoveAlbum(int userId, IEnumerable<int> albumIds);

        /// <summary>
        /// Get chosen to purchase Track's IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns Array of IDs</returns>
        IEnumerable<int> GetOrderTracksIds(int userId);

        /// <summary>
        /// Get collection of chosen to purchase Tracks
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns List of Tracks</returns>
        ICollection<TrackDetailsViewModel> GetOrderTracks(int userId, int? currencyCode = null);

        /// <summary>
        /// Get chosen to purchase Album's IDs
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns Array of IDs</returns>
        IEnumerable<int> GetOrderAlbumsIds(int userId);

        /// <summary>
        /// Get collection of chosen to purchase Albums
        /// </summary>
        /// <param name="userId">User's ID</param>
        /// <returns>Returns List of Albums</returns>
        ICollection<AlbumDetailsViewModel> GetOrderAlbums(int userId, int? currencyCode = null);

        /// <summary>
        /// Remove all tracks and albums from cart
        /// </summary>
        /// <param name="userId"></param>
        void RemoveAll(int userId);

        /// <summary>
        /// Accept Payment of All User's Cart
        /// </summary>
        /// <param name="userId">User's ID</param>
        void AcceptPayment(int userId);
    }
}
