using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name); //Sisteme giriş yapan kullanıcıyı buluyoruz.
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory(); //resim yolunu al
                var extension = Path.GetExtension(p.Picture.FileName); //parametreden gelen picture'ın filename'ini al dedik.
                var imageName = Guid.NewGuid() + extension; // benzersiz resim ismini oluşturduk.
                var saveLocation = resource + "/wwwroot/UserImage/" + imageName; // resmi nereye kaydediyor onu belirledik.
                var stream = new FileStream(saveLocation, FileMode.Create); //resim dosyasını ekledik.
                await p.Picture.CopyToAsync(stream); //resmi kopyaladık.
                user.ImageUrl = imageName;
            }

            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password); // şifrre güncelleme.
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
