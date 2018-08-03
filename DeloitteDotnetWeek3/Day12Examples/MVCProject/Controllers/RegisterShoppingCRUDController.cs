using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class RegisterShoppingCRUDController : Controller
    {
        TrainingDBEntities db = new TrainingDBEntities();
        // GET: RegisterShoppingCRUD
        [HttpGet]
        public ActionResult InsertRegisterShopping()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRegisterShopping(RegisterShopping rs)
        {
            rs.Name = Request.Form["txtname"].ToString();
            rs.Gender = Request.Form["gender"].ToString();
            rs.Membership = Request.Form["ddlmember"].ToString();
            rs.ShoppingPreference = Request.Form["shop"].ToString();

            var res = Request.Form["cbcod"].ToString();
            if (res == "false")
                rs.COD = "No";
            else
                rs.COD = "Yes";

            rs.Password = Request.Form["txtpass"].ToString();

            db.RegisterShoppings.Add(rs);

            var r = db.SaveChanges();

            if (r > 0)
                ModelState.AddModelError("", "Data inserted");




            return View();
        }

        [HttpGet]
        public ActionResult SelectAllRegisterShopping()
        {
            var data = db.RegisterShoppings.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult SelectByID()
        {
            var data = new SelectList(db.RegisterShoppings, "Id", "Name");
            Session["rsdata"] = data;
            return View();

        }

        [HttpPost]
        public ActionResult SelectByID(string Command)
        {
            int id = int.Parse(Request.Form["ddlid"].ToString());
            if (Command == "SelectByID")
            {


                var data = db.RegisterShoppings.Where(x => x.Id == id).SingleOrDefault();
                ViewData["userdata"] = data;
                return View();

            }

            if (Command == "Update")
            {
                int oldid = int.Parse(Request.Form["txtid"].ToString());
                var olddata = db.RegisterShoppings.Where(x => x.Id == oldid).SingleOrDefault();

                olddata.Membership = Request.Form["txtmem"].ToString();
                olddata.ShoppingPreference = Request.Form["txtshop"].ToString();
                olddata.COD = Request.Form["txtcod"].ToString();

                var res = db.SaveChanges();
                if (res > 0)
                    ModelState.AddModelError("", "Data Upload");
                return View();
            }

            if (Command == "Delete")
            {
                int oldid = int.Parse(Request.Form["txtid"].ToString());
                var olddata = db.RegisterShoppings.Where(x => x.Id == oldid).SingleOrDefault();

                db.RegisterShoppings.Remove(olddata);
                var res = db.SaveChanges();
                if (res > 0)
                    ModelState.AddModelError("", "Data Deleted");
                return View();
            }


            return View();



        }
        [HttpGet]
        public ActionResult SelectAndEdit()
        {
            var data = db.RegisterShoppings.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var data = db.RegisterShoppings.Where(x => x.Id == id).SingleOrDefault();
            Session["RSData"] = data;
            return View();

        }

        [HttpPost]
        public ActionResult Update()
        {
            int id = int.Parse(Request.Form["txtid"].ToString());

            var olddate = db.RegisterShoppings.Where(x => x.Id == id).SingleOrDefault();
            olddate.Membership = Request.Form["txtmem"].ToString();
            olddate.ShoppingPreference = Request.Form["txtshop"].ToString();
           

            var res = db.SaveChanges();
            if (res > 0)
            {
                //Response.Write("Data Updated");
                return RedirectToAction("SelectAndEdit"); // redirecting from controller
            }
            return View();
        }
    }
}