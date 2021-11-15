using SGS.Domain.Entities;
using SGS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace SGS.Services.Interfaces
{
    public class FiscalYearRepositort1 : IFiscalYear
    {
        private readonly SGSDbContext _myDbConnection;
        public FiscalYearRepositort1(SGSDbContext myDbConnection)
        { 

            _myDbConnection = myDbConnection;
        }
     
      
        public List<FiscalYear> GetAllFiscalYear()
        {

            try
            {
                //List<FiscalYear> s = (from stdsObj in _con.FiscalYear
                //                      select stdsObj).ToList();
                List<FiscalYear> ListFiscalYear = _myDbConnection.FiscalYear.Where(x => !x.IsDeleted).ToList();
                

                return ListFiscalYear;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public void Create(FiscalYear fiscalYear)
        {
           

            _myDbConnection.FiscalYear.Add(fiscalYear);

            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
         var Delete= _myDbConnection.FiscalYear.FirstOrDefault(x=>x.Id==id);
            //FiscalYear Delete = (from stdObj in _con.FiscalYear
            //                     where stdObj.Id == id
            //                     select stdObj).FirstOrDefault();

         
            Delete.IsDeleted = true;

  //          _myDbConnection.FiscalYear.Remove(Delete);
            _myDbConnection.SaveChanges();
         
        }

        public FiscalYear Get(int id)
        {
            FiscalYear fiscalYear = _myDbConnection.FiscalYear.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefault();
            if(fiscalYear !=null)
            {
                return fiscalYear;
            }
            else
            {
                return new FiscalYear();
            }
        }
        public void Edit(FiscalYear fiscalYear)
        {

            _myDbConnection.FiscalYear.Update(fiscalYear);
            _myDbConnection.SaveChanges();       
        }
    }
}
