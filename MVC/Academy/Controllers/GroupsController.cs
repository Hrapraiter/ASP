
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Academy.Views.ViewModel;
using Academy;
using Microsoft.AspNetCore.Routing.Template;

public class GroupsController : Controller
{
    private readonly AcademyContext _context;

    public GroupsController(AcademyContext context)
    {
        _context = context;
    }

    // GET: GROUPS
    //public async Task<IActionResult> Index()    
    //{
    //    return View(await _context.Groups.Include(g => g.Direction)
    //                                     .ToListAsync());
    //}

    //void SwitchForIndexBody<T,TResult>(ref IQueryable<T> items, Func<T, TResult> order_func , string switch_str)
    //{
    //    switch (switch_str)
    //    {
    //        case "asc"  : items = items.OrderBy(order_func).AsQueryable(); break;
    //        case "desc" : items = items.OrderByDescending(order_func).AsQueryable(); break;
    //    }
    //}
    public async Task<IActionResult> Index
    (
        int? group_id,

        string GroupOrderByName = "",
        string GroupOrderByDate = "",
        string GroupSearchString = "",
        int    GroupPageIndex = 0 , 
        int    GroupPageSize = 3,
        
        string StudentOrderByName = "",
        string StudentOrderByDate = "",
        string StudentSearchString = "",
        int    StudentPageIndex = 0 , 
        int    StudentPageSize = 5
    )
    {
        ViewData["group_id"] = null;

        ViewData["groupOrderByName"]    = GroupOrderByName;
        ViewData["groupOrderByDate"]    = GroupOrderByDate;
        ViewData["groupSearchString"]   = GroupSearchString;
        ViewData["groupPageIndex"]      = GroupPageIndex;
        ViewData["groupPageSize"]       = GroupPageSize;
        
        ViewData["studentOrderByName"]  = StudentOrderByName;
        ViewData["studentOrderByDate"]  = StudentOrderByDate;
        ViewData["studentSearchString"] = StudentSearchString;
        ViewData["studentPageIndex"]    = StudentPageIndex;
        ViewData["studentPageSize"]     = StudentPageSize;

        GroupSearchString = GroupSearchString.ToLower();
        StudentSearchString = StudentSearchString.ToLower();

        GroupIndexData viewModel = new GroupIndexData();

        IQueryable<Group> groups = _context.Groups
            .AsNoTracking()
            .Where(g => g.group_name.Contains(GroupSearchString));

        //SwitchForIndexBody(ref groups, g => g.start_date, GroupOrderByDate);
        //SwitchForIndexBody(ref groups, g => g.group_name, GroupOrderByName);

        switch (GroupOrderByDate)
        {
            case "asc":  groups = groups.OrderBy(g => g.start_date);           break;
            case "desc": groups = groups.OrderByDescending(g => g.start_date); break;
        }
        switch (GroupOrderByName)
        {
            case "asc":  groups = groups.OrderBy(g => g.group_name); break;
            case "desc": groups = groups.OrderByDescending(g => g.group_name); break;
        }

        viewModel.Groups = await PaginatedList<Group>.CreateAsync(groups, GroupPageIndex, GroupPageSize);

        if (group_id != null)
        {
            ViewData["group_id"] = group_id.Value;
            ViewData["group_name"] = (await _context.Groups.FirstOrDefaultAsync(g => g.group_id == group_id.Value))!.group_name;
            HashSet<int> studentSearchIds = 
                (await _context.Students
                  .Include(s => s.Group)
                  .AsNoTracking()
                  .Where(s => s.Group!.group_id == group_id.Value)
                  .ToListAsync()
                )
                .Where(s => s.FullName.ToLower().Contains(StudentSearchString))
                .Select(s => s.stud_id)
                .ToHashSet();

            IQueryable<Student> students = _context.Students.Where(s => studentSearchIds.Contains(s.stud_id));

            //SwitchForIndexBody(ref students, s => s.birth_date, StudentOrderByDate);
            
            switch (StudentOrderByName)
            {
                case "asc":  students = students.OrderBy(s => s.birth_date);           break;
                case "desc": students = students.OrderByDescending(s => s.birth_date); break;
            }
            switch (StudentOrderByName)
            {
                case "asc":  students = students.OrderBy(s => s.last_name).ThenBy(s => s.first_name);                     break;
                case "desc": students = students.OrderByDescending(s => s.last_name).ThenByDescending(s => s.first_name); break;
            }

            viewModel.Students = await PaginatedList<Student>.CreateAsync(students , StudentPageIndex , StudentPageSize);
        }

        return View(viewModel);
    }

    // GET: GROUPS/Details/5
    public async Task<IActionResult> Details(int? group_id)
    {
        if (group_id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups
            .Include(g => g.Direction)
            .FirstOrDefaultAsync(m => m.group_id == group_id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }

    // GET: GROUPS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GROUPS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("group_id,direction,group_name,start_date,start_time,learning_days")] Group group)
    {
        if (ModelState.IsValid)
        {
            _context.Add(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(group);
    }

    // GET: GROUPS/Edit/5
    public async Task<IActionResult> Edit(int? group_id)
    {
        if (group_id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups.FindAsync(group_id);
        if (group == null)
        {
            return NotFound();
        }
        return View(group);
    }

    // POST: GROUPS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? group_id, [Bind("group_id,direction,group_name,start_date,start_time,learning_days")] Group group)
    {
        if (group_id != group.group_id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(group);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(group.group_id))
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
        return View(group);
    }

    // GET: GROUPS/Delete/5
    public async Task<IActionResult> Delete(int? group_id)
    {
        if (group_id == null)
        {
            return NotFound();
        }

        var group = await _context.Groups
            .Include(g => g.Direction)
            .FirstOrDefaultAsync(m => m.group_id == group_id);
        if (group == null)
        {
            return NotFound();
        }

        return View(group);
    }

    // POST: GROUPS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? group_id)
    {
        var group = await _context.Groups.FindAsync(group_id);
        if (group != null)
        {
            _context.Groups.Remove(group);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GroupExists(int? group_id)
    {
        return _context.Groups.Any(e => e.group_id == group_id);
    }
}
