using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contato
    {
        public int ContatoId { get; set; }

        [Display(Name = "* Nome.:")]
        [Required(ErrorMessage = "O Campo Nome deve ser preenchido")]
        public string ContatoNome { get; set; }
        
        [Display(Name = "* E-mail.:")]
        [Required(ErrorMessage = "O Campo E-mail deve ser preenchido")]
        public string ContatoEmail { get; set; }

        [Display(Name = "* Telefone")]
        [Required(ErrorMessage = "O Campo Telefone deve ser preenchido")]
        public string ContatoTelefone { get; set; }

        [Display(Name = "* Cidade.:")]
        [Required(ErrorMessage = "O Campo Cidade deve ser preenchido")]
        public string ContatoCidade { get; set; }

        [Display(Name = "* Assunto.:")]
        [Required(ErrorMessage = "o Campo Assunto deve ser preenchido")]
        public string ContatoAssunto { get; set; }

        [Display(Name = "* Mensagem.:")]
        [Required(ErrorMessage = "O Campo Mensagem deve ser preenchido")]
        public string ContatoMensagem { get; set; }
    }
}
