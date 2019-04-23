using System.Web.Mvc;
using Nexio.Models;
using Nexio.Services;

namespace Nexio.Controllers
{
    public class HomeController : Controller
    {
        private ResultValidator _resultValidator;

        public HomeController()
        {
            _resultValidator = ResultValidator.Instance;
        }

        [HttpGet]
        public ActionResult CreateWoman()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateWoman(PersonModel woman)
        {
            if (_resultValidator.Dic.Count != 0)
                _resultValidator.Clear();
            
            if (ModelState.IsValid)
            {
                _resultValidator.Dic.Add("woman", woman);
                return RedirectToAction("CreateMan");
            }
            return View(woman);
        }

        [HttpGet]
        public ActionResult CreateMan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMan(PersonModel man)
        {
            if (ModelState.IsValid)
            {
                _resultValidator.Dic.Add("man", man);
                return RedirectToAction("Result");
            }
            return View(man);
        }

        public ActionResult Result()
        {
            ViewBag.Message = _resultValidator.ValidateResult();
            _resultValidator.Clear();
            return View();
        }
    }
}