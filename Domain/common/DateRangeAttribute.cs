using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SGS.Domain.common
{
   public class DateRangeAttribute:RangeAttribute
    {
        public DateRangeAttribute(string maxValue)
      :base(typeof(DateTime),DateTime.Now.ToShortDateString(),maxValue)
        {
        
        
        
        }
    }
}
