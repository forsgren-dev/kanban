namespace Kanban.Api.Contracts.Requests
{
    public sealed record MoveCardRequest(Guid TargetColumnId);
}
