using System.Collections.Generic;

namespace IndexStructure.Btree
{
    public abstract class BTree<T, TRecordAddress>
    {
        protected Leaf<T, TRecordAddress> Leafs;

        protected BTree()
        {
            Leafs = new Leaf<T, TRecordAddress>();
        }

        // 2 1 3 4 4 1 3 5 2 3 6 
        public void AddElement(T indexed, TRecordAddress address)
        {
            List<T> indexedValues = SplitIndexItems(indexed);

            var localLeaf = Leafs;

            foreach (var item in indexedValues)
            {
                if (localLeaf.Leafs.ContainsKey(item))
                {
                    //localLeaf = localLeaf.Leafs.Leafs.Leafs;
                }
            }
        }

        protected abstract List<T> SplitIndexItems(T indexed);
    }
}