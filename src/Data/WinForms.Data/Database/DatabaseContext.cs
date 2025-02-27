﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WinForms.Data.Database
{
    public class DatabaseContext
    {
        public string connectionString;
        public SqlConnection conn;

        public DatabaseContext()
        {
            try
            {
                connectionString = "";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (SqlException e)
            {
                throw new ArgumentException("Erro na conexão com o banco de dados: "+e.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erro: " + ex.Message);
            }
        }

        public DataTable SqlQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro: " + e.Message);
            }
            return dt;
        }

        public string SqlCommand(string sql)
        {
            try
            {
                var myCommand = new SqlCommand(sql, conn);
                myCommand.CommandTimeout = 0;
                var myReader = myCommand.ExecuteReader();
                return "";
            }
            catch (Exception e)
            {
                throw new ArgumentException("Erro: " + e.Message);
            }
        }

        public void SqlClose()
        {
            conn.Close();
        }
    }
}
