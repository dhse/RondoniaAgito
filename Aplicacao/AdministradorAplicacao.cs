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
    public class AdministradorAplicacao
    {
        private Contexto contexto = new Contexto();

        public void Salvar(Administrador admin)
        {
            if (admin.AdminId > 0)
                Alterar(admin);
            else
                Inserir(admin);
        }

        private void Alterar(Administrador admin)
        {
            var strQuery = "";
            strQuery = string.Format("UPDATE ADMINISTRADOR SET AdminLogin = '{0}', AdminSenha = '{1}', AdminNome = '{2}', AdminEmail = '{3}', AdminFoto = '{4}'", admin.AdminLogin, admin.AdminSenha, admin.AdminNome, admin.AdminEmail, admin.AdminFoto);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        private void Inserir(Administrador admin)
        {
            var strQuery = "";
            strQuery = String.Format("INSERT INTO ADMINISTRADOR(AdminLogin,AdminSenha,AdminNome,AdminEmail,AdminFoto) VALUES('{0}','{1}','{2}','{3}','{4}')", admin.AdminLogin, admin.AdminSenha, admin.AdminNome, admin.AdminEmail, admin.AdminFoto);

            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public void Excluir(int id)
        {
            var strQuery = string.Format(" DELETE FROM ADMINISTRADOR WHERE ADMINID = {0}", id);
            contexto.ExecutaComandoInserirtAlterarDeletetar(strQuery);
        }

        public List<Administrador> ListarTodos()
        {
            var strQuery = " SELECT *FROM ADMINISTRADOR";
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno);
        }

        public Administrador ListarPorId(int id)
        {
            var strQuery = " SELECT * FROM ADMINISTRADOR WHERE AdminId = " + id;
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            return TransformaReaderEmListaDeObjeto(retorno).FirstOrDefault();
        }

        private List<Administrador> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var admin = new List<Administrador>();
            while (reader.Read())
            {
                var tempObjeto = new Administrador()
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

        public bool Logar(Administrador admin)
        {
            bool usuarioValido = false;
            var strQuery = string.Format(" SELECT * FROM ADMINISTRADOR WHERE ADMINLOGIN = '{0}' AND ADMINSENHA = '{1}' ", admin.AdminLogin, admin.AdminSenha);
            var retorno = contexto.ExecutaComandoRetorno(strQuery);
            usuarioValido = retorno.HasRows;
            contexto.ConectarNoBanco().Close();
            return (usuarioValido);
        }

    }
}
