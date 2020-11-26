namespace LearnTensesApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Kunci_Jawaban
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Kunci_Jawaban")]
        [Required]
        [StringLength(10)]
        public string Kunci_Jawaban1 { get; set; }
    }
}
