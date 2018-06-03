namespace EmprestimosJogos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmprestimoContext : DbContext
    {
        public EmprestimoContext()
            : base("name=MvcConnectionString")
        {
        }

        public virtual DbSet<Amigo> Amigo { get; set; }
        public virtual DbSet<emprestimo_jogo> emprestimo_jogo { get; set; }
        public virtual DbSet<historico_emprestimo> historico_emprestimo { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amigo>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Amigo>()
                .Property(e => e.cpf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Amigo>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Amigo>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Amigo>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Amigo>()
                .HasMany(e => e.emprestimo_jogo)
                .WithRequired(e => e.Amigo)
                .HasForeignKey(e => e.idAmigo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<emprestimo_jogo>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<historico_emprestimo>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .HasMany(e => e.emprestimo_jogo)
                .WithRequired(e => e.Jogo)
                .HasForeignKey(e => e.idJogo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.cpf)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);
        }
    }
}
