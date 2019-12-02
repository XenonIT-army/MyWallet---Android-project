using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SqlliteApp.Standard.Entities
{
    [System.ComponentModel.DataAnnotations.Schema.Table("History")]
    public partial class PurchaseHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Sum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
