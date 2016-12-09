using Toci.Telepathy.Interfaces.SolarPlexus;

namespace Toci.GhostRider.Base.ZlotyPodzial
{
    public class SolarPlexusBase<T> : ISolarPlexusGraph<T>   //ISolarPlexusGraph
    {
        public T Self { get; set; }
        public virtual bool HasChild()
        {
            //throw new System.NotImplementedException();
            return true;
        }
    }
}