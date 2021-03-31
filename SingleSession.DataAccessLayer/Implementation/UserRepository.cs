using Dapper;
using SingleSession.DataAccessLayer.Interface;
using SingleSession.ModelLayer.Configurations;
using SingleSession.ModelLayer.DBModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleSession.DataAccessLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionstring;
        public UserRepository()
        {
            connectionstring = ConfigurationManager.ConnectionString;
        }

        public async Task<User> Login(User user)
        {
            string sql = "select * from Users where Email= @USEREMAIL and Password= @PASSWORD";
            using var db = new SqlConnection(connectionstring);
            var result = await db.QueryFirstOrDefaultAsync<User>(sql, new
            {
                USEREMAIL = user.Email,
                PASSWORD = user.Password
            });
            return result;
        }

        public async Task<bool> Register(User user)
        {
            string sql = "INSERT INTO Users (FirstName, LastName, Email, Password,LastUpdated) VALUES(@FirstName, @LastName,@Email,@Password,SYSDATETIME()); ";
            using var db = new SqlConnection(connectionstring);
            var result = await db.ExecuteAsync(sql, user);
            return result > 0;
        }
    }
}