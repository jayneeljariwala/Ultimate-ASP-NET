using Shared.DataTransferObjects;

public interface IEmployeeService
{
    IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges);
    EmployeeDTO GetEmployee(Guid companyId, Guid id, bool trackChanges);
    EmployeeDTO CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges);
    void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
    void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdateDto, bool companyTrackChanges, bool employeeTrackChanges);
    (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges, bool empTtrackChanges);
    void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
}