using SGS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGS.Services.Interfaces
{
    public interface IInvoiceHDR
    {
     
        public List<InvoiceHDR> GetAllInvoiceHDR();
        public void Create(InvoiceHDR invoiceHDR );
 
        public void Delete(int id);
        public void Edit(InvoiceHDR invoiceHDR);
        public InvoiceHDR Get(int id);
    }
}
