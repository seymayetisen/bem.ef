using Bem.Ef.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Data
{
    public class PersonData : BaseData
    {

        public List<Person> GetAllPerson()
        {
            var personList = GetPersonList("SELECT * FROM Person");

            return personList;
        }

        public List<Person> GetAllPersonHaveItem()
        {
            var personList = GetPersonList(@"SELECT * FROM Person AS p
INNER JOIN PersonItem AS pe ON p.Id = pe.PersonId
WHERE pe.GivenDate is null");

            return personList;
        }

        public List<Person> GetAllPersonHaveNotItem()
        {
            var personList = GetPersonList(@"SELECT * FROM Person AS p
INNER JOIN PersonItem AS pe ON p.Id = pe.PersonId
WHERE pe.GivenDate is NOT null");

            return personList;
        }

        public List<Person> GetPersonFilterByName(string name)
        {
            var personList = GetPersonList(@"SELECT * FROM Person AS p
INNER JOIN PersonItem AS pe ON p.Id = pe.PersonId
WHERE pe.GivenDate is NOT null");

            return personList;
        }

        private List<Person> GetPersonList(string commandText)
        {
            var list = new List<Person>();

            using (var conn = CreateConnection())
            {
                var sqlCommand = new SqlCommand(commandText, conn);
                conn.Open();

                using (var rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(ConvertRdrToPerson(rdr));
                    }
                }
            }

            return list;
        }

        private Person ConvertRdrToPerson(SqlDataReader rdr)
        {
            return new Person
            {
                Id = Convert.ToInt32(rdr["Id"]),
                FirstName = rdr["FirstName"].ToString(),
                IdentityNumber = rdr["IdentityNumber"].ToString(),
                LastName = rdr["LastName"].ToString()
            };
        }
    }
}
