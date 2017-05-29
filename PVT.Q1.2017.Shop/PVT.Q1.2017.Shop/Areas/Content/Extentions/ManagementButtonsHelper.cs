namespace PVT.Q1._2017.Shop.Areas.Content.Extentions
{
    using System.Web.Mvc;

    /// <summary>
    /// The management buttons helper.
    /// </summary>
    public static class ManagementButtonsHelper
    {
        private const string DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS = "btn btn-sm btn-primary";
        private const string DEFAULT_DELETE_BUTTON_CSS_CLASS = "btn btn-sm btn-danger";
        private const string DEFAULT_CREATE_BUTTON_ICON_CSS_CLASS = "glyphicon glyphicon-plus";
        private const string DEFAULT_EDIT_BUTTON_ICON_CSS_CLASS = "glyphicon glyphicon-pencil";
        private const string DEFAULT_DELETE_BUTTON_ICON_CSS_CLASS = "glyphicon glyphicon-trash";

        /// <summary>
        /// Renders a button for new artist creation purpose.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for new artists creation.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnCreateArtist(
            this HtmlHelper helper,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_CREATE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("New", "Artists", new { area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Добавить нового исполнителя";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for editing artists.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="artistId">
        /// The artist to edit.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for editing artists.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnEditArtist(
            this HtmlHelper helper,
            int artistId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_EDIT_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Edit", "Artists", new { id = artistId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Редактировать исполнителя";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for deleting artists.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="artistId">
        /// The artist to delete.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for deleting artists.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnDeleteArtist(
            this HtmlHelper helper,
            int artistId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_DELETE_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_DELETE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Delete", "Artists", new { id = artistId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Удалить исполнителя";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for new album creation purpose.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="artistId">
        /// The artist for whitch a new album will be created.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for new albums creation.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnCreateAlbum(
            this HtmlHelper helper,
            int? artistId = null,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_CREATE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("New", "Albums", new { artistId = artistId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Добавить новый альбом";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for editing albums.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="albumId">
        /// The album to edit.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for editing albums.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnEditAlbum(
            this HtmlHelper helper,
            int albumId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_EDIT_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Edit", "Albums", new { id = albumId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Редактировать альбом";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for deleting albums.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="albumId">
        /// The album to delete.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for deleting albums.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnDeleteAlbum(
            this HtmlHelper helper,
            int albumId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_DELETE_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_DELETE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Delete", "Albums", new { id = albumId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Удалить альбом";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for new track creation purpose.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="artistId">
        /// The artist for whitch a new track will be created.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for new tracks creation.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnCreateTrack(
            this HtmlHelper helper,
            int? artistId = null,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_CREATE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("New", "Tracks", new { artistId = artistId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Добавить новый трек";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }
        
        /// <summary>
        /// Renders a button for editing tracks.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="trackId">
        /// The track to edit.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for editing tracks.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnEditTrack(
            this HtmlHelper helper,
            int trackId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_EDIT_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Edit", "Tracks", new { id = trackId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Редактировать трек";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for deleting tracks.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="trackId">
        /// The track to delete.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for deleting tracks.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnDeleteTrack(
            this HtmlHelper helper,
            int trackId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_DELETE_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_DELETE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("Delete", "Tracks", new { id = trackId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Удалить трек";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }

        /// <summary>
        /// Renders a button for adding tracks to the album.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="albumId">
        /// The album id.
        /// </param>
        /// <param name="text">
        /// The button text.
        /// </param>
        /// <param name="class">
        /// The button CSS class.
        /// </param>
        /// <param name="iconClass">
        /// The button icon CSS class.
        /// </param>
        /// <param name="href">
        /// The url to a page for adding tracks to the album.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnAddTracksToAlbum(
            this HtmlHelper helper,
            int albumId,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = DEFAULT_MANAGEMENT_BUTTON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_CREATE_BUTTON_ICON_CSS_CLASS;
            }

            if (string.IsNullOrWhiteSpace(href))
            {
                var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                href = urlHelper.Action("AddTracksToAlbum", "Albums", new { id = albumId, area = "Management" });
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Добавить треки в альбом";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href);
        }
    }
}