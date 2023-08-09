﻿using Npgsql;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using userManagement.Models;

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

        public void newUser(Muser user,dbConn conn)
        {
            string querySql = $"INSERT INTO public.users (first_name, last_name, username, email, password) VALUES('{user.first_name}','{user.last_name}','{user.username}','{user.email}','{user.password}')";
            NpgsqlCommand cmd = new NpgsqlCommand(querySql, conn.openConn());
            cmd.ExecuteNonQuery();
            conn.closeConn();
        }

        public void updateUser(int id, string[] features, string[] alldata,dbConn conn) {
            string vars = "first_name, last_name, username, email, password";
            string result = "";

            int i = 0;
            try
            {
                foreach (string feature in features)
                {
                    if (vars.Contains(feature))
                    {
                        result += feature + "='"+alldata[i]+"',";
                    }
                    else
                    {
                        result = "";
                        Console.WriteLine("alguna de las caracteristicas o valores, no son correctas");
                        break;
                    }
                    i += 1;
                }
                result = result[..^1];
                string querySql = $"UPDATE public.users Set "+ result + $"WHERE id = {id}";
                Console.WriteLine(querySql);
                NpgsqlCommand cmd = new NpgsqlCommand(querySql, conn.openConn());
                cmd.ExecuteNonQuery();
                conn.closeConn();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            




        } 

    }
}
