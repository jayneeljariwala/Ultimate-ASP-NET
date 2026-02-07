using AutoMapper;
using Shared.DataTransferObjects;

internal sealed class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var employeeFromDb = _repositoryManager.Employee.GetEmployees(companyId, trackChanges);
        var employeeDto = _mapper.Map<IEnumerable<EmployeeDTO>>(employeeFromDb);
        return employeeDto;
    }
}