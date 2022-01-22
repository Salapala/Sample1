 using Microsoft.EntityFramework;
using HospitalManagementApi.Models;

namespace HospitalManagementApi.Infrastructure
{
    public class HospitalManagementDbContext : DbContext
    {
        public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options)
        
        public DbSet<Mangement> Managements{get; set;}
    }
} 