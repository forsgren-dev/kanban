using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class GetBoard
    {
        private readonly IBoardRepository _boardRepository;

        public GetBoard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<BoardDto?> Handle(Guid boardId, CancellationToken ct = default)
        {
            var board = await _boardRepository.GetById(boardId, ct);
            return board is null ? null : BoardDto.From(board);
        }
    }
}
