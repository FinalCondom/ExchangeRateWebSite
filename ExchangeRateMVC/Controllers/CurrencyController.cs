using ExchangeRateBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExchangeRateDTO;

namespace ExchangeRateMVC.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult Index()
        {
            AccessWebAPI access = new AccessWebAPI();

            Currency temp = access.getCurrencies().FirstOrDefault();
            temp.Name = "PROUT";
            access.updateCurrency(temp);
            return View(access.getCurrencies());
        }
        //POST: Currency

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Currency c)
        {
            if (ModelState.IsValid)
            {
                AccessWebAPI access = new AccessWebAPI();

                access.insertCurrency(c);

                return RedirectToAction("Index");
            }
            return View();
        }
        //PUT : Currency
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            Currency currency = access.getCurrencies().FirstOrDefault(m=>m.Id==id);
            return View(currency);
        }

        [HttpPost]
        public ActionResult Edit(Currency c)
        {
            if (ModelState.IsValid)
            {
                AccessWebAPI access = new AccessWebAPI();

                access.updateCurrency(c);

                return RedirectToAction("Index");
            }
            return View();
        }
        //Delete Request
        public ActionResult Delete(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            access.deleteCurrency(id);
            return RedirectToAction("Index");
        }
    }
}