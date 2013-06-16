using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackMW2013.Controllers
{
    public class MockUpController : Controller
    {
        //
        // GET: /MockUp/

        public ActionResult ViewTree()
        {
            return View();
        }

        public ActionResult ManageLists()
        {
            return View();
        }
    }
}
