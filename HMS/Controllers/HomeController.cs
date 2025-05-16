using System.Diagnostics;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        HmsContext context;

        public HomeController(HmsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (user.Password != null || user.Email != null || user.UserName != null)
            {
                var data = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password
                };
                context.Users.Add(data);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult LoginVerify(User user)
        {
            if (user.Password != null || user.Email != null)
            {
                var myUser = context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

                if (myUser != null)
                {
                    HttpContext.Session.SetString("user_id", myUser.Id.ToString());
                    HttpContext.Session.SetString("user_email", myUser.Email);
                    HttpContext.Session.SetString("user_name", myUser.UserName);

                    return RedirectToAction("Admin");
                }
            }
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("user_id") != null)
            {
                HttpContext.Session.Remove("user_id");
                HttpContext.Session.Remove("user_name");
                HttpContext.Session.Remove("user_email");

                return RedirectToAction("Index", "Home");
            }
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
