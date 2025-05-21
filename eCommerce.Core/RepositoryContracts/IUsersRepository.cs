using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.RepositoryContracts
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Method to add user data to data store and return the added user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<ApplicationUser> AddUser(ApplicationUser user);

        /// <summary>
        /// Method to retrieve existing user by their email and password
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        Task<ApplicationUser> GetUserByEmailandPassword(string? Email, string? Password);
    }
}
