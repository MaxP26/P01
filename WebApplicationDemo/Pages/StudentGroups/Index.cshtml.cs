using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Pages.StudentGroups
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationDemo.Data.ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(WebApplicationDemo.Data.ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<StudentGroup> StudentGroup { get;set; } = default!;

        [BindProperty]
        public string searchName { get; set; } = "Contains";

        [BindProperty]
        public string searchDirection { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.StudentGroup != null)
            {
                var result = _context.StudentGroup.AsQueryable();
                if (!string.IsNullOrEmpty(searchName))
                {
                    switch (searchDirection)
                    {
                        case "Contains":
                            result = result.Where(s => s.Name.Contains(searchName));
                            break;
                        case "StartWith":
                            result = result.Where(s => s.Name.StartsWith(searchName));
                            break;
                        case "EndWith":
                            result = result.Where(s => s.Name.EndsWith(searchName));
                            break;

                    }
                }
                StudentGroup = await result.ToListAsync();
            }
        }
   
        public async Task OnPostFilterAsync()
        {
            _logger.LogInformation("The set filter searchDirestion={0} searchString={1}", searchDirection, searchName);
            //_logger.LogInformation($"The set filter searchDirestion={searchDirection} searchString={searchName}");
            {
                var result = _context.StudentGroup.AsQueryable();
                if (!string.IsNullOrEmpty(searchName))
                {
                    switch (searchDirection)
                    {
                        case "Contains":
                            result = result.Where(s => s.Name.Contains(searchName));
                            break;
                        case "StartWith":
                            result = result.Where(s => s.Name.StartsWith(searchName));
                            break;
                        case "EndWith":
                            result = result.Where(s => s.Name.EndsWith(searchName));
                            break;

                    }
                }
                StudentGroup = await result.ToListAsync();
            }

        }


    }
}
