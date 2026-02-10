using Kanban.Application.Boards.Contracts;
using Kanban.Application.Boards.Ports;
using Kanban.Domain.Boards;

namespace Kanban.Application.Boards.UseCases
{
    public class CreateBoard
    {
        // Could be in a Service layer, but I am putting it here for simplicity
        private readonly IBoardRepository _boardRepository;

        // Constructor for CreateBoard, which takes an IBoardRepository as a parameter.
        public CreateBoard(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        /// <summary>
        /// Handles the creation of a new board. 
        /// It creates a new Board entity, saves it to the repository, 
        /// and returns a BoardDto representing the newly created board.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<BoardDto> Handle(string name, CancellationToken ct = default)
        {
            var board = Board.Create(name);
            await _boardRepository.Save(board, ct);
            return BoardDto.From(board);
        }
    }
}
