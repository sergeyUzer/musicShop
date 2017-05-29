namespace Shop.BLL.Helpers
{
    using System;
    using System.IO;
    using System.Web;

    /// <summary>
    /// </summary>
    public static class Mp3StreamHelper
    {
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public static MemoryStream GetAudioStream(
            string trackName,
            string trackArtistName,
            byte[] audio,
            bool sample = false)
        {
            if (audio == null)
            {
                return null;
            }

            var size = sample ? (long)(audio.Length - audio.Length * 0.8) : audio.Length;
            long startbyte = 0;
            var endbyte = size - 1;
            var statusCode = 200;

            var desSize = endbyte - startbyte + 1;

            if (HttpContext.Current != null)
            {
                var request = HttpContext.Current.Request;
                if (request.Headers["Range"] != null)
                {
                    var range = request.Headers["Range"].Split('=', '-');

                    long requestStartIndex;
                    if (range.Length > 1 && long.TryParse(range[1], out requestStartIndex))
                    {
                        startbyte = Math.Min(endbyte, requestStartIndex); // начальный индекс не должен выходить за пределы массива байтов
                    }

                    long requestEndIndex;
                    if (range.Length > 2 && !string.IsNullOrWhiteSpace(range[2]) && long.TryParse(range[1], out requestEndIndex))
                    {
                        endbyte = Math.Min(endbyte, requestEndIndex); // конечный индекс не должен выходить за пределы массива байтов
                    }

                    if (endbyte < startbyte)
                    {
                        endbyte = startbyte; // конечный индекс не может быть меньше начального
                    }

                    if (startbyte != 0 || endbyte != size - 1 || range.Length > 2 && range[2] == string.Empty)
                    {
                        statusCode = 206;
                    }
                }

                desSize = endbyte - startbyte + 1;

                var response = HttpContext.Current.Response;
                response.ContentType = "audio/mp3";
                FillResponse(response, statusCode, trackArtistName, trackName, desSize, startbyte, endbyte, size);
            }

            return startbyte >= 0 && desSize > 0 ? new MemoryStream(audio, (int)startbyte, (int)desSize) : null;
        }
        
        /// <summary>
        /// </summary>
        /// <param name="response">
        ///     The response.
        /// </param>
        /// <param name="statusCode">
        ///     The status code.
        /// </param>
        /// <param name="trackArtistName">
        ///     The track artist name.
        /// </param>
        /// <param name="trackName">
        ///     The track name.
        /// </param>
        /// <param name="desSize">
        ///     The des size.
        /// </param>
        /// <param name="startbyte">
        ///     The startbyte.
        /// </param>
        /// <param name="endbyte">
        ///     The endbyte.
        /// </param>
        /// <param name="fSize">
        ///     The f size.
        /// </param>
        private static void FillResponse(
            HttpResponse response,
            int statusCode,
            string trackArtistName,
            string trackName,
            long desSize,
            long startbyte,
            long endbyte,
            long fSize)
        {
            response.StatusCode = statusCode;
            response.AddHeader("TrackArtist", trackArtistName);
            response.AddHeader("TrackTitle", trackName);
            response.AddHeader("Content-Accept", response.ContentType);
            response.AddHeader("Content-Length", desSize.ToString());
            response.AddHeader("Content-Range", $"bytes {startbyte}-{endbyte}/{fSize}");
        }
    }
}