using Kanban.Domain.Boards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Application.Boards.Contracts
{
    public sealed record BoardDto(
        Guid Id,
        string Name,
        IReadOnlyList<ColumnDto> Columns,
        IReadOnlyList<CardDto> Cards)
    {
        public static BoardDto From(Board board)
        {
            return new BoardDto(
                board.Id,
                board.Name,
                board.Columns
                .OrderBy(c => c.Order)
                .Select(c => new ColumnDto(c.Id, c.Name, c.Order))
                .ToList(),
                board.Cards
                .Select(c => new CardDto(c.Id, c.Title, c.Description, c.ColumnId)).ToList()
                );
        }
    }
    

    public sealed record ColumnDto(
        Guid Id,
        string Name,
        int Order
        );

        public sealed record CardDto(
            Guid Id,
            string Title,
            string? Description,
            Guid ColumnId
        );
    
}
