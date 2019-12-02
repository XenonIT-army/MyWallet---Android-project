using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SqlliteApp.Standard.Entities
{
    [Table("PurchaseHistory")]
    class PurchaseHistory
    {
        [Key]
        public int PurchaseHistoryId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]

        public string Sum { get; set; }

        [Required]
        [MaxLength(256)]
        public string Percent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
    }
}
