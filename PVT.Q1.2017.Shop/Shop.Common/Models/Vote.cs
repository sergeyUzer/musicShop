// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Vote.cs" company="PVT.Q1.2017">
//   PVT.Q1.2017
namespace Shop.Common.Models
{
    using FluentValidation.Attributes;
    using Infrastructure.Models;
    using Validators;

    /// <summary>
    ///     The user vote.
    /// </summary>
    [Validator(typeof(VoteValidator))]
    public class Vote : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the mark.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        ///     Gets or sets the track id.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        ///     Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        ///     Gets or sets the track.
        /// </summary>
        public virtual Track Track { get; set; }

        /// <summary>
        ///     Gets or sets the user.
        /// </summary>
        public virtual UserData User { get; set; }
    }
}