namespace MomentsFor.Domain.Entities
{
    public interface IEntityBase<T>
    {
        public T Id { get; set; }
    }
}
