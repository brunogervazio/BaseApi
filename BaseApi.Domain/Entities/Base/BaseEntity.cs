namespace BaseApi.Domain.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid Uuid { get; private set; }

        protected BaseEntity() => Uuid = Guid.NewGuid();

        protected BaseEntity(Guid uuid) => Uuid = uuid;
    }
}
