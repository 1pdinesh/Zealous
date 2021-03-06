﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zealous.Models;

namespace Zealous.Controllers
{
    public class PaymentController : ZealousController
    {

     


        //retrieve data and save in database 
        public ActionResult GetDataPaypal()
        {
            var getData = new GetDataPaypal();
            var order = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.tx = Request.QueryString["tx"];


            var payment = new Payment();
            payment.Amount = order.GrossTotal;
           
            payment.Date = DateTime.Now;
            payment.EventId = 1;
            db.Payments.Add(payment);
            db.SaveChanges();
            Session["cart"] =null;
            return View(order);
        }

        //retrieve data to view using id
        public ActionResult OrderNow(int? id)
        {
            var p = db.Events.FirstOrDefault(t => t.Id == id);
            List<Event> IsCart;
            if (p == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["strCart"] == null)
            {
               IsCart = new List<Event>
                {
                   p
            };
                Session["strCart"] = IsCart;

            }
            else
            {
                 IsCart = (List<Event>)Session["strCart"];

                IsCart.Add(p);
                Session["strCart"] = IsCart;
            }


            return View("index", IsCart);


        }
       


        //delete data from session according to id
        public ActionResult Delete(int? id)
        {
            //db.Products.FirstOrDefault(t=>t.Id==id);
            List<Event> IsCart = (List<Event>)Session["strCart"];
            var p = IsCart.FirstOrDefault(t => t.Id == id);
            if (p == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            
            IsCart.Remove(p);
            Session["strCart"] = IsCart;
            return View("index", IsCart);
        }





    }
}