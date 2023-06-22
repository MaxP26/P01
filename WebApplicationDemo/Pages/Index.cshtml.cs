using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Security;

namespace WebApplicationDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string StudentName { get; set; }

        public void OnGet()
        {
            ViewData["Test"] = "Hello test";
            StudentName = "Ivan Grozilov";
        }
        public void OnPostSaveData() { }
    }
}