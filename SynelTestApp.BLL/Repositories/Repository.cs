﻿
namespace SynelTestApp.BLL.Repositories
{
    public class Repository : IRepository
    {
        private readonly EmployeeDbContext _context;

        public Repository(EmployeeDbContext context)
        {
            _context = context;
        }

        // Get Employees
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        //Get by id
        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees?
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        //Add new employee record
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        // Update employee
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result != null)
            {
                result.PayrollNumber = employee.PayrollNumber;
                result.Forenames = employee.Forenames;
                result.Surname = employee.Surname;
                result.DateOfBirth = employee.DateOfBirth;
                result.Telephone = employee.Telephone;
                result.Mobile = employee.Mobile;
                result.Address = employee.Address;
                result.SecondAddress = employee.SecondAddress;
                result.Postcode = employee.Postcode;
                result.EmailHome = employee.EmailHome;
                result.StartDate = employee.StartDate;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        // Delete employee
        public async Task DeleteEmployeeAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}