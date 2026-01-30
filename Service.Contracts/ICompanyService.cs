using Shared.DataTransferObjects;

public interface ICompanyService
{
    IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges);
}