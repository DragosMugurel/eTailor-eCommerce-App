using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public static class SqlDBHelper
    {
        private const int EROARE_LA_EXECUTIE = 0;

        private static string _connectionString = null;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.AppSettings.Get("StringConectare_BD_SQLServer");
                }
                return _connectionString;
            }
        }

        public static DataSet ExecuteDataSet(string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            using (DataSet ds = new DataSet())
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(parameters);

                    try
                    {
                        new SqlDataAdapter(cmd).Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        LogException(ex, sql, parameters);
                    }
                    return ds;
                }
            }
        }

        public static bool ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] parameters)
        {
            int result = EROARE_LA_EXECUTIE;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(parameters);

                    try
                    {
                        cmd.Connection.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        LogException(ex, sql, parameters);
                    }
                }
            }
            return result != EROARE_LA_EXECUTIE;
        }

        private static void LogException(SqlException ex, string sql, SqlParameter[] parameters)
        {
            // Log or handle the exception, you can customize this based on your logging requirements
            Console.WriteLine($"SQL Exception occurred: {ex.Message}");
            Console.WriteLine($"SQL Query: {sql}");

            foreach (var parameter in parameters)
            {
                Console.WriteLine($"Parameter: {parameter.ParameterName}, Value: {parameter.Value}");
            }
        }
    }
}
