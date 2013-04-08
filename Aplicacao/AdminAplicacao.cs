using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Repositorio;


namespace Aplicacao
{
    public class AdminAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Salvar(Admin admin)
        {
            if (admin.AdminId > 0)
                Alterar(admin);
            else
                Inserir(admin);
        }

        private void Alterar(Admin admin)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE ADMIN SET ");
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        private void Inserir(Admin admin)
        {
            var strQuery = "";
            strQuery = String.Format("INSERT INTO ADMIN () VALUES()");

            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM ADMIN WHERE ADMINID = {0}", id);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public List<Admin> ListarTodos()
        {
            var strQuery = " SELECT *FROM ADMIN";
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        private List<Admin> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var admin = new List<Admin>();
            while (reader.Read())
            {
                var tempObjeto = new Admin()
                {
                    AdminId = int.Parse(reader["AdminId"].ToString()),
                    AdminNome = reader["AdminNome"].ToString(),
                    AdminLogin = reader["AdminLogin"].ToString(),
                    AdminSenha = reader["AdminSenha"].ToString(),
                    AdminEmail = reader["AdminEmail"].ToString(),
                    AdminFoto = reader["AdminFoto"].ToString()
                };
                admin.Add(tempObjeto);
            }
            return admin;
        }

        public bool Logar(Admin admin)
        {
            bool usuarioValido = false;
            var strQuery = string.Format(" SELECT * FROM ADMIN WHERE ADMINLOGIN = '{0}' AND ADMINSENHA = '{1}' ", admin.AdminLogin, admin.AdminSenha);
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            usuarioValido = retorno.HasRows;
            contexto.ConectarNoBanco().Close();
            return (usuarioValido);
        }

    }
}
