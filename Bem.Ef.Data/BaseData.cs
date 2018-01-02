using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Data
{
    public class BaseData
    {
       public SqlConnection CreateConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=Zimmet;Integrated Security=True");
        }

    }
}
