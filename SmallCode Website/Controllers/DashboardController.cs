using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmallCode_Website.Areas.Identity.Data;
using SmallCode_Website.Data;
using SmallCode_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode_Website.Controllers
{
    public class DashboardController : Controller
    {
        private UsersDBContext _db;

        public DashboardController(UsersDBContext db)
        {
            _db = db;
        }

        public IActionResult Index(User user)
        {
            if (User.Identity.IsAuthenticated)   
            {
                return View(_db.Codes.Where(x=> x.Writer == User.Identity.Name).ToList());
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        public IActionResult AddCode()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCode(Codes code)
        {
            if (ModelState.IsValid)
            {
                code.Writer = User.Identity.Name;
                code.CreatedDate = DateTime.Now.ToString();
                
                _db.Codes.Add(code);
                await _db.SaveChangesAsync();
                TempData["added"] = "true";
                
                
                
                return Redirect("/dashboard/index");
            }
           
            return View(code);

        }

        
        public async Task<IActionResult> DeleteCode(int id)
        {
            Codes code = _db.Codes.ToList().Find(a => a.Id == id);
            if (User.Identity.IsAuthenticated)
            {
                if(code != null)
                {
                    if (code.Writer == User.Identity.Name)
                    {
                        _db.Codes.Remove(code);
                        await _db.SaveChangesAsync();
                        TempData["deleted"] = "true";
                    }
                    
                }
                
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
            return Redirect("/Dashboard");
        }
    }
}
