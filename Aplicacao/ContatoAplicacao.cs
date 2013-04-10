using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dominio;
using Repositorio;

namespace Aplicacao
{
    public class ContatoAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Salvar(Contato contato)
        {
            if (contato.ContatoId > 0)
                Alterar(contato);
            else
                Inserir(contato);
        }

        private void Alterar(Contato contato)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE CONTATO SET ContatoNome = '{0}', ContatoEmail = '{1}',ContatoTelefone = '{2}',ContatoCidade = '{3}',ContatoAssunto = '{4}',ContatoMensagem = '{5}'",contato.ContatoNome,contato.ContatoEmail,contato.ContatoTelefone,contato.ContatoCidade,contato.ContatoAssunto,contato.ContatoAssunto);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        private void Inserir(Contato contato)
        {
            var strQuery = "";
            strQuery = String.Format("INSERT INTO CONTATO(ContatoNome,ContatoEmail,ContatoTelefone,ContatoCidade,ContatoAssunto,ContatoMensagem) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",contato.ContatoNome,contato.ContatoEmail,contato.ContatoTelefone,contato.ContatoCidade,contato.ContatoAssunto,contato.ContatoMensagem);

            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM CONTATO WHERE ContatoId = {0}", id);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public List<Contato> ListarTodos()
        {
            var strQuery = " SELECT *FROM CONTATO";
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Contato ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM CONTATO WHERE ContatoId = " + id;
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Contato> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var contato = new List<Contato>();
            while (reader.Read())
            {
                var tempObjeto = new Contato()
                {
                    ContatoId = int.Parse(reader["ContatoId"].ToString()),
                    ContatoNome = reader["ContatoNome"].ToString(),
                    ContatoEmail = reader["ContatoEmail"].ToString(),
                    ContatoTelefone = reader["ContatoTelefone"].ToString(),
                    ContatoAssunto = reader["ContatoAssunto"].ToString(),
                    ContatoCidade = reader["ContatoCidade"].ToString(),
                    ContatoMensagem = reader["ContatoMensagem"].ToString()
                };
                contato.Add(tempObjeto);
            }
            return contato;
        }
    }
}
