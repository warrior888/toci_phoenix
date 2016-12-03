using System.Collections.Generic;

namespace Toci.Basics.Interfaces.DesignPatterns.ChainOfResponsibility
{
    public interface IHandlersManager<T, TKey>
    {
        Dictionary<TKey, IHandler<string>> HandlersMap { get; set; }
    }
}