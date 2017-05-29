namespace Shop.Infrastructure.Enums
{
    /// <summary>
    /// Determines possible user roles in this shop
    /// </summary>
    public enum UserRoles
    {
        /// <summary>
        /// Ordinary user
        /// </summary>
        Customer,

        /// <summary>
        /// User with huge wallet
        /// </summary>
        Seller,

        /// <summary>
        /// Admin
        /// </summary>
        Admin,   

        Buyer
    }
}
