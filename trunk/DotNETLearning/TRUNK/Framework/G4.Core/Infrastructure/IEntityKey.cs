namespace G4.Core.Infrastructure
{
    public interface IEntityKey<TKey>
    {
        TKey Id { get; }
    }
}