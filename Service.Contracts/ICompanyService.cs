using Shared.DataTransferObjects;

public interface ICompanyService
{
    IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges);
    CompanyDTO GetCompany(Guid companyId, bool trackChanges);
    CompanyDTO CreateCompany(CompanyForCreationDto company);
    IEnumerable<CompanyDTO> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
    (IEnumerable<CompanyDTO> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);
    void DeleteCompany(Guid companyId, bool trackChanges);
    void UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
}