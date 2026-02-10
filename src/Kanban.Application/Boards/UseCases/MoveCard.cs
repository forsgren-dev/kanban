using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class MoveCard
    {

        // Dependency injection of the board repository to access and modify board data
        private readonly IBoardRepository _boardRepository;

        // Constructor for MoveCard, which takes an IBoardRepository as a parameter
        public MoveCard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        /// <summary>
        /// Handles the logic for moving a card from one column to another on the Kanban board.
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="cardId"></param>
        /// <param name="targetColumnId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
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
