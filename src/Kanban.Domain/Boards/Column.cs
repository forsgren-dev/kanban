namespace Kanban.Domain.Boards
{
    public sealed class Column
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Order { get; }


        public Column(Guid id, string name, int order)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty.", nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            if (order < 1)
                throw new ArgumentException("Order must be a positive integer.", nameof(order));

            Id = id;
            Name = name;
            Order = order;
        }
    }
}
