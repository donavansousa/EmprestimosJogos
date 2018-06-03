namespace EmprestimosJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class historico_emprestimo
    {
        public int id { get; set; }

        public DateTime data { get; set; }

        public int idJogo { get; set; }

        public int idAmigo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descricao { get; set; }
    }
}
