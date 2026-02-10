using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;
using Kanban.Domain.Boards;

namespace Kanban.Application.Boards.UseCases
{
    public class CreateBoard
    {
        private readonly IBoardRepository _boardRepository;

        public CreateBoard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<BoardDto> Handle(string name, CancellationToken ct = default)
        {
            var board = Board.Create(name);
            await _boardRepository.Save(board, ct);
            return BoardDto.From(board);
        }
    }
}
