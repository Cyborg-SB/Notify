namespace NotifyApi.Contracts.Models
{
    public interface IMovieContract
    {
        public Guid Id { get; }
        public string Title { get;}
        public string Description { get; }
        public DateTime ReleaseDate { get; }
    }
}
