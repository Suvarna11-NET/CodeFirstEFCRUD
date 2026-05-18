using CrudOperationEFDBFirst.Data;
using CrudOperationEFDBFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationEFDBFirst.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _context.Employees.ToListAsync());
        }
        //create 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee Emp)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(Emp);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Emp);
        }
        public async Task<IActionResult> Edit(int id)
        {
             var emp=await _context.Employees.FindAsync(id);
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee  Emp)
        {
            _context.Employees.Update(Emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emp=await _context.Employees.FindAsync(id);
            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var emp = await _context.Employees.FirstAsync();
            return View(emp);
        }

    }
}
