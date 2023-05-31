using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum blogYorum = new BlogYorum();

        public ActionResult Index()
        {
            //var degerler = c.Blogs.ToList();
            blogYorum.Deger1 = c.Blogs.ToList();
            blogYorum.Deger3 = c.Blogs.Take(3).OrderByDescending(x=>x.ID);
            blogYorum.Deger2 = c.Yorumlars.Take(3).OrderByDescending(x=>x.ID);
            return View(blogYorum);
        }
        public ActionResult BlogDetay(int id)
        {

            //var blogBul = c.Blogs.Where(item=>item.ID==id).ToList();
            blogYorum.Deger1 = c.Blogs.Where(item => item.ID == id).ToList();
            blogYorum.Deger2 = c.Yorumlars.Where(item => item.Blogid == id).ToList();
            blogYorum.Deger3 = c.Blogs.Take(3).OrderByDescending(x => x.ID);

            return View(blogYorum);
        }

        [HttpGet]
        public PartialViewResult Yorum(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Yorum(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
 
        


    }
}