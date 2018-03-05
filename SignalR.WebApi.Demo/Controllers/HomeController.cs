using SignalR.WebApi.Demo.Data;
using SignalR.WebApi.Demo.Models;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace SignalR.WebApi.Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLoginViewModel model)
        {
            // we logged in only by user name
            using (var ctx = new DemoContext())
            {
                var user = ctx.Users.FirstOrDefault(x => x.Name == model.Name);

                if (user == null) { ViewBag.ErrorMessage = "come on write user name correctly!"; return View("Index"); }

                Session["user"] = user;
                return RedirectToAction("Form");
            }
        }

        public ActionResult Form()
        {
            var user = Session["user"] as User;
            if (user == null) { ViewBag.ErrorMessage = "error while getting user by sesssion!"; return View("Form");}

            using (var ctx = new DemoContext())
            {
                var userForms = ctx.Users.Include(x => x.Forms).FirstOrDefault(x => x.Id == user.Id).Forms;
                return View(userForms);
            }
        }

        public ActionResult Details(int id)
        {
            var user = Session["user"] as User;
            if (user == null) { ViewBag.ErrorMessage = "error while getting user by sesssion!"; return View("Details"); }

            using (var ctx = new DemoContext())
            {
                var userForm = ctx.Forms.Include(x => x.Users).FirstOrDefault(x => x.Id == id && x.Users.Any(y => y.Id == user.Id));

                if (userForm == null) { ViewBag.ErrorMessage = "error while getting user by sesssion!"; return View("Details"); }

                TempData["UserId"] = user.Id;
                TempData["IsAdmin"] = user.IsAdmin;

                return View(userForm);
            }
        }
    }
}
