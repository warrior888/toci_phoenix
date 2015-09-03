using System.Collections.Generic;

namespace IndexStructure.Btree
{
    // 21 344 135 236  34245
    // 2 1 3 4 4 1 3 5 2 3 6 ~= 40
    public class Leaf<T, TRecordAddress> : Dictionary<T, TRecordAddress>
    {
        public T Item;
        public TRecordAddress Address;
        public Leaf<T, TRecordAddress> Leafs;
    }
}