using Kanban.Domain.Boards;
namespace Kanban.Application.Boards.Ports
{
    public interface IBoardRepository
    {
        Task Save(Board board, CancellationToken ct);
        Task<Board?> GetById(Guid boardId, CancellationToken ct);
    }
}
