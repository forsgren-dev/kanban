using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class AddCard
    {
        private readonly IBoardRepository _boardRepository;

        public AddCard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public async Task<BoardDto?> Handle(
            Guid boardId,
            string title,
            string description,
            CancellationToken ct = default)
        {
            var board = await _boardRepository.GetById(boardId, ct);
            if (board is null)
                return null;

            board.AddCard(title, description);
            await _boardRepository.Save(board, ct);
            return BoardDto.From(board);
        }
    }
}
