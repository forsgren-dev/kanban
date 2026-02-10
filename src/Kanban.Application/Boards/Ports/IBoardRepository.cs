using Kanban.Domain.Boards;
namespace Kanban.Application.Boards.Ports
{
    /// <summary>
    /// Interface for board repository operations.
    /// </summary>
    public interface IBoardRepository
    {
        // Saves the given board to the repository
        Task Save(Board board, CancellationToken ct);

        // Retrieves a board by its ID from the repository
        Task<Board?> GetById(Guid boardId, CancellationToken ct);
    }
}
