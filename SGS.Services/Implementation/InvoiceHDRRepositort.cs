using SGS.Domain.Entities;
using SGS.Repositories;
using SGS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGS.Services.Implementation
{ public class InvoiceHDRRepositort: IInvoiceHDR
    { private readonly SGSDbContext _myDbConnection;
        public InvoiceHDRRepositort(SGSDbContext myDbConnection)
        { _myDbConnection = myDbConnection;   }

        public List<InvoiceHDR> GetAllInvoiceHDR()
        {try
            { 
                List<InvoiceHDR> ListInvoiceHDR = _myDbConnection.InvoiceHDR.ToList();
 
                return ListInvoiceHDR; }
            catch (Exception ex)
            { 
                
                return null;  }
        }

        public void Create(InvoiceHDR invoiceHDR )
        {
            //_myDbConnection.ItemsDTL.Add(invoiceHDR.itemsDTL);
            _myDbConnection.InvoiceHDR.Add(invoiceHDR);

            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            var Delete = _myDbConnection.InvoiceHDR.FirstOrDefault(x => x.InvoiceID == id);
            _myDbConnection.InvoiceHDR.Remove(Delete);
            _myDbConnection.SaveChanges();
        }

        public void Edit(InvoiceHDR invoiceHDR)
        {
            _myDbConnection.InvoiceHDR.Update(invoiceHDR);
            _myDbConnection.SaveChanges();
        }

        public InvoiceHDR Get(int id)
        {
            InvoiceHDR invoiceHDR = _myDbConnection.InvoiceHDR.Where(x => x.InvoiceID == id).FirstOrDefault();
            if (invoiceHDR != null)
            {
                return invoiceHDR;
            }
            else
            {
                return new InvoiceHDR();
            }
        }

     

        }
    }
    
    


