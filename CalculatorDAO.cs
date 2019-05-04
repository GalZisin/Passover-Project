using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc170419
{
    public class CalculatorDAO : ICalculatorDAO
    {
        public void InsertValuesIntoTablesXAndY(int x, int y)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CalculatorDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("INSERT_X_Y", conn);

                cmd.Parameters.Add(new SqlParameter("@X_Value", x));
                cmd.Parameters.Add(new SqlParameter("@Y_Value", y));

                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
        public void GetOperationResult()
        {

            double result = 0;
            //Command and Data Reader
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CalculatorDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("SELECT ID, X_VALUE, OPERATION, Y_VALUE FROM Results", conn);

                cmd.Connection.Open();
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {
                    XTable xTable = new XTable
                    {
                        Id = (int)reader["ID"],
                        XValue = (int)reader["X_VALUE"]

                    };

                    YTable yTable = new YTable
                    {
                        Id = (int)reader["ID"],
                        YValue = (int)reader["Y_VALUE"]

                    };
                    Operation calcOperation = new Operation
                    {
                        Id = (int)reader["ID"],
                        //CalcOperation = (char)reader["Operation"];
                        CalcOperation = Convert.ToChar(reader["OPERATION"].ToString())


                    };

                    switch (calcOperation.CalcOperation)
                    {

                        case '+':
                            result = xTable.XValue + yTable.YValue;
                            break;

                        case '-':
                            result = xTable.XValue - yTable.YValue;
                            break;

                        case '*':
                            result = xTable.XValue * yTable.YValue;
                            break;

                        case '/':
                            result = (xTable.XValue * 1.00) / yTable.YValue;
                            break;
                    }

                    //    if (calcOperation.CalcOperation == '+')
                    //    {
                    //        result = xTable.XValue + yTable.YValue;
                    //    }
                    //    if (calcOperation.CalcOperation == '-')
                    //    {
                    //        result = xTable.XValue - yTable.YValue;
                    //    }
                    //    if (calcOperation.CalcOperation == '*')
                    //    {
                    //        result = xTable.XValue * yTable.YValue;
                    //    }
                    //    if (calcOperation.CalcOperation == '/')
                    //    {
                    //        result = (xTable.XValue * 1.00) / yTable.YValue;
                    //    }
                    //    UpdateToResults(xTable.Id, result);
                    //    result = 0;
                    //}

                    UpdateToResults(xTable.Id, result);
                    result = 0;
                    //cmd.Connection.Close();

                }

            }
        }
        public void UpdateToResults(int id, double result)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CalculatorDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand($"UPDATE Results SET RESULTS = {result} WHERE ID ={id}", conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void PrintResults()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=CalculatorDB;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Results", conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                while (reader.Read() == true)
                {

                    Console.WriteLine($"{reader["ID"]}    {reader["X_VALUE"]} {reader["OPERATION"]} {reader["Y_VALUE"]} = {reader["RESULTS"]}");
                }
            }
        }
    }
}
