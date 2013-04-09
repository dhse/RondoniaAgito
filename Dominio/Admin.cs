using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Admin
    {
        public int AdminId { get; set; }
        [Required(ErrorMessage = "O Usuário deve ser preenchido!")]
        [Display(Name = "Usuário:")]
        public string AdminLogin { get; set; }
        [Required(ErrorMessage = "A Senha deve ser informada!")]
        [Display(Name = "Senha:")]
        public string AdminSenha { get; set; }
        [Display(Name = "Nome:")]
        public string AdminNome { get; set; }
        [Display(Name = "E-mail:")]
        public string AdminEmail { get; set; }
        public string AdminFoto { get; set; }
    }
}
