using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace DataAccess
{
    public static class RegionDAO
    {
        private static DbHelper db = new DbHelper();

        #region Region dataAccess
        public static DataTable GetAllShipping()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [RegionId]
                                                      ,[RegionName]
                                                      ,[RegionPrice]
                                                      ,[DevMethods]
                                                  FROM [Shipping]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int UpdateShipping(Shipping ship)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Shipping]
                                           SET [RegionName] = @RegionName
                                              ,[RegionPrice] =@RegionPrice
                                              ,[DevMethods] = @DevMethods
                                         WHERE RegionId=@RegionId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@RegionName", ship.RegionName), 
            new SqlParameter("@RegionPrice", ship.RegionPrice),
            new SqlParameter("@DevMethods", ship.DevMethods),
            new SqlParameter("@RegionId", ship.RegionId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int RemoveShippingById(int shipId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from Shipping where RegionId = @RegionId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@RegionId", shipId) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int AddNewShippping(Shipping ship)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [Shipping]
                                                       ([RegionName]
                                                       ,[RegionPrice]
                                                       ,[DevMethods])
                                                 VALUES
                                                       (@RegionName
                                                       ,@RegionPrice
                                                       ,@DevMethods)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@RegionName", ship.RegionName), 
            new SqlParameter("@RegionPrice", ship.RegionPrice),
            new SqlParameter("@DevMethods", ship.DevMethods)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }
        #endregion Region dataAccess

    }
}
