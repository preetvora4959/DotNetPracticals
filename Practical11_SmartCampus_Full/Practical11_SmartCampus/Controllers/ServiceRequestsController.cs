using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Data;
using Practical11_SmartCampus.Models;

namespace Practical11_SmartCampus.Controllers;

public class ServiceRequestsController(CampusDbContext context) : Controller
{
    public async Task<IActionResult> Index(string? status, string? search)
    {
        var requests = context.ServiceRequests.AsQueryable();
        if (!string.IsNullOrWhiteSpace(status)) requests = requests.Where(x => x.Status == status);
        if (!string.IsNullOrWhiteSpace(search)) requests = requests.Where(x => x.StudentName.Contains(search) || x.Issue.Contains(search) || x.Department.Contains(search));
        ViewBag.Status = status;
        ViewBag.Search = search;
        return View(await requests.OrderByDescending(x => x.CreatedAt).ToListAsync());
    }

    public IActionResult Create() => View(new ServiceRequest());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ServiceRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        request.CreatedAt = DateTime.Now;
        context.ServiceRequests.Add(request);
        await context.SaveChangesAsync();
        TempData["Success"] = "Service request submitted successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        return request == null ? NotFound() : View(request);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        return request == null ? NotFound() : View(request);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ServiceRequest request)
    {
        if (id != request.Id) return BadRequest();
        if (!ModelState.IsValid) return View(request);
        context.Update(request);
        await context.SaveChangesAsync();
        TempData["Success"] = "Service request updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        return request == null ? NotFound() : View(request);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request != null)
        {
            context.ServiceRequests.Remove(request);
            await context.SaveChangesAsync();
            TempData["Success"] = "Service request deleted successfully.";
        }
        return RedirectToAction(nameof(Index));
    }
}
