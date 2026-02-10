namespace Kanban.Domain.Boards
{
    public sealed class Card
    {
        public Guid Id { get; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public Guid ColumnId { get; private set; }


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

        public void MoveTo(Guid columnId) => ColumnId = columnId;


    }
}
