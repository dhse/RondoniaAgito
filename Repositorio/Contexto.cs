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
