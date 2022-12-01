namespace SynelTestApp.BLL.Data;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    { }
    public DbSet<Employee> Employees { get; set; }
}
