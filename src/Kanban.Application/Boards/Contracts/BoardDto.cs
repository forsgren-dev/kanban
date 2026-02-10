using Kanban.Domain.Boards;

namespace Kanban.Application.Boards.Contracts
{
    /// <summary>
    /// BoardDto represents the structure of the Kanban board for presentation.
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="Name"></param>
    /// <param name="Columns"></param>
    /// <param name="Cards"></param>
    public sealed record BoardDto(
        Guid Id,
        string Name,
        IReadOnlyList<ColumnDto> Columns,
        IReadOnlyList<CardDto> Cards
        )
    {
        /// Converts a Board domain model to a BoardDto for presentation.
        public static BoardDto From(Board board)
        {
            return new BoardDto(
                board.Id,
                board.Name,
                board.Columns
                .OrderBy(c => c.Order)
                .Select(c => new ColumnDto(c.Id, c.Name, c.Order)).ToList(),
                board.Cards
                .Select(c => new CardDto(c.Id, c.Title, c.Description, c.ColumnId)).ToList()
                );
        }
    }
    // ColumnDto represents the structure of a column on the Kanban board.
    public sealed record ColumnDto(
        Guid Id,
        string Name,
        int Order
        );

    // CardDto represents the structure of a card on the Kanban board.
    public sealed record CardDto(
        Guid Id,
        string Title,
        string? Description,
        Guid ColumnId
    );

}
