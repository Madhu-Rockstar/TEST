using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class BoutiqueController : Controller
    {
        public ActionResult AllBoutique()
        {
            var Madhu = new Implementation();
            var model = Madhu.GetBoutique();
            return View(model);
        }
        public ActionResult OnEdit(BoutiqueShop postedData)
        {
            var Madhu = new Implementation();
            try
            {
                Madhu.UpdateBoutique(postedData);
                return RedirectToAction("AllBoutique");
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult AddBoutique(BoutiqueShop posteddata)
        {
            var com = new Implementation();
            try
            {
                com.AddBoutique(posteddata);              
                return RedirectToAction("AllBoutique");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new BoutiqueShop());
            }
        }
        [HttpPost]
        public ActionResult OnEdit(string id)
        {
            int Bid = Convert.ToInt32(id);
            var com = new Implementation();
            try
            {
                com.DeleteBoutique(Bid);
                return RedirectToAction("AllBoutique");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

    }
}