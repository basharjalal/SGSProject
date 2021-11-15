using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SGS.Domain.common
{
  public  class CarntDateRangeAttribute:ValidationAttribute
    {

        public override bool IsValid(object value)
        { 
            DateTime dataTime = Convert.ToDateTime(value);
            return dataTime >= DateTime.Now;
        }
       
    }
}
