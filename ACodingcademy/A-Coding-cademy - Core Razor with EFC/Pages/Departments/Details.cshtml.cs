using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using A_Coding_cademy___Core_Razor_with_EFC.Models;

namespace A_Coding_cademy___Core_Razor_with_EFC.Pages.Departments
{
    public class DetailsModel : PageModel
    {
        private readonly A_Coding_cademy___Core_Razor_with_EFC.Models.Context _context;

        public DetailsModel(A_Coding_cademy___Core_Razor_with_EFC.Models.Context context)
        {
            _context = context;
        }

        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments
                .Include(d => d.Administrator).FirstOrDefaultAsync(m => m.DepartmentID == id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
