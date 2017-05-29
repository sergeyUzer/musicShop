namespace Shop.Common.ViewModels
{
    using System;

    /// <summary>
    /// The artist details view model.
    /// </summary>
    public class ArtistDetailsViewModel
    {
        /// <summary>
        /// Artist id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Artist name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Artist biography.
        /// </summary>
        public string Biography { get; set; }

        /// <summary>
        /// Artist birthday.
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Artist photo.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// The number of the artist tracks.
        /// </summary>
        public int TracksCount { get; set; }

        /// <summary>
        /// The number of the artist albums.
        /// </summary>
        public int AlbumsCount { get; set; }
    }
}