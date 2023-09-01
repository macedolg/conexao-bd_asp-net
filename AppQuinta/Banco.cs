using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuinta
{
    class Banco
    {
        private readonly MySqlConnection conexao = new MySqlConnection(@"Server = localhost;Database=dbAppBanco;User=root;Password=12345678");
        private readonly MySqlCommand cmd = new MySqlCommand();

        public void Open()
        {
            if (conexao.State == ConnectionState.Closed) 
                conexao.Open(); 
        }

        public void Close()
        {
            if (conexao.State == ConnectionState.Open) 
              conexao.Close(); 
        }

        public MySqlDataReader ExecuteReadSql(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

    }
}

