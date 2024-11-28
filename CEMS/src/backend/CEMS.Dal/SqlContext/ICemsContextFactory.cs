using CEMS.Dal.Models;

namespace CEMS.Dal.SqlContext
{
    public interface ICemsContextFactory
    {
        CemsDBContext CreateContext();
    }
}
