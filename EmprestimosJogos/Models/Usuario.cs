namespace EmprestimosJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nome { get; set; }

        [Required]
        [StringLength(255)]
        public string login { get; set; }

        [Required]
        [StringLength(14)]
        public string cpf { get; set; }

        [Required]
        [StringLength(255)]
        public string senha { get; set; }

        public short ativo { get; set; }
        
    }
}
