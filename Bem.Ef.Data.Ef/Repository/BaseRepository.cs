using Bem.Ef.Data.Ef.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bem.Ef.Data.Ef.Repository
{
    public class BaseRepository
    {
        protected ZimmetContext CreateContext()
        {
            return new ZimmetContext();
        }
    }
}
