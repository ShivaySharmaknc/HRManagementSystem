using Microsoft.EntityFrameworkCore;
using HRManagementSystem.Models;

namespace HRManagementSystem.Data
{
    public class HRManagementDbContext : DbContext
    {
        public HRManagementDbContext(DbContextOptions<HRManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            // Add other relationship configurations
        }
    }

    // Repository interfaces and implementations
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HRManagementDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(HRManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Implement repository methods
    }
}
