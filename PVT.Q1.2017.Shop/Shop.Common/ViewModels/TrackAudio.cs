namespace Shop.Common.ViewModels
{
    using System.IO;

    /// <summary>
    /// </summary>
    public class TrackAudio
    {
        /// <summary>
        /// Gets or sets the audio stream.
        /// </summary>
        public MemoryStream AudioStream { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }
    }
}