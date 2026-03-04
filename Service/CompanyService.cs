using AutoMapper;
using Shared.DataTransferObjects;

internal sealed class CompanyService : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CompanyService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges)
    {
        var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
        var companiesDto = _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        return companiesDto;
    }

    public CompanyDTO GetCompany(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company is null)
        {
            throw new CompanyNotFoundException(companyId);
        }
        var companyDto = _mapper.Map<CompanyDTO>(company);
        return companyDto;
    }

    public CompanyDTO CreateCompany(CompanyForCreationDto company)
    {
        var companyEntity = _mapper.Map<Company>(company);
        _repositoryManager.Company.CreateCompany(companyEntity);
        _repositoryManager.Save();

        var companyToReturn = _mapper.Map<CompanyDTO>(companyEntity);
        return companyToReturn;
    }

    public IEnumerable<CompanyDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
    {
        if (ids is null)
        {
            throw new IdParameterBadRequestException();
        }

        var companyEntities = _repositoryManager.Company.GetByIds(ids, trackChanges);
        if (ids.Count() != companyEntities.Count())
        {
            throw new CollectionByIdsBadRequestException();
        }
        var companiesToReturn = _mapper.Map<IEnumerable<CompanyDTO>>(companyEntities);
        return companiesToReturn;
    }

    public (IEnumerable<CompanyDTO> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection)
    {
        if (companyCollection is null) throw new CompanyCollectionBadRequest();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
        foreach (var company in companyEntities)
        {
            _repositoryManager.Company.CreateCompany(company);
        }
        _repositoryManager.Save();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyDTO>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
        return (companies: companyCollectionToReturn, ids: ids);
    }
}