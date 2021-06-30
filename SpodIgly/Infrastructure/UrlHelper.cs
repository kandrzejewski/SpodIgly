using System.IO;


namespace SpodIgly.Infrastructure
{
    public static class UrlHelper
    {
        public static string GenreIconPath(this System.Web.Mvc.UrlHelper helper, string genreIconFilename)
        {
            var genreIconFolder = AppConfig.GenreIconsFolderRelative;
            var path = Path.Combine(genreIconFolder, genreIconFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }

        public static string AlbumCoverPath(this System.Web.Mvc.UrlHelper helper, string albumFilename)
        {
            var albumCoverFolder = AppConfig.PhotosFolderRelative;
            var path = Path.Combine(albumCoverFolder, albumFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}