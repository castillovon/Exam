using ExamCounter.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamCounter.DataService
{
    public class DataSrvc
    {
        static SqlConnection _sqlConnection = new SqlConnection();

        public static void StoreCounter(CounterViewModel cnt)
        {
            try
            {
                _sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                using (cmd)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "StoreCounter_sp";
                    cmd.Parameters.Clear();


                    cmd.Parameters.Add(new SqlParameter("@cnt", SqlDbType.Int)).Value = cnt.Counter;
                    cmd.Connection = _sqlConnection;

                    if (cmd.Connection.State != System.Data.ConnectionState.Open)
                    {
                        cmd.Connection.Open();

                        int result = cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CounterViewModel GetCounter()
        {
             _sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
             
            CounterViewModel counteModel = new CounterViewModel();
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 var dtResult = new DataTable();
                 using (cmd)
                 {
                     cmd.Connection = _sqlConnection;
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.CommandText = "GetCounter";
                     cmd.Parameters.Clear();

                     cmd.Connection.Open();
                     var sqlAdapter = new SqlDataAdapter(cmd);
                     sqlAdapter.Fill(dtResult);
                     cmd.Connection.Close();

                 }

                 if (dtResult.Rows.Count > 0)
                 {
                     var dr = dtResult.Rows[0];
                     counteModel.Counter = Convert.ToInt32(dr[0]);
                    
                 }
                 return counteModel;
             }
             catch(Exception ex)
             {
                 throw ex;
             }
          
                 
             
        }


       
    }
}