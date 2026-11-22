
using Practical11_SmartCampus.Models;

namespace Practical11_SmartCampus.Data;

public static class CampusSeedData
{
    public static void Initialize(CampusDbContext db)
    {
        if (!db.ServiceRequests.Any())
        {
            db.ServiceRequests.Add(
                new ServiceRequest
                {
                    StudentName = "Preet Vora",
                    Department = "Computer Engineering",
                    Issue = "Wi-Fi Connectivity",
                    Description = "Unable to connect to the campus Wi-Fi in the library.",
                    Status = "Pending"
                }
            );
        }

        if (!db.CampusEvents.Any())
        {
            db.CampusEvents.AddRange(
                new CampusEvent { EventName = "Tech Innovation Day", Venue = "Main Auditorium", EventDate = DateTime.Today.AddDays(7), Description = "Student project showcase and technology demonstrations." },
                new CampusEvent { EventName = "Campus Sports Meet", Venue = "University Sports Ground", EventDate = DateTime.Today.AddDays(14), Description = "Inter-department sports activities and competitions." }
            );
        }

        db.SaveChanges();
    }
}
