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
    public class ProductcategoryRepository:BaseRepository,IProductcategoryRepository
    {
        public ProductcategoryRepository(string connectionString) : base(connectionString)
        {
        }
        #region
        public GenericModel Addproductcategory(Productcategory entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@Categoryname", entity.Categoryname);
                //parameters.Add("@Createdby", entity.Createdby);
                //parameters.Add("@Modifiedby", entity.Modifiedby);
                return connection.Query<GenericModel>("Usp_AddPostcategory", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
