public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees(Guid compnayId, bool trackChanges);
}