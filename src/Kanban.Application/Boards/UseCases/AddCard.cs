using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class AddCard
    {
        /// <summary>
        /// Dependency Injection: 
        /// The AddCard use case depends on the IBoardRepository to access and modify board data.
        /// </summary>
        private readonly IBoardRepository _boardRepository;

        /// Constructor for AddCard, which takes an IBoardRepository as a parameter.
        public AddCard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        /// <summary>
        /// Handles the logic for adding a new card to a specific board.
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
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
