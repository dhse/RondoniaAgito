using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Contexto
    {
        //Connection String e ja faz uma conecção com o banco de dados
        public SqlConnection ConectarNoBanco()
        {
            //var coneccao = new SqlConnection(@"Server=adb6612a-8f48-49d5-9bfc-a19c0020b8ce.sqlserver.sequelizer.com;Database=dbadb6612a8f4849d59bfca19c0020b8ce;User ID=kcrjfbbtwgrvsvnt;Password=rcGKd23SuBC7FbjYzD2NCbPLtzbGQApLY5pU3oPFm6bSHenZeYzn6Zqpu4qLYuc2;");
            var coneccao = new SqlConnection(@"server=localhost;Integrated Security=SSPI;Initial Catalog=RondoniaAgito");
            coneccao.Open();
            return coneccao;
        }

        public void ExecutaComandoInserirtAlterarDeletetar(string strQuery)
        {
            var cmdComando = new SqlCommand { CommandText = strQuery, CommandType = CommandType.Text, Connection = ConectarNoBanco() };
            cmdComando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, ConectarNoBanco());
            return cmdComando.ExecuteReader();
        }


    }
}
