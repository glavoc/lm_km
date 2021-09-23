using System.Reflection;
using System.Windows.Media.Imaging;

namespace lm_km.res
{

    /// <summary>
    /// Gets the embedded resource image from the cbb.res assembly based on user provided file name with extension.
    /// Helper methods.
    /// </summary>
    public static class ResourceImage
    {
        #region public methods

        /// <summary>
        /// Gets the icon image from reource assembly.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static BitmapImage GetIcon(string name)
        {
            // Create the resource reader stream.
            string nmspsce = typeof(ResourceImage).Namespace + ".Images.Icons." + name;
            var ass = Assembly.GetExecutingAssembly();
            var stream = ass.GetManifestResourceStream(nmspsce);

            var image = new BitmapImage();

            // Construct and return image.
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            // Return constructed BitmapImage.
            return image;
        }

        #endregion
    }
}
