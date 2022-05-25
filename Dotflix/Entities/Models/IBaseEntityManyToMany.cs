namespace ApiDotflix.Entities.Models
{
    public interface IBaseEntityManyToMany<T> where T : BaseEntity
    {
        public int Id { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }
        public T SonEntity { get; set; }
    }
}
