namespace EmprestimosJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jogo")]
    public partial class Jogo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogo()
        {
            emprestimo_jogo = new HashSet<emprestimo_jogo>();
        }

        public int id { get; set; }

        [StringLength(255)]
        [DisplayName("Descrição")]
        public string descricao { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Título")]
        public string titulo { get; set; }

        public bool ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emprestimo_jogo> emprestimo_jogo { get; set; }
    }
}
