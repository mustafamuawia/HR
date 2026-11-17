using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HR_MS
{
    public class MyList<T> : List<T>
    {

        public event EventHandler OnAdd;

        public void Add(T item)
        {
            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }

    }
}
