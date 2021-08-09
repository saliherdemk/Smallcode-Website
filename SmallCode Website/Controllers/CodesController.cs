using Microsoft.AspNetCore.Mvc;
using SmallCode_Website.Data;
using SmallCode_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode_Website.Controllers
{
    public class CodesController : Controller
    {
        private UsersDBContext _db;

        public List<Codes> _allCode;

        public CodesController(UsersDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return Redirect("/");
        }

        public IActionResult Code(int id)
        {
            
            List<Codes> codes = _db.Codes.ToList();

            Codes code0 = codes.Find(x => x.Id == id);
            return View(code0);
        }
    }
}
