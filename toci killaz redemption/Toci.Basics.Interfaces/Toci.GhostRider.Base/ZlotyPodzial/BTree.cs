using Toci.Basics.Interfaces.DataStructures;

namespace Toci.GhostRider.Base.ZlotyPodzial
{
    public class BTree<T> : IBTree<T>
    {
        public T Self { get; set; }
        public virtual bool HasChild()
        {
            throw new System.NotImplementedException();
        }
    }
}