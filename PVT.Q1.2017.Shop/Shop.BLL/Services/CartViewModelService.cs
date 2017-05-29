namespace Shop.BLL.Services
{
    using Common.ViewModels;

    /// <summary>
    /// Cart View Model service
    /// </summary>
    public static class CartViewModelService
    {
        /// <summary>
        /// Set TotalPrice for cart
        /// </summary>
        /// <param name="userCurrency">
        /// Валюта, которую выбрал пользователь.
        /// </param>
        /// <returns> Успешно ли прошла операция подсчёта</returns>
        public static bool SetTotalPrice(CartViewModel userCart, CurrencyViewModel userCurrency)
        {
            if (userCart == null || userCurrency == null)
            {
                return false;
            }

            userCart = CheckCount(userCart);

            foreach (TrackDetailsViewModel anyTrack in userCart.Tracks)
            {
                if (anyTrack.Price == null)
                {
                    return false;
                }

                userCart.TotalPrice += anyTrack.Price.Amount;
            }

            foreach (AlbumDetailsViewModel anyAlbum in userCart.Albums)
            {
                if (anyAlbum.Price == null)
                {
                    return false;
                }

                userCart.TotalPrice += anyAlbum.Price.Amount;
            }

            return true;
        }

        /// <summary>
        /// Проверка на null содержимого корзины.
        /// </summary>
        /// <param name="userCart"></param>
        /// <returns>Корзина текущего пользователя</returns>
        private static CartViewModel CheckCount(CartViewModel userCart)
        {
            if (userCart.Tracks.Count > 0 || userCart.Albums.Count > 0)
            {
                userCart.IsEmpty = false;
            }
            return userCart;
        }
    }
}
