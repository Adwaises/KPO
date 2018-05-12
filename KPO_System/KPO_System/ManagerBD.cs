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
        string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres; Password=123456;Database=school; ";
        NpgsqlDataAdapter da;
        NpgsqlConnection conn;

        public void init()
        {
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
    }
}
