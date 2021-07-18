namespace SN.Model.Abstract
{
    public interface IModel<TKey>
    {
        public TKey Id { get; set; }
    }
}