using Npgsql;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace userManagement.data
{
    public class dbConn
    {
        private NpgsqlConnection conn;

        public dbConn()
        {
            conn = new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=Maria123.; Database=userManagementDb");
        }

        public NpgsqlConnection openConn()
        {
            try
            {
                conn.Open();
                Console.WriteLine("base de datos abierta");
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("problemas al abrir la base de datos");
                return null;
            }
        }

        public void closeConn()
        {
            conn.Close();
        }

        public void command(string querySql,dbConn conn)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(querySql, conn.openConn());
            cmd.ExecuteNonQuery();

        }

    }
}
