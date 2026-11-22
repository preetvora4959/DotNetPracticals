using Microsoft.EntityFrameworkCore;
using Practical11_SmartCampus.Models;

namespace Practical11_SmartCampus.Data;

public class CampusDbContext(DbContextOptions<CampusDbContext> options) : DbContext(options)
{
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
    public DbSet<CampusEvent> CampusEvents => Set<CampusEvent>();
}
