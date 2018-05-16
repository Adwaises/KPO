using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPO_System
{
    class ManagerBD
    {
        
        NpgsqlDataAdapter da;
        public NpgsqlConnection conn;
        string conn_param;

        public void init(string server, string port, string userId, string passw, string dataBase)
        {
            conn_param = String.Format( "Server={0};Port={1};User Id={2}; Password={3};Database={4}; ", server, port, userId, passw, dataBase);
            conn = new NpgsqlConnection(conn_param);
        }

        /// <summary>
        /// Управляющий запрос
        /// </summary>
        public void controlQuery(string сq)
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = сq;
                    //cmd.Parameters.AddWithValue("p", "Hello world");
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Запрос выборка
        /// </summary>
        /// <param name="sq"></param>
        public DataTable selectionQuery(string sql)
        {
            DataTable dt;
            try
            {
                conn.Open(); //Открываем соединение.

                da = new NpgsqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);

                conn.Close(); //Закрываем соединение.
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
            return dt;
        }

        public bool isConnect()
        {
            try
            {
                conn.Open(); //Открываем соединение.

                conn.Close(); //Закрываем соединение.
                return true;
            }
            catch (Exception ex)
            {
                //conn.Close();
                return false;
                //throw ex;
            }
           
        }
    }
}
