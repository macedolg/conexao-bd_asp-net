using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace AppQuinta
{
    class Banco
    {
        private readonly MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        private readonly MySqlCommand cmd = new MySqlCommand();

        public void Open()
        {
            if (conexao.State == ConnectionState.Closed) 
                conexao.Open(); 
        }


        public MySqlDataReader ExecuteReadSql(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public void ExecuteNowdSql(string strQuery)
        {
            cmd.Connection = conexao;
            cmd.CommandText = strQuery;
            cmd.ExecuteNonQuery();
        }

        public string ExecuteScalarSql(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            string strRetorno = Convert.ToString(cmd.ExecuteScalar());
            return strRetorno;
        }
        public void Close()
        {
            if (conexao.State == ConnectionState.Open) 
                conexao.Close(); 
        }

    }
}

