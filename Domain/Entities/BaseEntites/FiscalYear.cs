
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SGS.Domain.common;

namespace SGS.Domain.Entities
{
    public class FiscalYear
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(10, ErrorMessage = "عدد الاحرف اقل من عشرة احرف:)")]
        [MaxLength(250, ErrorMessage = "عدد الاحرف اكثر من مئتان وخمسون:)")]
        [Required(ErrorMessage = " الرجاء ادخال الاسم :)")]
        public string EnglishName { get; set; }
        [MinLength(10, ErrorMessage = "عدد الاحرف اقل من عشرة احرف:)")]
        [MaxLength(250, ErrorMessage = "عدد الاحرف اكثر من مئتان وخمسون:)")]
        [Display(Name = "Enter your email"), Required(ErrorMessage = " الرجاء ادخال الاسم :)")] 
        public string ArabicName { get; set; }
        [MinLength(0)]
        [MaxLength(250, ErrorMessage = "عدد الاحرف اكثر من مئتان وخمسون:)")]
        [Required(ErrorMessage = " الرجاء ادخال الاسم :)")]
        public string ClubName { get; set; }
      [DataType("datetime2(7)", ErrorMessage = " الرجاء ادخال الاسم :)")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CarntDateRange(ErrorMessage = "اقل من تاريخ اليوم")]
        public DateTime? StartedDate { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType("datetime2(7)")]
      [CarntDateRange(ErrorMessage="اقل من تاريخ اليوم")]
        public DateTime? EndedDate { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
       

