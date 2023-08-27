using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        public IActionResult Index()
        {
            var values = socialMediaManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult SocialMediaAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SocialMediaAdd(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            socialMediaManager.Insert(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult SocialMediaDelete(int id)
        {
            var values = socialMediaManager.GetByID(id);
            socialMediaManager.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SocialMediaUpdate(int id)
        {
            var values = socialMediaManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult SocialMediaUpdate(SocialMedia socialMedia)
        {
            socialMediaManager.Update(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
