public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees(Guid compnayId, bool trackChanges);
    Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
}