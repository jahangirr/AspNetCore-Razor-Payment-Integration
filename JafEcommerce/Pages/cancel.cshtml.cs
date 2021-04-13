using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JafEcommerce.Pages
{
    public class cancelModel : PageModel
    {
        [BindProperty]
        public string CancelMessage { get; set; }
        public void OnGet()
        {
            CancelMessage = "Transaction Cancel";
        }
    }
}
