using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UsersRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            user.UserID = Guid.NewGuid();

            // SQL query to insert user data into the "Users" table.
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\")" +
                " VALUES (@UserID, @Email, @PersonName, @Gender, @Password)";

            int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser> GetUserByEmailandPassword(string? Email, string? Password)
        {
            //Sql query to select a user by Email and password 
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

            var param = new { Email = Email, Password = Password };

            ApplicationUser? user = await _dbContext.DbConnection
                .QueryFirstOrDefaultAsync<ApplicationUser>(query, param);

            return user;
        }
    }
}
