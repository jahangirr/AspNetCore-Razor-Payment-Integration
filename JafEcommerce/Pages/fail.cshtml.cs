using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JafEcommerce.Pages
{
    public class failModel : PageModel
    {

        [BindProperty]
        public string FailMessage { get; set; }
        public void OnGet()
        {
            FailMessage = "Transaction Fail";
        }
    }
}
