using Microsoft.EntityFrameworkCore;


namespace JWTRefreshToken.Auth
{
    public class EmployeeRepository : IEmployees
    {
        readonly ApplicationDbContext _dbContext = new();

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CheckEmployee(int id)
        {
            try
            {
                return _dbContext.Employees.Any(e => e.EmployeeID == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee? employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return employee;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       public List<Employee> GetEmployeeDetails()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetEmployeeDetails(int id)
        {
            try
            {
                Employee employee = _dbContext.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else { throw new ArgumentNullException(); }
            }
            catch (Exception)
            {

                throw;
            }

        }

       public void UpdateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Entry(employee).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
