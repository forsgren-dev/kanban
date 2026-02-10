using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class MoveCard
    {
        private readonly IBoardRepository _boardRepository;
        
        public MoveCard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<BoardDto?> Handle(
            Guid boardId, 
            Guid cardId, 
            Guid targetColumnId, 
            CancellationToken ct = default)
        {
            var board = await _boardRepository.GetById(boardId, ct);
            if (board is null) return null;

            board.MoveCard(cardId, targetColumnId);
            await _boardRepository.Save(board, ct);
            return BoardDto.From(board);
        }
    }
}
