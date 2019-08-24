using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestPractice.Models;

namespace TestPractice.Controllers
{
    public class EmployeeDatasController : Controller
    {
        private readonly EmployeeContext _context;


        public EmployeeDatasController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: EmployeeDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeDatas.ToListAsync());
        }

        // GET: EmployeeDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            

                if (id == null)
                {
                    return NotFound();
                }

            var emp = _context.EmployeeDatas;
            var dat = _context.Employees;
            var employeeDetail = dat
                .Join(emp,
                e => e.EMPID,
                m => m.EMPID,
                (e, m) => new EmployeeDetailed {
                    EMPID=e.EMPID,
                    LASTNAME=m.LASTNAME,
                    FIRSTNAME=m.FIRSTNAME,
                    PHONE=m.PHONE,
                    HIREDATE=e.HIREDATE,
                    SALARY=e.SALARY,
                    DEPT=e.DEPT,
                    JOBCODE=e.JOBCODE,
                    SEX=e.SEX
                }).Where(x=>x.EMPID==id);
            
            
           
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail.FirstOrDefault());
        }

        // GET: EmployeeDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EMPID,BIRTHDATE,LASTNAME,FIRSTNAME,PHONE")] EmployeeData employeeData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }

        // GET: EmployeeDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeData = await _context.EmployeeDatas.FindAsync(id);
            if (employeeData == null)
            {
                return NotFound();
            }
            return View(employeeData);
        }

        // POST: EmployeeDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EMPID,BIRTHDATE,LASTNAME,FIRSTNAME,PHONE")] EmployeeData employeeData)
        {
            if (id != employeeData.EMPID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDataExists(employeeData.EMPID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeData);
        }

        // GET: EmployeeDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeData = await _context.EmployeeDatas
                .FirstOrDefaultAsync(m => m.EMPID == id);
            if (employeeData == null)
            {
                return NotFound();
            }

            return View(employeeData);
        }

        // POST: EmployeeDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeData = await _context.EmployeeDatas.FindAsync(id);
            _context.EmployeeDatas.Remove(employeeData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDataExists(int id)
        {
            return _context.EmployeeDatas.Any(e => e.EMPID == id);
        }
    }
}
