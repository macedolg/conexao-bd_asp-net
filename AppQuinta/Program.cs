using System;

namespace AppQuinta
{
    class Program
    {
        static void Main(string[] args)
        {

            UsuarioDAO objDAO = new UsuarioDAO();
            



            Console.WriteLine("Informe o Id para identificação: ");
            string strIdUsu = Console.ReadLine();
            string strDado = objDAO.SelectDado(strIdUsu);
            Console.WriteLine("Olá senhor(a) " + strDado);

            Console.WriteLine("Digite o Nome: ");
            string strNomeUsu = Console.ReadLine();

            Console.WriteLine("Digite o Cargo: ");
            string strCargo = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento:");
            string strDataNasc = Console.ReadLine();

            objDAO.Insert(strNomeUsu, strCargo, strDataNasc);

            objDAO.SelectDado(strIdUsu);     

            objDAO.Select();



            //objDAO.Update(strNomeUsu, strCargo, strDataNasc, strIdUsu);

            //objDAO.Delete(strIdUsu);



            //string strSelectId = "SELECT NOMEUSU FROM TBUSUARIO WHERE IDUSU=" + 
            //    strIdUsu + ";";

            //Console.WriteLine("Banco conectado!");

        }
    }
}
