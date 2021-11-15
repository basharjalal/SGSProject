using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGS.Domain.Entities
{
   public class ItemsDTL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCode { get; set; }
        
        public int InvoiceID { get; set; }
        public InvoiceHDR Invoice { get; set; }
        [MinLength(0)]
        [MaxLength(150,ErrorMessage = "The number of letters is more than  150 :)")]
        [Required(ErrorMessage = " please enter ItemName :)")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = " please enter  Qty :)")]
        public int Qty { get; set; }
        [Range(3, 14, ErrorMessage = "The number  is more than  3 orless than 14  :)")]
        [Required(ErrorMessage = " please enter  Price :)")]
        public int Price { get; set; }
    }
}
