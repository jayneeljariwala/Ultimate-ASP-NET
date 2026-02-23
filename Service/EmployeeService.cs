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

    public EmployeeDTO GetEmployee(Guid companyId, Guid id, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var employeeDb = _repositoryManager.Employee.GetEmployee(companyId, id, trackChanges);
        if (employeeDb is null)
        {
            throw new EmployeeNotFoundException(id);
        }
        var employee = _mapper.Map<EmployeeDTO>(employeeDb);
        return employee;
    }

    public EmployeeDTO CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }

        var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

        _repositoryManager.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
        _repositoryManager.Save();

        var employeeToReturn = _mapper.Map<EmployeeDTO>(employeeEntity);
        return employeeToReturn;
    }
}