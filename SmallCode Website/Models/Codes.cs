using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallCode_Website.Models
{
    public class Codes
    {
        public int Id { get; set; }

        
        public string Title { get; set; }
        public string Writer { get; set; }

       
        public string CodeContent { get; set; }

        public string CreatedDate { get; set; }
    }
}
