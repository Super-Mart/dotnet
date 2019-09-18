using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using A_Coding_cademy___Core_Razor_with_EFC.Models;

namespace A_Coding_cademy___Core_Razor_with_EFC.Pages.Courses
{   
        public class CreateModel : DepartmentNamePageModel
        {
            private readonly A_Coding_cademy___Core_Razor_with_EFC.Models.Context _context;

            public CreateModel(A_Coding_cademy___Core_Razor_with_EFC.Models.Context context)
            {
                _context = context;
            }

            public IActionResult OnGet()
            {
                PopulateDepartmentsDropDownList(_context);
                return Page();
            }

            [BindProperty]
            public Course Course { get; set; }

            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                var emptyCourse = new Course();

                if (await TryUpdateModelAsync<Course>(
                     emptyCourse,
                     "course",   // Prefix for form value.
                     s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits))
                {
                    _context.Courses.Add(emptyCourse);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                // Select DepartmentID if TryUpdateModelAsync fails.
                PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
                return Page();
            }
        }
    
}