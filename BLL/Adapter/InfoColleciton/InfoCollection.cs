using System.Collections;
using System.Collections.Generic;
using BLL.Adapter.Models;
using BLL.Iterator;

namespace BLL.Adapter.VillageCollection
{
    public class InfoCollection : IteratorAggregate
    {
        readonly List<IInfo> _collection = new List<IInfo>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<IInfo> getItems()
        {
            return _collection;
        }

        public void AddItem(IInfo item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new InfoIterator(this, _direction);
        }
    }
}
