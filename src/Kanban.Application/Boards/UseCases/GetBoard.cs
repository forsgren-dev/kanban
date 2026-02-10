using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;

namespace Kanban.Application.Boards.UseCases
{
    public sealed class GetBoard
    {
        // Dependency Injection
        private readonly IBoardRepository _boardRepository;

        // Constructor for GetBoard, which takes an IBoardRepository as a parameter.
        public GetBoard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        /// <summary>
        /// Handles the retrieval of a board by its ID. 
        /// It fetches the board from the repository and converts it to a BoardDto for presentation. 
        /// </summary>
        /// <param name="boardId"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<BoardDto?> Handle(Guid boardId, CancellationToken ct = default)
        {
            var board = await _boardRepository.GetById(boardId, ct);
            return board is null ? null : BoardDto.From(board);
        }
    }
}
