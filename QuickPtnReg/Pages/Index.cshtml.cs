using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuickPtnReg.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
          
        }


        public IActionResult OnGet()
        {
            return RedirectToPage("/Register");
        }

        //public void OnGet()
        //{
        //      RedirectToPage("/Register");
        //}
    }
}