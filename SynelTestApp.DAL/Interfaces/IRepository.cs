namespace SynelTestApp.DAL.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
