using Microsoft.AspNetCore.Mvc;
using SGS.Domain.Dto;
using SGS.Domain.Entities;
using SGS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGS.WebMVC.Controllers
{
    public class InvoiceHDRController : Controller
    {
        private readonly IInvoiceHDR _InvoiceHDRRepository;
        public InvoiceHDRController(IInvoiceHDR InvoiceHDRRepository)
        {
            _InvoiceHDRRepository = InvoiceHDRRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //InvoiceHDRViewsModels data = new InvoiceHDRViewsModels;

            //data.InvoiceHDR = _InvoiceHDRRepository.GetAllStudents();
            List<InvoiceHDR> ListInvoiceHDR = _InvoiceHDRRepository.GetAllInvoiceHDR();
            return View(ListInvoiceHDR);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceHDR invoiceHDR )
        {
            if ((invoiceHDR.PaymentMethod != 1) && (invoiceHDR.PaymentMethod != 0))
           ModelState.AddModelError("PaymentMethod", "الرجاء ادخال الحالة :)");



            //for (int i = 0; i <= Request.Form.Count; i++)
            //{
            //    var ClientSampleID = Request.Form["ClientSampleID[" + i + "]"];
            //    var additionalComments = Request.Form["AdditionalComments[" + i + "]"];
            //    var acidStables = Request.Form["AcidStables[" + i + "]"];

            //    if (!String.IsNullOrEmpty(ClientSampleID))
            //    {

            //    }
            //}
            if (ModelState.IsValid)
            {
                _InvoiceHDRRepository.Create(invoiceHDR);
                
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {

            _InvoiceHDRRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            InvoiceHDR invoiceHDR = _InvoiceHDRRepository.Get(id);
            return View(invoiceHDR);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceHDR invoiceHDR)
        {

            if (ModelState.IsValid)
            {
                _InvoiceHDRRepository.Edit(invoiceHDR);
                return RedirectToAction("Index");

            }
            return View();
        }
   
    }



}