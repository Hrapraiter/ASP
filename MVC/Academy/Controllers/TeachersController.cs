using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;
using Academy;

public class TeachersController : Controller
{
    private readonly AcademyContext _context;

    public TeachersController(AcademyContext context)
    {
        _context = context;
    }

    // GET: TEACHERS
    public async Task<IActionResult> Index
    (
        string orderByName = "",
        string orderByDate = "" ,
        string searchString = "",
        int pageIndex = 0,
        int pageSize = 3
    )
    {
        IQueryable<Teacher> teachers = _context.Teachers;
        
        ViewData["orderByName"] = orderByName;
        ViewData["orderByDate"] = orderByDate;
        ViewData["searchString"] = searchString;
        ViewData["pageSize"] = pageSize;

        teachers = teachers.Where
            (t =>
                t.last_name.Contains(searchString) ||
                t .first_name.Contains(searchString)
            );

        switch (orderByDate) 
        {
            case "asc": teachers    = teachers.OrderBy(t => t.birth_date);          break;
            case "desc": teachers   = teachers.OrderByDescending(t => t.birth_date);break;
        }
        switch (orderByName) 
        {
            case "asc": teachers    = teachers.OrderBy(t => t.last_name).ThenBy(t => t.first_name);                     break;
            case "desc": teachers   = teachers.OrderByDescending(t => t.last_name).ThenByDescending(t => t.first_name); break;
        }

        return View(await PaginatedList<Teacher>.CreateAsync(teachers , pageIndex , pageSize));
    }

    // GET: TEACHERS/Details/5
    public async Task<IActionResult> Details(int? teacher_id)
    {
        if (teacher_id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers.Include(t => t.TDRs)
                                             .ThenInclude(tdr => tdr.Discipline)
                                             .FirstOrDefaultAsync(m => m.teacher_id == teacher_id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    // GET: TEACHERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TEACHERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("teacher_id,work_since,rate,last_name,first_name,middle_name,birth_date,email,phone,photo")] Teacher teacher)
    {
        if (ModelState.IsValid)
        {
            _context.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // GET: TEACHERS/Edit/5
    public async Task<IActionResult> Edit(int? teacher_id)
    {
        if (teacher_id == null)
        {
            return NotFound();
        }
        HashSet<int> selectedDisciplines = _context.TeachersDisciplinesRelation.Where(t => t.teacher == teacher_id)
                                                                               .Select(t => t.discipline)
                                                                               .ToHashSet<int>();
        
        ViewData["Disciplines_not_selected"] = await _context.Disciplines.Where(d => !selectedDisciplines.Contains(d.discipline_id))
                                                                         .ToListAsync();

        ViewData["Disciplines_selected"] = await _context.Disciplines.Where(d => selectedDisciplines.Contains(d.discipline_id))
                                                                     .ToListAsync();
        var teacher = await _context.Teachers.FindAsync(teacher_id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // POST: TEACHERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? teacher_id, [Bind("teacher_id,work_since,rate,last_name,first_name,middle_name,birth_date,email,phone,photo")] Teacher teacher)
    {
        if (teacher_id != teacher.teacher_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(teacher.teacher_id))
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
        return View(teacher);
    }

    // GET: TEACHERS/Delete/5
    public async Task<IActionResult> Delete(int? teacher_id)
    {
        if (teacher_id == null)
        {
            return NotFound();
        }

        var teacher = await _context.Teachers
            .Include(t => t.TDRs)
            .ThenInclude(tdr => tdr.Discipline)
            .FirstOrDefaultAsync(m => m.teacher_id == teacher_id);
        if (teacher == null)
        {
            return NotFound();
        }

        return View(teacher);
    }

    // POST: TEACHERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? teacher_id)
    {
        var teacher = await _context.Teachers.FindAsync(teacher_id);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TeacherExists(int? teacher_id)
    {
        return _context.Teachers.Any(e => e.teacher_id == teacher_id);
    }
}
