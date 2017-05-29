namespace Shop.Common.Models
{
    using System;
    using System.Collections.Generic;
    using Shop.Infrastructure.Models;

    /// <summary>
    /// Payment transaction for saving payment info
    /// </summary>
    public class PaymentTransaction : BaseEntity 
    {

        /// <summary>
        /// Total amount for current transaction
        /// </summary>
        public decimal Totals { get; set; }

        /// <summary>
        /// Date and time of transaction creation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Currency ID
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Currency for transaction
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Transaction holder
        /// </summary>
        public virtual UserData User { get; set; }

        /// <summary>
        /// Purchased tracks
        /// </summary>
        public virtual ICollection<PurchasedTrack> PurchasedTrack { get; set; }

        /// <summary>
        /// Purchased albums
        /// </summary>
        public virtual ICollection<PurchasedAlbum> PurchasedAlbum { get; set; }
    }
}
