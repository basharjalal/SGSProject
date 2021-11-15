using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGS.Repositories;
using SGS.Domain.Dto;
using SGS.WebMVC;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using SGS.Domain.Entities;

using SGS.Services.Interfaces;
namespace SGS.WebMVC.Controllers
{
    public class FiscalYearController : Controller
    {
        private readonly IFiscalYear _FiscalYearRepository;
        public FiscalYearController(IFiscalYear FiscalYeaRepository)
        {
            _FiscalYearRepository = FiscalYeaRepository;
              }
        [HttpGet]
        public IActionResult Index()
        {
           
            List<FiscalYear> ListFiscalYear = _FiscalYearRepository.GetAllFiscalYear();
            return View(ListFiscalYear);
        }

        [HttpGet]
        public ViewResult Create()
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FiscalYear fiscalYear)
        {
            //if ((fiscalYear.EndedDate = ) && (fiscalYear.StartedDate = 0))
              //  ModelState.AddModelError("Status", "الرجاء ادخال الحالة :)");
   
            if (fiscalYear.StartedDate >= fiscalYear.EndedDate)
                ModelState.AddModelError("StartedDate", "يجب أن يكون تاريخ البدء أقل من تاريخ الانتهاء");
       
            //if (fiscalYear.StartedDate == { 1/1/ 0001 12:00:00 AM})
            //    ModelState.AddModelError("StartedDate", "ادخل تاريخ البداء"); 
            //if (fiscalYear.EndedDate == null)
            // ModelState.AddModelError("EndedDate", "ادخل تاريخ الانتهاء"); 


            if ((fiscalYear.Status != 1) && (fiscalYear.Status != 0))
                  ModelState.AddModelError("Status", "الرجاء ادخال الحالة :)");

    



            if (ModelState.IsValid)
            {
                _FiscalYearRepository.Create(fiscalYear);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            
            _FiscalYearRepository.Delete(id);
             
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            FiscalYear fiscalYear = _FiscalYearRepository.Get(id);
            return View(fiscalYear);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FiscalYear fiscalYear)
        {
            if (fiscalYear.StartedDate >= fiscalYear.EndedDate)
                ModelState.AddModelError("StartedDate", "يجب أن يكون تاريخ البدء أقل من تاريخ الانتهاء");
            if (ModelState.IsValid)
            {
                _FiscalYearRepository.Edit(fiscalYear);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}







