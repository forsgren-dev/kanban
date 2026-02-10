namespace Kanban.Api.Contracts.Requests
{
    public class MoveCardRequest
    {
        public Guid CardId { get; set; }
        public Guid TargetBoardId { get; set; }
        public Guid TargetColumnId { get; set; }
    }
}
