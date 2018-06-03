namespace EmprestimosJogos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Amigo")]
    public partial class Amigo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Amigo()
        {
            emprestimo_jogo = new HashSet<emprestimo_jogo>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required]
        [StringLength(14)]
        [DisplayName("CPF")]
        public string cpf { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(20)]
        [DisplayName("Telefone")]
        public string telefone { get; set; }

        [StringLength(20)]
        [DisplayName("Celular")]
        public string celular { get; set; }

        public bool ativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<emprestimo_jogo> emprestimo_jogo { get; set; }
    }
}
