public interface ICompanyService
{
    IEnumerable<Company> GetAllCompanies(bool trackChanges);
}