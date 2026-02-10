namespace Kanban.Api.Contracts.Requests
{
    public sealed record AddCardRequest(string Title, string? Description);
}
