using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuinta
{
     class UsuarioDAO
    {
        Banco db = new Banco();

        public void Insert(string strNomeUsu, string strCargo, string strDataNasc)
        {
            string strInsert = string.Format("insert into tbUsuario(NomeUsu, Cargo, dataNasc)" +
            "values('{0}','{1}', " +
            "STR_TO_DATE('{2}', '%d/%m/%Y'));", 
            strNomeUsu, strCargo, strDataNasc);

            db.Open();
            db.ExecuteNowdSql(strInsert);
            db.Close();
        }

        public void Update(string strNomeUsu, string strCargo, string strDataNasc, string strIdUsu)
        {
            string strUpdate = string.Format("update tbUsuario set NomeUsu = '{0}'," +
                "Cargo = '{1}', DataNasc = STR_TO_DATE('{2}', '%d/%m/%Y') " +
                "where idUsu = '{3}';", 
                strNomeUsu, strCargo, strDataNasc, strIdUsu);
            db.Open();
            db.ExecuteNowdSql(strUpdate);
            db.Close();
        }

        public void Delete(string strIdUsu)
        {
            string strDelete = string.Format("delete from tbusuario where idUsu= {0};",
                strIdUsu);

            db.Open();
            db.ExecuteNowdSql(strDelete);
            db.Close();
        }

        public string SelectDado(string strIdUsu)
        {
            string strDado = "select NomeUsu from tbusuario where IdUsu = " +
                strIdUsu +
                ";";

            db.Open();
            strDado = db.ExecuteScalarSql(strDado);
            db.Close();

            return strDado;
        }

        public MySqlDataReader Select()
        {
            string strSelect = "select * from tbusuario;";

            db.Open();
            MySqlDataReader reader = db.ExecuteReadSql(strSelect);
            while (reader.Read())
            {
                Console.WriteLine("Código = {0} |   Nome = {1}  | Cargo = {2}   | Nascimento = {3}",
                     reader["IdUsu"], reader["NomeUsu"], reader["Cargo"], reader["DataNasc"]);
            }
            Console.ReadLine();

            reader.Close();
            db.Close();
            return reader;

        }
    }
}
