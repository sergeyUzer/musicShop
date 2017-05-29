namespace Shop.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Common.Models;
    using Shop.DAL.Context;
    using Infrastructure.Repositories;
    using Infrastruture;

    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">
        /// The db context.
        /// </param>
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
