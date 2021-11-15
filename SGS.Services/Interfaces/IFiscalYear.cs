using SGS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;

namespace SGS.Services.Interfaces
{
    public interface IFiscalYear
    {
        public void Create(FiscalYear fiscalYear);
        public List<FiscalYear> GetAllFiscalYear(); 
        public void Delete(int id);
        public void Edit(FiscalYear fiscalYear);
        public FiscalYear Get(int id);
    }
}
