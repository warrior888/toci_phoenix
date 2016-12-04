namespace Toci.Basics.Interfaces
{
    public interface IUniverse<T>
    {
        T Self { get; set; }

        bool HasChild();
    }
}