public sealed class IdParameterBadRequestException : BadRequest
{
    public IdParameterBadRequestException() : base("Id parameter is null.") { }
}