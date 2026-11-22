using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Data;
using Practical11_SmartCampus.Models;

namespace Practical11_SmartCampus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampusApiController(CampusDbContext context) : ControllerBase
{
    [HttpGet("requests")]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetRequests() => await context.ServiceRequests.OrderByDescending(x => x.CreatedAt).ToListAsync();

    [HttpGet("requests/{id:int}")]
    public async Task<ActionResult<ServiceRequest>> GetRequest(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        return request == null ? NotFound() : Ok(request);
    }

    [HttpPost("requests")]
    public async Task<ActionResult<ServiceRequest>> AddRequest(ServiceRequest request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        request.Id = 0;
        request.CreatedAt = DateTime.Now;
        context.ServiceRequests.Add(request);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRequest), new { id = request.Id }, request);
    }

    [HttpPut("requests/{id:int}")]
    public async Task<IActionResult> UpdateRequest(int id, ServiceRequest request)
    {
        if (id != request.Id) return BadRequest();
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        if (!await context.ServiceRequests.AnyAsync(x => x.Id == id)) return NotFound();
        context.Entry(request).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("requests/{id:int}")]
    public async Task<IActionResult> DeleteRequest(int id)
    {
        var request = await context.ServiceRequests.FindAsync(id);
        if (request == null) return NotFound();
        context.ServiceRequests.Remove(request);
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("events")]
    public async Task<ActionResult<IEnumerable<CampusEvent>>> GetEvents() => await context.CampusEvents.OrderBy(x => x.EventDate).ToListAsync();
}
