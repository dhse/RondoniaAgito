using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorio;

namespace Aplicacao
{
    public class QuemSomosAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Salvar(QuemSomos quemSomos)
        {
            if (quemSomos.QuemSomosId > 0)
                Alterar(quemSomos);
            else
                Inserir(quemSomos);
        }

        private void Alterar(QuemSomos quemSomos)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE QUEMSOMOS SET ");
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        private void Inserir(QuemSomos quemSomos)
        {
            var strQuery = "";
            strQuery = String.Format("INSERT INTO ADMIN () VALUES()");

            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM QUEMSOMOS WHERE QUEMSOMOSID = {0}", id);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public List<QuemSomos> ListarTodos()
        {
            var strQuery = " SELECT *FROM QUEEMSOMOS";
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        private List<QuemSomos> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var quemSomos = new List<QuemSomos>();
            while (reader.Read())
            {
                var tempObjeto = new QuemSomos()
                                     {
                                         QuemSomosId = int.Parse(reader["QuemSomosId"].ToString()),
                                         QuemSomosDescricao = reader["QuemSomosDescricao"].ToString(),
                                         
                                     };
                quemSomos.Add(tempObjeto);
            }
            return quemSomos;
        }
    }
}
