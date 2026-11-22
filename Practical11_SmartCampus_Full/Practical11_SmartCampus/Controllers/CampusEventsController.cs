using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Data;
using Practical11_SmartCampus.Models;

namespace Practical11_SmartCampus.Controllers;

public class CampusEventsController(CampusDbContext context) : Controller
{
    public async Task<IActionResult> Index() => View(await context.CampusEvents.OrderBy(x => x.EventDate).ToListAsync());

    public IActionResult Create() => View(new CampusEvent());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CampusEvent campusEvent)
    {
        if (!ModelState.IsValid) return View(campusEvent);
        context.CampusEvents.Add(campusEvent);
        await context.SaveChangesAsync();
        TempData["Success"] = "Campus event added successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var campusEvent = await context.CampusEvents.FindAsync(id);
        return campusEvent == null ? NotFound() : View(campusEvent);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CampusEvent campusEvent)
    {
        if (id != campusEvent.Id) return BadRequest();
        if (!ModelState.IsValid) return View(campusEvent);
        context.Update(campusEvent);
        await context.SaveChangesAsync();
        TempData["Success"] = "Campus event updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var campusEvent = await context.CampusEvents.FindAsync(id);
        if (campusEvent != null)
        {
            context.CampusEvents.Remove(campusEvent);
            await context.SaveChangesAsync();
            TempData["Success"] = "Campus event deleted successfully.";
        }
        return RedirectToAction(nameof(Index));
    }
}
