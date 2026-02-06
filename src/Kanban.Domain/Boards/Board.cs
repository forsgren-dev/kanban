using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kanban.Domain.Boards
{
    public sealed class Board
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        private List<Column> _columns = new();
        public IReadOnlyList<Column> Columns => _columns.AsReadOnly();

        private List<Card> _cards = new();
        public IReadOnlyList<Card> Cards => _cards.AsReadOnly();

        private Board()
        { }

        public static Board Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Board name cannot be null or empty.", nameof(name));

            var board = new Board
            {
                Id = Guid.NewGuid(),
                Name = name.Trim()

            };
            
            board._columns.Add(new Column(Guid.NewGuid(), "Todo", 1));
            board._columns.Add(new Column(Guid.NewGuid(), "Doing", 2));
            board._columns.Add(new Column(Guid.NewGuid(), "Done", 3));

            return board;
        }


        /// <summary>
        /// Add a new card to the board. 
        /// The card's ColumnId must match an existing column on the board.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddCard(string title, string? description)
        {
            var todoColumn = _columns.FirstOrDefault(c => c.Name == "Todo");
            if (todoColumn == null)
                throw new InvalidOperationException("Todo column missing.");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));

            var card = new Card(Guid.NewGuid(), title.Trim(), description, todoColumn.Id);
            _cards.Add(card);
        }

        /// <summary>
        /// Move card on the board.
        /// Validates that the card and target column exist, 
        /// then updates the card's ColumnId to move it to the new column.
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="targetColumnId"></param>
        /// <exception cref="ArgumentException"></exception>
        public void MoveCard(Guid cardId, Guid targetColumnId)
        {
            
            var card = _cards.Find(c => c.Id == cardId);
            if (card == null)
                throw new ArgumentException("Card not found.", nameof(cardId));
            var targetColumn = _columns.Find(c => c.Id == targetColumnId);
            if (targetColumn == null)
                throw new ArgumentException("Target column not found.", nameof(targetColumnId));
            card.MoveTo(targetColumnId);
            
        }


    }
}
