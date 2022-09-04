using DBconnTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;



namespace MVCTest.Controllers
{
    public class HomeController : Controller
    {
        DBmanager db = new DBmanager();
        public ActionResult Login()
        {            
            return View();
        }        

        public ActionResult Register()
        {
            
            List<City> cityList = db.Getcity();           

            ViewBag.CityList = cityList;            
            return View();
            //return View();
        }

        public ActionResult Transcripts()
        {
            return View();
        }

    //    [HttpPost]
    //    public ActionResult Village(int id)
    //    {
    //        List<Village> list = db.Getvillage(id);
    //        string result = "";            
            
    //        if (list == null)
    //        {
    //            //讀取資料庫錯誤
    //            return Json(result);
    //        }
    //        else
    //        {
    //            result = JsonConvert.SerializeObject(list);
    //            return Json(result);
    //        }
    //    }
    }
}

        //[HttpPost]  //使用post時才放，要不然網頁會出現錯誤
        //public ActionResult Transcripts(Student model)
        //{
        //    string id = model.id;
        //    string name = model.name;
        //    int score = model.score;
        //    Student data = new Student(id, name, score);
        //    return View(data);

        //public ActionResult Transcripts(string id, string name, int score)
        //{

        //    Student data = new Student(id, name, score);
        //    return View(data);
        //}
    
