using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmallCode_Website.Data;
using SmallCode_Website.Models;

namespace SmallCode_Website.Pages
{
    public class HomeModel : PageModel
    {
        private UsersDBContext _db;

        public List<Codes> _allCode;

        public HomeModel(UsersDBContext db)
        {
            _db = db;
            List < Codes > codes= _db.Codes.ToList();

            _allCode = codes;
        }
        public void OnGet()
        {
        }
    }
}
