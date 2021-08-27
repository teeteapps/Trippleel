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
        #region Product Categories
        public IEnumerable<Productcategory> Getproductcategorylist()
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Productcategory>(GetAllStatement(Productcategory.TableName)).ToList();
            }
        }
        public GenericModel Addproductcategory(Productcategory entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Categoryname", entity.Categoryname);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                return connection.Query<GenericModel>("Usp_Addproductcategory", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        public Productcategory Getcategorydetails(long Categorycode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Productcategory>(FindStatement(Productcategory.TableName, "Categorycode"),new {id=Categorycode }).FirstOrDefault();
            }
        }
        public GenericModel Addproductsubcategory(Productsubcategory entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Categorycode", entity.Categorycode);
                parameters.Add("@Subcategoryname", entity.Subcategoryname);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                return connection.Query<GenericModel>("Usp_Addproductsubcategory", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion
    }
}
