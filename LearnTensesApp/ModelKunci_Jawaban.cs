namespace LearnTensesApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelKunci_Jawaban : DbContext
    {
        public ModelKunci_Jawaban()
            : base("name=ModelKunci_Jawaban")
        {
        }

        public virtual DbSet<Kunci_Jawaban> Kunci_Jawaban { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
