using Dapper;
using DBL.Enitites;
using System;
using System.Collections.Generic;
using System.Data;
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
        public GenericModel Addproductattributes(Attributes entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Attributename", entity.Attributename);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                return connection.Query<GenericModel>("Usp_Addproductattributes", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public IEnumerable<Attributevalues> Getattributedetails(long Attributecode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Attributevalues>(FindStatement(Attributevalues.TableName, "Attributecode"), new { id = Attributecode }).ToList();
            }
        }
        #endregion
    }
}
