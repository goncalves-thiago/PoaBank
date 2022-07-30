using Microsoft.Extensions.Configuration;
using System.Data;

namespace PoaBank.Interfaces
{
    public interface IBankContext
    {
        IDbConnection Connection();
    }
}
