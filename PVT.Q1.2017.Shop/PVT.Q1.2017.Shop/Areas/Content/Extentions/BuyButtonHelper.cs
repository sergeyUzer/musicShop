namespace PVT.Q1._2017.Shop.Areas.Content.Extentions
{
    using System.Web.Mvc;

    public static class BuyButtonHelper
    {
        private const string DEFAULT_BUY_BUTTON_CSS_CLASS = "btn btn-sm btn-success";

        private const string DEFAULT_BUY_BUTTON_ICON_CSS_CLASS = "glyphicon glyphicon-shopping-cart";

        /// <summary>
        /// Renders a button for buying an album.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="albumId">
        /// The album id.
        /// </param>
        /// <param name="isOrdered">
        /// Determines whether an item is ordered.
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
        /// The url to a page for creating a price for the album.
        /// </param>
        /// <param name="onclick">
        /// Client onclick function.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnBuyAlbum(
            this HtmlHelper helper,
            int albumId,
            bool isOrdered,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null,
            string onclick = null)
        {
            if (string.IsNullOrWhiteSpace(onclick))
            {
                string alternateText = string.Empty;
                if (string.IsNullOrWhiteSpace(text))
                {
                    text = isOrdered ? "Из корзины" : "В корзину";
                    alternateText = isOrdered ? "В корзину" : "Из корзины";
                }

                onclick = isOrdered
                              ? $"removeAlbumFromCart(this, {albumId}, '{text}', '{alternateText}')"
                              : $"addAlbumToCart(this, {albumId}, '{text}', '{alternateText}')";
            }

            return GenerateBtnBuyItem(helper, isOrdered, text, @class, iconClass, href, onclick);
        }
        
        /// <summary>
        /// Renders a button for buying a track.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="trackId">
        /// The track id.
        /// </param>
        /// <param name="isOrdered">
        /// Determines whether an item is ordered.
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
        /// The url to a page for creating a price for the album.
        /// </param>
        /// <param name="onclick">
        /// Client onclick function.
        /// </param>
        /// <returns>
        /// The button html.
        /// </returns>
        public static MvcHtmlString BtnBuyTrack(
            this HtmlHelper helper,
            int trackId,
            bool isOrdered,
            string text = null,
            string @class = null,
            string iconClass = null,
            string href = null,
            string onclick = null)
        {
            if (string.IsNullOrWhiteSpace(onclick))
            {
                string alternateText = string.Empty;
                if (string.IsNullOrWhiteSpace(text))
                {
                    text = isOrdered ? "Из корзины" : "В корзину";
                    alternateText = isOrdered ? "В корзину" : "Из корзины";
                }

                onclick = isOrdered
                              ? $"removeTrackFromCart(this, {trackId}, '{text}', '{alternateText}')"
                              : $"addTrackToCart(this, {trackId}, '{text}', '{alternateText}')";
            }

            return GenerateBtnBuyItem(helper, isOrdered, text, @class, iconClass, href, onclick);
        }

        private static MvcHtmlString GenerateBtnBuyItem(
            this HtmlHelper helper,
            bool isOrdered,
            string text,
            string @class,
            string iconClass,
            string href,
            string onclick)
        {
            if (string.IsNullOrWhiteSpace(@class))
            {
                @class = isOrdered ? "ordered " + DEFAULT_BUY_BUTTON_CSS_CLASS : DEFAULT_BUY_BUTTON_CSS_CLASS;
            }
            else if (isOrdered)
            {
                @class += " ordered ";
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                iconClass = DEFAULT_BUY_BUTTON_ICON_CSS_CLASS;
            }
            
            if (string.IsNullOrWhiteSpace(text))
            {
                text = isOrdered ? "Из корзины" : "В корзину";
            }

            return helper.ButtonWithIcon(@class, iconClass, text, href, onclick);
        }
    }
}