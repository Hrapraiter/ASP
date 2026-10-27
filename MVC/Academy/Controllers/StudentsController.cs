
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;
using System.Collections.Immutable;
using Academy;
using Microsoft.SqlServer.Server;

public class StudentsController : Controller
{
    private readonly AcademyContext _context;

    public StudentsController(AcademyContext context)
    { 
        _context = context;
    }
    public Task<List<Group>> Groups { get => _context.Groups.ToListAsync(); }
    // GET: STUDENTS
    //public async Task<IActionResult> Index()    
    //{
    //    return View(await _context.Students.Include(s => s.Group)
    //                                       .ToListAsync());
    public async Task<IActionResult> Index
    (
        string orderByName = "",
        string orderByDate = "",
        string searchString = "",
        int pageIndex= 0,
        int pageSize = 5
    )    
    //public async Task<IActionResult> Index([Bind("orderByName,orderByDate,searchString,pageIndex,pageSize")] ModelIndexArgs studArgs)    
    {
        ViewData["orderByName"] = orderByName;
        ViewData["orderByDate"] = orderByDate;
        ViewData["searchString"] = searchString;

        ViewData["pageIndex"] = pageIndex;
        ViewData["pageSize"] = pageSize;

        searchString = searchString.ToLower();

        HashSet<int> searchStudentIds = (await _context.Students
                .AsNoTracking()
                .ToListAsync()
             )
            .Where(s => s.FullName.ToLower().Contains(searchString))
            .Select(s => s.stud_id)
            .ToHashSet();

        IQueryable<Student> students = _context.Students
            .Include(s => s.Group)
            .AsNoTracking()
            .Where(s => searchStudentIds.Contains(s.stud_id));


        switch (orderByDate) 
        {
            case "asc"  : students = students.OrderBy(s => s.birth_date);           break; 
            case "desc" : students = students.OrderByDescending(s => s.birth_date); break;
        }
        switch (orderByName) 
        {
            case "asc"  : students = students.OrderBy(s => s.last_name).ThenBy(s => s.first_name);           break; 
            case "desc" : students = students.OrderByDescending(s => s.last_name).ThenByDescending(s => s.first_name); break;
        }

        return View(await PaginatedList<Student>.CreateAsync(students, pageIndex, pageSize));
        //return View(await _context.Students.Include(s => s.Group)
        //                                   .ToListAsync());
    }

    // GET: STUDENTS/Details/5
    public async Task<IActionResult> Details(int? stud_id)
    {
        if (stud_id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .Include(s => s.Group)
            .FirstOrDefaultAsync(m => m.stud_id == stud_id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: STUDENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("stud_id,group,last_name,first_name,middle_name,birth_date,email,phone,photo")] Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }

    // GET: STUDENTS/Edit/5
    public async Task<IActionResult> Edit(int? stud_id)
    {
        if (stud_id == null)
        {
            return NotFound();
        }
        ViewData["Groups"] = await _context.Groups.ToListAsync();
        var student = await _context.Students.FindAsync(stud_id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // POST: STUDENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? stud_id, [Bind("stud_id,group,last_name,first_name,middle_name,birth_date,email,phone,photo")] Student student)
    {
        if (stud_id != student.stud_id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.stud_id))
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
        return View(student);
    }

    // GET: STUDENTS/Delete/5
    public async Task<IActionResult> Delete(int? stud_id)
    {
        if (stud_id == null)
        {
            return NotFound();
        }

        var student = await _context.Students
            .Include(s => s.Group)
            .FirstOrDefaultAsync(m => m.stud_id == stud_id);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: STUDENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? stud_id)
    {
        var student = await _context.Students.FindAsync(stud_id);
        if (student != null)
        {
            _context.Students.Remove(student);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentExists(int? stud_id)
    {
        return _context.Students.Any(e => e.stud_id == stud_id);
    }
}
