using System.Collections;
using System.Collections.Generic;
using BLL.Factory.Model;

namespace BLL.Iterator
{
    public class AffairsCollection : IteratorAggregate
    {
        readonly List<IAffair> _collection = new List<IAffair>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<IAffair> getItems()
        {
            return _collection;
        }

        public void AddItem(IAffair item)
        {
            this._collection.Add(item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AffairIterator(this, _direction);
        }
    }
}
