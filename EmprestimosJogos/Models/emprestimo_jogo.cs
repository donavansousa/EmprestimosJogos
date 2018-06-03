namespace EmprestimosJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class emprestimo_jogo
    {
        public int id { get; set; }

        [DisplayName("Jogo")]
        public int idJogo { get; set; }

        [DisplayName("Amigo")]
        public int idAmigo { get; set; }

        [Required]
        [StringLength(1)]
        [DisplayName("Situação")]
        public string status { get; set; }

        [DisplayName("Data")]
        public DateTime data { get; set; }

        public virtual Amigo Amigo { get; set; }

        public virtual Jogo Jogo { get; set; }
    }
}
