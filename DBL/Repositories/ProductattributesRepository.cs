using Dapper;
using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public class ProductattributesRepository:BaseRepository,IProductattributesRepository
    {
        public ProductattributesRepository(string connectionString) : base(connectionString)
        {
        }
        #region Product Categories
        public IEnumerable<Attributes> GetProductattributeslist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Attributes>(GetAllStatement(Attributes.TableName)).ToList();
            }
        }
        #endregion
    }
}
