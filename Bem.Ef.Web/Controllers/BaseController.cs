using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bem.Ef.Web.Controllers
{
    public class BaseController : Controller
    {
        internal string _connStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            }
        }

        internal static Person ConvertRdrToPerson(SqlDataReader rdr)
        {
            return new Person
            {
                Id = Convert.ToInt32(rdr["Id"]),
                FirstName = rdr["Name"].ToString(),
                IdentityNumber = rdr["IdentityNumber"].ToString(),
                LastName = rdr["LastName"].ToString(),
                BirthDate = Convert.ToDateTime(rdr["BirthDate"])
            };
        }

        internal SqlConnection CreateAndOpenConnection()
        {
            var conn = new SqlConnection(_connStr);
            conn.Open();

            return conn;
        }

        internal List<Person> GetAllPersonList()
        {
            var list = new List<Person>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand("SELECT * FROM Person", sqlConn);
                var rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(ConvertRdrToPerson(rdr));
                }
            }

            return list;
        }

        internal List<Item> GetAllItemsList()
        {
            var list = new List<Item>();

            using (var sqlConn = CreateAndOpenConnection())
            {
                var sqlCommand = new SqlCommand("SELECT * FROM Items", sqlConn);
                var rdr = sqlCommand.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(new Item
                    {
                        ItemId = Convert.ToInt32(rdr["Id"]),
                        Name = rdr["name"].ToString()
                    });
                }
            }

            return list;
        }
    }
}