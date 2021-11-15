using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace SGS.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Is_Deleted { get; set; }
    }
}
