using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR_MS
{
    public class MyList<T> : List<T>
    {

        public event EventHandler OnAdd;
        public event EventHandler OnRemove;

        public void Add(T item)
        {
            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }

        public void Remove(T item)
        {
            if (null != OnRemove)
            {
                OnRemove(this, null);
            }
            base.Remove(item);
        }


    }
}
