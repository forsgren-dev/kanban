using Kanban.Domain.Boards;
namespace Kanban.Application.Boards.Ports
{
    internal interface IBoardRepository
    {
        Task Save(Board board, CancellationToken ct);
        Task<Board?> GetById(Guid boardId, CancellationToken ct);
    }
}
