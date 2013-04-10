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

        [Display(Name = "Usuário:")]
        [Required(ErrorMessage = "O Usuário deve ser preenchido!")]
        [MaxLength(30,ErrorMessage = "O Login deve ter no maximo 30 caracteres!")]
        public string AdminLogin { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "A Senha deve ser informada!")]
        [MaxLength(20,ErrorMessage = "A Senha deve ter no maximo 20 caracteres!")]
        public string AdminSenha { get; set; }
        
        [Display(Name = "Nome:")]
        public string AdminNome { get; set; }
        
        [Display(Name = "E-mail:")]
        public string AdminEmail { get; set; }
        
        public string AdminFoto { get; set; }
    }
}
