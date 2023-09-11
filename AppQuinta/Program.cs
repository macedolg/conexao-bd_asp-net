using MySql.Data.MySqlClient;
using System;
using System.Net ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AppQuinta
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco db = new Banco();

             MySqlConnection Conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString);
             Conexao.Open();

            Console.WriteLine("Digite o Nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o Cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            string strDataNasc = Console.ReadLine();

            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, dataNasc)" +
                "values('{0}','{1}', " +
                "STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUsu, strCargo, strDataNasc);
            // MySqlCommand ObjCommandI = new MySqlCommand(strInsert, Conexao);
            db.ExecuteNowdSql(strInsert);

            //string strInsert = "insert into tbUsuario(NomeUsu, Cargo, dataNasc)values('Fulano','Aluno','2023/05/16'); ";
            //MySqlCommand ObjCommand2 = new MySqlCommand(@strInsert, mySqlConnection);
            //ObjCommand2.ExecuteNonQuery();
            db.Open();
            string strUpdate = "update tbusuario set nomeusu = 'João' where IdUsu = 4;";
            //MySqlCommand ObjCommandUP = new MySqlCommand(strUpdate, Conexao);
            db.ExecuteNowdSql(strUpdate);

            string strDelete = "delete from tbusuario where idUsu=3; ";
            //MySqlCommand ObjCommandD = new MySqlCommand(@strDelete, Conexao);
            db.ExecuteNowdSql(strDelete);

            db.Open();
            string strSelect = "SELECT * FROM tbUsuario;";
            
            MySqlDataReader reader = db.ExecuteReadSql(strSelect);


            while (reader.Read()) {
                Console.WriteLine("Código = {0} |   Nome = {1}  | Cargo = {2}   | Nascimento = {3}",
                    reader["IdUsu"], reader["NomeUsu"],reader["Cargo"],reader["DataNasc"]);
            }

            
            reader.Close();
            db.Open();
            db.Close();
            Console.ReadLine();
            //Console.WriteLine("Banco conectado!");

        }
    }
}
