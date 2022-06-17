namespace Demo1.Data.Interfaces
{
    public interface IDelete<T>
    {
        bool Delete(T id);
    }
}
