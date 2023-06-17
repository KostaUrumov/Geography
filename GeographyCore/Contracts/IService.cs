namespace GeographyCore.Contracts
{
    public interface IService<T>
    {
        Task Add(T value);
        public List<T> ListAll();
    }
}
