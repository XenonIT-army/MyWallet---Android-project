using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SqlliteApp.Standard.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Payment")]
    public partial class Payment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(256)]
       
        public string Balance { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(256)]
        public string Percent { get; set; }

    }
}
