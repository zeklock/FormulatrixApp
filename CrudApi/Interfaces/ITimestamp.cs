namespace CrudApi.Interfaces
{
    public interface ITimestamp
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
