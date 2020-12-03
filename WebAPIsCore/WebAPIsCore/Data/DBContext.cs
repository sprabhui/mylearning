using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAPIsCore.Models;

namespace WebAPIsCore.Data
{
    public class DBContext
    {
        private IConfiguration _config;
       
        public DBContext(IConfiguration config)
        {
            _config = config;
        }

        public List<User> getAllUsers()
        {
            List<User> userList = new List<User>();
            string CS = _config["db:connectionstring"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT RTRIM(LTRIM(FirstName)) as FirstName,RTRIM(LTRIM(Password)) as Password FROM [User]", con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var user = new User();
                    //user.id = Convert.ToInt32(rdr["id"]);
                    user.firstName = rdr["FirstName"].ToString();
                   // user.lastName = rdr["LastName"].ToString();
                   // user.emailAddress = rdr["EmailAddress"].ToString();
                    user.password = rdr["Password"].ToString();
                    userList.Add(user);
                }
                con.Close();
            }
            return userList;

        }
    }
}
