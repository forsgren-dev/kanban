using Kanban.Application.Boards.Ports;
using Kanban.Domain.Boards;
using System.Collections.Concurrent;

namespace Kanban.Api.Persistence
{
    // Simple in-memory implementation of the IBoardRepository interface
    public sealed class InMemoryBoardRepository : IBoardRepository
    {
        private readonly ConcurrentDictionary<Guid, Board> _storage = new();

        /// <summary>
        /// Saves the given board to the in-memory storage. 
        /// Could later be extended to handle updates, concurrency issues and save to file/DB
        /// </summary>
        /// <param name="board"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task Save(Board board, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            _storage[board.Id] = board;
            return Task.CompletedTask;
        }

        // Returns a board by its ID from the in-memory storage or null if not found
        public Task<Board?> GetById(Guid boardId, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            _storage.TryGetValue(boardId, out var board);
            return Task.FromResult(board);
        }
    }
}
