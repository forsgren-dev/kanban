using System.Collections.Concurrent;
using Kanban.Application.Boards.Ports;
using Kanban.Domain.Boards;

namespace Kanban.Api.Persistence
{
    public sealed class InMemoryBoardRepository : IBoardRepository
    {
        private readonly ConcurrentDictionary<Guid, Board> _store = new();

        public Task Save(Board board, CancellationToken ct)
        {
            _store[board.Id] = board;
            return Task.CompletedTask;
        }

        public Task<Board?> GetById(Guid boardId, CancellationToken ct)
        {
            _store.TryGetValue(boardId, out var board);
            return Task.FromResult(board);
        }
    }
}
