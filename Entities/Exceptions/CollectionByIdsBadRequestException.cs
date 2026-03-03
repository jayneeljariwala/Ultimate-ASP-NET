public sealed class CollectionByIdsBadRequestException : BadRequest
{
    public CollectionByIdsBadRequestException() : base("Collection count mismatch.") { }
}