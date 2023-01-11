using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvc.Data;
using MyMvc.Models;

namespace MyMvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        private readonly employeeDbcontext _context;
        public EmployeeController(employeeDbcontext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var emp = await _context.employeeTable.ToListAsync();
            return View(emp);
        }

        // GET: EmployeeController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            if (id == null || _context.employeeTable == null)
            {
                return NotFound();
            }
            var emp = await _context.employeeTable.FirstOrDefaultAsync(m => m.Id == id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(employee emp)
        {
            try
            {
                _context.employeeTable.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(emp);
            }
            return View(emp);
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id==null || _context.employeeTable == null){
                return NotFound();
            }
            var emp = await _context.employeeTable.FindAsync(id);
            if (emp == null)
            {
                return NotFound();

            }
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, employee emp)
        {
            if (id != emp.Id)
            {
                return NotFound();
            }
            _context.employeeTable.Update(emp);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Delete/5
        public async Task <IActionResult> Delete(int id)
        {
            if (id==null || _context.employeeTable == null){
                return NotFound();

            }
            var emp = await _context.employeeTable.FirstOrDefaultAsync(m =>m.Id==id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, employee emp)
        {
            var existing = await _context.employeeTable.FirstOrDefaultAsync(e =>e.Id == id);
            if (existing == null)
            {
                throw new ArgumentException($"Employee Does not exists"); }
                _context.Entry(existing).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
         
            return RedirectToAction(nameof(Index));
        }
    }
}
