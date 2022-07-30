using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PoaBank.Entity;
using PoaBank.Interfaces;
using System.Data;

namespace PoaBank.Context
{
    public class BankContext : IBankContext
    {
        private readonly IConfiguration _configuration;
        public BankContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("BankConnectionNote"));
        }
    }
}
