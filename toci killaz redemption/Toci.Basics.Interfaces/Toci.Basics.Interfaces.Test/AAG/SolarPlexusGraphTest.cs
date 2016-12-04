using System.Collections.Generic;
using Toci.Basics.Interfaces.DataStructures;
using Toci.Basics.Interfaces.DesignPatterns.Factory;
using Toci.Basics.Interfaces.DesignPatterns.Strategy;
using Toci.Telepathy.Interfaces.SolarPlexus;

namespace Toci.Basics.Interfaces.Test.AAG
{
    public class SolarPlexusGraphTest
    {
        public void Test()
        {
            ISolarPlexusGraph<ITociStrategyLogic<IBTree<IGraph<Dictionary<string, string>>>>> TheMysteriousBehviourTest 
                = new SolarPlexusBase<ITociStrategyLogic<IBTree<IGraph<Dictionary<string, string>>>>>();

            //TheMysteriousBehviourTest.
        }
    }
}