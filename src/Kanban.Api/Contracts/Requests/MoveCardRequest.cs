namespace Kanban.Api.Contracts.Requests
{
    public class MoveCardRequest
    {
        public int CardId { get; set; }
        public int TargetBoardId { get; set; }
        public int TargetPosition { get; set; }
    }
}
