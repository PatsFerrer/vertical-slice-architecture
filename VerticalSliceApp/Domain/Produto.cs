namespace VerticalSliceApp.Domain
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public string? Nome { get; private set; }
        public decimal Preco { get; private set; } = decimal.Zero;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        public Produto(string nome, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}
