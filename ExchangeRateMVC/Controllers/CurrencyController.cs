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

            Currency test = new Currency();

            access.deleteCurrency(1);

            return View(access.getCurrencies());
        }
        //POST: Currency

        //[HttpPost]
        //public ActionResult Add(Currency c)
        //{
        //    AccessWebAPI access = new AccessWebAPI();

        //    access.insertCurrency(c);

        //    return View(access.getCurrencies());
        //}
    }
}