﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Identity.Abstract
{
    /// <summary>
    /// Abstraction for interacting with AspNetUserTokens table.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key for a user.</typeparam>
    /// <typeparam name="TUserToken">The type representing a user token.</typeparam>
    public interface IUserTokensTable<TKey, TUserToken>
        where TKey : IEquatable<TKey>
        where TUserToken : IdentityUserToken<TKey>, new()
    {
        /// <summary>
        /// Gets a list of tokens to be belonging to the specified user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        Task<IEnumerable<TUserToken>> GetTokensAsync(TKey userId);
        /// <summary>
        /// Finds a token entry for the specified user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="loginProvider">The login provider.</param>
        /// <param name="name">The token name.</param>
        Task<TUserToken> FindTokenAsync(TKey userId, string loginProvider, string name);
    }
}
