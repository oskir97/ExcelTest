using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest.EFC.DataContexts.DbConnection
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnectionForRead();
        IDbConnection CreateConnectionForWrite();
    }
}
