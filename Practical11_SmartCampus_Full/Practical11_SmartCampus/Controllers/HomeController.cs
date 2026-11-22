using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Data;

namespace Practical11_SmartCampus.Controllers;

public class HomeController(CampusDbContext context) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.TotalRequests = await context.ServiceRequests.CountAsync();
        ViewBag.PendingRequests = await context.ServiceRequests.CountAsync(x => x.Status == "Pending");
        ViewBag.InProgressRequests = await context.ServiceRequests.CountAsync(x => x.Status == "In Progress");
        ViewBag.ResolvedRequests = await context.ServiceRequests.CountAsync(x => x.Status == "Resolved");
        ViewBag.TotalEvents = await context.CampusEvents.CountAsync();
        ViewBag.RecentRequests = await context.ServiceRequests.OrderByDescending(x => x.CreatedAt).Take(5).ToListAsync();
        ViewBag.UpcomingEvents = await context.CampusEvents.OrderBy(x => x.EventDate).Take(3).ToListAsync();
        return View();
    }

    public IActionResult Error() => View();
}
