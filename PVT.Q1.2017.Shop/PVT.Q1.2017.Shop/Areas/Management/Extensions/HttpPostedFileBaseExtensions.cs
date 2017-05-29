namespace PVT.Q1._2017.Shop.Areas.Management.Extensions
{
    using System.IO;
    using System.Web;

    /// <summary>
    /// The http posted file extensions
    /// </summary>
    public static class HttpPostedFileBaseExtensions
    {
        /// <summary>
        /// Converts the uploaded file to the array of bytes.
        /// </summary>
        /// <param name="postedFile">
        /// The posted file.
        /// </param>
        /// <returns>
        /// The array of bytes.
        /// </returns>
        public static byte[] ToBytes(this HttpPostedFileBase postedFile)
        {
            if (postedFile == null || postedFile.InputStream == null)
            {
                return null;
            }

            var inputStream = postedFile.InputStream as MemoryStream;
            if (inputStream != null)
            {
                return inputStream.ToArray();
            }

            using (inputStream = new MemoryStream())
            {
                postedFile.InputStream.CopyTo(inputStream);
                return inputStream.ToArray();
            }
        }
    }
}