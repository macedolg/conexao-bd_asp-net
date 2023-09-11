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

            db.Open();
            Console.WriteLine("Digite o Nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o Cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            string strDataNasc = Console.ReadLine();
            
            string strSelect = "SELECT * FROM tbUsuario;";
            MySqlDataReader reader = db.ExecuteReadSql(strSelect);



            while (reader.Read()) {
                Console.WriteLine("Código = {0} |   Nome = {1}  | Cargo = {2}   | Nascimento = {3}",
                    reader["IdUsu"], reader["NomeUsu"],reader["Cargo"],reader["DataNasc"]);
            }

            reader.Close();

            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, dataNasc)" +
                "values('{0}','{1}', " +
                "STR_TO_DATE('{2}', '%d/%m/%Y'));", strNomeUsu, strCargo, strDataNasc);;
            db.ExecuteNowdSql(strInsert);

            string strUpdate = "update tbusuario set nomeusu = 'João' where IdUsu = 4;";
            db.ExecuteNowdSql(strUpdate);

            string strDelete = "delete from tbusuario where idUsu=3; ";
            db.ExecuteNowdSql(strDelete);
            Console.WriteLine("Informe o Id para identificação: ");
            string IdUsu = Console.ReadLine();

            string strSelectId = "SELECT NOMEUSU FROM TBUSUARIO WHERE IDUSU=" + IdUsu + ";";

            string strDado = db.ExecuteScalarSql(strSelectId);
            Console.WriteLine("Olá senhor(a) " + strDado);
            db.Close();

            db.Open();
            Console.ReadLine();
            //Console.WriteLine("Banco conectado!");

        }
    }
}
