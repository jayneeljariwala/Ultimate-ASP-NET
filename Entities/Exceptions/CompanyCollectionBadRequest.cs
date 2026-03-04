public sealed class CompanyCollectionBadRequest : BadRequest
{
    public CompanyCollectionBadRequest() : base("Company collection sent from a client is null.") { }
}