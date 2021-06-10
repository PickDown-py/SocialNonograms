namespace SN.Entity
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}