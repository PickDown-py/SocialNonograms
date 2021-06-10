namespace SN.Dto.Abstract
{
    public interface IDto<TKey>
    {
        public TKey Id { get; set; }
    }
}