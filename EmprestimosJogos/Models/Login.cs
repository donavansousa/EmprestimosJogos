using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmprestimosJogos.Models
{
    public class Login
    {
        [Required]
        [StringLength(255)]
        [DisplayName("Login")]
        public string login { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Senha")]
        public string senha { get; set; }

        public string ReturnUrl { get; set; }
    }
}