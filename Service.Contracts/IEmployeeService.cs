using Shared.DataTransferObjects;

public interface IEmployeeService
{
    IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges);
}