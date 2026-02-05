namespace Kanban.Api.Contracts.Requests
{
    public class AddCardRequest
    {
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int BoardId { get; set; }
    }
}
