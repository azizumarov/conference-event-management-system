using CEMS.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CEMS.Dal.SqlContext
{
    public class CemsContextFactory(string connectionString) : ICemsContextFactory
    {
        public CemsDBContext CreateContext()
        {
            var opt = new DbContextOptionsBuilder<CemsDBContext>().UseSqlServer(connectionString).Options;
            return new CemsDBContext(opt);
        }
    }
}
