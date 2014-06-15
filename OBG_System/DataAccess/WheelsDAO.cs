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
    public static class WheelsDAO
    {

        private static DbHelper db = new DbHelper();

        public static DataTable GetAllProducts(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [ProductId]
                                                      ,[Image]
                                                      ,[Style]
                                                      ,[Brand]
                                                      ,[Size]
                                                      ,[PCD]
                                                      ,[Finish]
                                                      ,[Offset]
                                                      ,[SEAT]
                                                      ,[BORE]
                                                      ,[Weight]
                                                      ,[ONHand]
                                                      ,[Price]
                                                      ,[PartNO]
                                                      ,[des],d.wheelsrate,w.price*d.wheelsrate finalprice
                                                  FROM [OBG_].[dbo].[Wheels] w ,[discount] d where d.userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid) };
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static string GetDesByProductId(int productid)
        {
            string des="";
            DbCommand command = db.GetSqlStringCommond(@"SELECT [des] FROM Wheels where productid = @productid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@productid", productid) };
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    des = reader.GetString(0);

                }
            }
            return des;
        }

        public static DataTable GetAllWheelsVehiclesByWheelsId(int wheelsId)
        {
            DbCommand command = db.GetSqlStringCommond(@"select w.wheelsId, w.vehicleid,v.vehiclename
                                    from WheelsVehicle w
                                    inner join Vehicles v
                                    on w.vehicleId = v.vehicleId
                                    where w.wheelsId = @wheelsId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@wheelsId", wheelsId) };
            command.Parameters.AddRange(paras);
            DataTable dt = db.ExecuteDataTable(command);

            return dt;
        }

        public static DataTable GetProductIdByVehicle(int vehicleid)
        {
            
                DbCommand command = db.GetSqlStringCommond(@"select w.wheelsId
                                    from WheelsVehicle w
                                    where w.vehicleid = @vehicleid");
                SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@vehicleid", vehicleid) };
                command.Parameters.AddRange(paras);
                DataTable dt = db.ExecuteDataTable(command);

                return dt;
            
        }

        public static DataTable GetAllWheelsVehicles()
        {
            DbCommand command = db.GetSqlStringCommond(@"select w.wheelsId, w.vehicleid,v.vehiclename
                                    from WheelsVehicle w
                                    inner join Vehicles v
                                    on w.vehicleId = v.vehicleId");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int DeleteProductById(int prodId)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"delete from wheels where ProductId=@ProductId");
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@ProductId", prodId) };
                    command.Parameters.AddRange(paras);
                    int ret = db.ExecuteNonQuery(command,t);

                    DbCommand command2 = db.GetSqlStringCommond(@"delete from WheelsVehicle where wheelsId=@wheelsId");
                    SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@wheelsId", prodId) };
                    command2.Parameters.AddRange(paras2);
                    db.ExecuteNonQuery(command2,t);

                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        public static int UpdateProduct(Wheels prod, List<Vehicle> listVehicles)
        {
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"UPDATE Wheels
                               SET [Image] = @Image
                                  ,[Style] = @Style
                                  ,[Brand] = @Brand
                                  ,[Size] = @Size
                                  ,[PCD] = @PCD
                                  ,[Finish] = @Finish
                                  ,[Offset] = @Offset
                                  ,[SEAT] = @SEAT
                                  ,[BORE] = @BORE
                                  ,[Weight] = @Weight
                                  ,[ONHand] = @ONHand
                                  ,[Price] = @Price
                                  ,[PartNO] = @PartNO
                                    ,[des] = @des
                             WHERE productId = @productId");
                    SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Image", prod.Image),
                new SqlParameter("@Style",prod.Style),
                new SqlParameter("@Brand",prod.Brand),
                new SqlParameter("@Size",prod.Size),
                new SqlParameter("@PCD",prod.Pcd),
                new SqlParameter("@Finish",prod.Finish),
                new SqlParameter("@Offset",prod.Offset),
                new SqlParameter("@SEAT",prod.Seat),
                new SqlParameter("@BORE",prod.Bore),
                new SqlParameter("@Weight",prod.Weight),
                new SqlParameter("@ONHand",prod.Onhand),
                new SqlParameter("@Price",prod.Price),
                new SqlParameter("@PartNO",prod.PartNO),
                new SqlParameter("@productId",prod.ProductId),
                new SqlParameter("@des",prod.Des)
            };
                    command.Parameters.AddRange(paras);
                    int ret = db.ExecuteNonQuery(command);

                    // remove all
                    DbCommand command2 = db.GetSqlStringCommond(@"delete from WheelsVehicle where wheelsId=@wheelsId");
                    SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@wheelsId", prod.ProductId) };
                    command2.Parameters.AddRange(paras2);
                    db.ExecuteNonQuery(command2,t);

                    //add all

                    foreach (Vehicle veh in listVehicles)
                    {
                        DbCommand command3 = db.GetSqlStringCommond(@"INSERT INTO [WheelsVehicle]
                                                   ([WheelsId]
                                                   ,[VehicleId])
                                             VALUES
                                                   (@wheelsId,@veh
                                                   )");
                        SqlParameter[] paras3 = new SqlParameter[] { 
                new SqlParameter("@veh", veh.VehicleId),new SqlParameter("@wheelsId", prod.ProductId)};
                        command3.Parameters.AddRange(paras3);
                        db.ExecuteNonQuery(command3, t);
                    }

                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }


        public static int AddNewProduct(Wheels prod, List<Vehicle> listVehicles)
        {
            using (Trans t = new Trans())
            {
                try
                {

                    DbCommand command = db.GetSqlStringCommond(@"
                    INSERT INTO [Wheels]
                               ([Image]
                               ,[Style]
                               ,[Brand]
                               ,[Size]
                               ,[PCD]
                               ,[Finish]
                               ,[Offset]
                               ,[SEAT]
                               ,[BORE]
                               ,[Weight]
                               ,[ONHand]
                               ,[Price]
                               ,[PartNO]
                                ,[des])
                         VALUES
                               (@Image,
                               @Style,
                               @Brand,
                               @Size,
                               @PCD, 
                               @Finish, 
                               @Offset, 
                               @SEAT,
                               @BORE,
                               @Weight,
                               @ONHand,
                               @Price,
                               @PartNO,
                                @des); Select @@IDENTITY;");
                    SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@Image", prod.Image),
                new SqlParameter("@Style",prod.Style),
                new SqlParameter("@Brand",prod.Brand),
                new SqlParameter("@Size",prod.Size),
                new SqlParameter("@PCD",prod.Pcd),
                new SqlParameter("@Finish",prod.Finish),
                new SqlParameter("@Offset",prod.Offset),
                new SqlParameter("@SEAT",prod.Seat),
                new SqlParameter("@BORE",prod.Bore),
                new SqlParameter("@Weight",prod.Weight),
                new SqlParameter("@ONHand",prod.Onhand),
                new SqlParameter("@Price",prod.Price),
                 new SqlParameter("@PartNO",prod.PartNO),
                 new SqlParameter("@des",prod.Des)
            };
                    command.Parameters.AddRange(paras);
                    //add relationship

                    int newWeehlesId = Convert.ToInt32(db.ExecuteScalar(command, t));
                    if (newWeehlesId > 0)
                    {
                        foreach (Vehicle veh in listVehicles)
                        {
                            DbCommand command2 = db.GetSqlStringCommond(@"INSERT INTO [WheelsVehicle]
                                                   ([WheelsId]
                                                   ,[VehicleId])
                                             VALUES
                                                   (@newWeehlesId,@veh
                                                   )");
                            SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@newWeehlesId", newWeehlesId),
                new SqlParameter("@veh", veh.VehicleId)};
                            command2.Parameters.AddRange(paras2);
                            db.ExecuteNonQuery(command2, t);
                        }
                    }
                    t.Commit();
                    return newWeehlesId;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }
    }
}