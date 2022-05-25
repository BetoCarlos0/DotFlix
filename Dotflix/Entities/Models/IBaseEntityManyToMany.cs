namespace ApiDotflix.Entities.Models
{
    public interface IBaseEntityManyToMany
    {
        public int Id { get; set; }
        public int AboutId { get; set; }

        public About About { get; set; }
        public BaseEntity SonEntity { get; set; }
    }
}
