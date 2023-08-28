using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuinta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(@"Server = localhost;Database=dbAppBanco;User=root;Password=12345678");
            mySqlConnection.Open();

            Console.WriteLine("Digite o Nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o Cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            string strDataNasc = Console.ReadLine();

            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, dataNasc)" + "values('{0}','{1}', STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUsu, strCargo, strDataNasc);
            MySqlCommand ObjCommand5 = new MySqlCommand(strInsert, mySqlConnection);
            ObjCommand5.ExecuteNonQuery();



            string strSelect = "SELECT * FROM TBUSUARIO;";
            MySqlCommand ObjCommand = new MySqlCommand(strSelect, mySqlConnection);

            //string strInsert = "insert into tbUsuario(NomeUsu, Cargo, dataNasc)values('Fulano','Aluno','2023/05/16'); ";
            //MySqlCommand ObjCommand2 = new MySqlCommand(@strInsert, mySqlConnection);
            //ObjCommand2.ExecuteNonQuery();

            string strDelte = "delete from tbusuario where idUsu=3; ";
            MySqlCommand ObjCommand3 = new MySqlCommand(@strDelte, mySqlConnection);
            ObjCommand3.ExecuteNonQuery();

            string strUpdate = "update tbusuario set nomeusu = 'João' where IdUsu = 4;";
            MySqlCommand ObjCommand4 = new MySqlCommand(strUpdate, mySqlConnection);
            ObjCommand4.ExecuteNonQuery();

            MySqlDataReader reader = ObjCommand.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine("Código = {0} |   Nome = {1}  | Cargo = {2}   | Nascimento = {3}",
                    reader["IdUsu"], reader["NomeUsu"],reader["Cargo"],reader["DataNasc"]);
            }
            reader.Close();
            Console.ReadLine();
            //Console.WriteLine("Banco conectado!");

        }
    }
}
