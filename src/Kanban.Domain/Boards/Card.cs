namespace Kanban.Domain.Boards
{
    public sealed class Card
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public Guid ColumnId { get; private set; }

        /// <summary>
        /// Card represents a task or item on the Kanban board. It belongs to a specific column.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="columnId"></param>
        /// <exception cref="ArgumentException"></exception>
        public Card(Guid id, string title, string? description, Guid columnId)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty.", nameof(id));
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.", nameof(title));
            if (columnId == Guid.Empty)
                throw new ArgumentException("ColumnId cannot be empty.", nameof(columnId));

            Id = id;
            Title = title.Trim();
            Description = description?.Trim();
            ColumnId = columnId;

        }
        /// <summary>
        /// Move the card to a different column by updating its ColumnId. 
        /// The new ColumnId must correspond to an existing column on the board.
        /// </summary>
        /// <param name="columnId"></param>
        public void MoveTo(Guid columnId) => ColumnId = columnId;


    }
}
