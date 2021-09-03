using Dapper;
using DBL.Enitites;
using DBL.Enum;
using DBL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repositories
{
    public class ProductRepository:BaseRepository,IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }

        #region Product
        public IEnumerable<Productvariations> Getallproductvariations(long Staffcode)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                return connection.Query<Productvariations>(FindStatement(Productvariations.TableName, "Accountcode"), new { id = Staffcode }).ToList();
            }
        }
        public GenericModel Addproductsdata(Products entity)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Accountcode", entity.Accountcode);
                parameters.Add("@Productname", entity.Productname);
                parameters.Add("@@Productbrand", entity.Productbrand);
                parameters.Add("@Categorycode", entity.Categorycode);
                parameters.Add("@Subcategorycode", entity.Subcategorycode);
                parameters.Add("@Hasattributes", entity.Hasattributes);
                parameters.Add("@Productattributecode", entity.Productattributecode);
                parameters.Add("@Productattributevaluecode",entity.Productattributevaluecodedata);
                parameters.Add("@Productcolorcode", entity.Productcolorcodedata);
                parameters.Add("@Createdby", entity.Createdby);
                parameters.Add("@Modifiedby", entity.Modifiedby);
                parameters.Add("@Datecreated", entity.Datecreated);
                parameters.Add("@Datemodified", entity.Datemodified);
                return connection.Query<GenericModel>("Usp_Addproductsdata", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        #endregion


        #region Other Methods
        public IEnumerable<ListModel> GetListModel(ListModelType listType)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Type", (int)listType);

                return connection.Query<ListModel>("Usp_GetListModel", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<ListModel> GetListModelbycode(long Code,ListModelType listType)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Code", Code);
                parameters.Add("@Type", (int)listType);

                return connection.Query<ListModel>("Usp_GetListModelbycode", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        #endregion
    }
}
