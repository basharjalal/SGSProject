using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SGS.Domain.Entities
{
  public class InvoiceHDR
    {   //public List<ItemsDTL> ListitemsDTL { get; set; }
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }
   [DataType("datetime2(7)")]
        public DateTime InvoiceDate { get; set; }
        [MinLength(0)]
        [MaxLength(500)]
        [Required(ErrorMessage = " please enter InvoiceNum :)")]
        public string InvoiceNum { get; set; }
       public int PaymentMethod { get; set; }
        [MinLength(0)]
        [MaxLength(150, ErrorMessage = "The number of letters is more than  150 :)")]
        [Required(ErrorMessage = " please enter Customer :)")]
        public string Customer { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MinLength(0)]
        [MaxLength(500)]
        public string Description { get; set; }
        public ItemsDTL itemsDTL { get; set; }
   
    }
}
