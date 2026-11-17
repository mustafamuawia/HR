using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace HR_MS
{
   public class MyCotainers
    {
       public string ContainerName { get; set; }
       public List<Size> ChildSize = new List<Size>();
       public List<Point> ChildLocation = new List<Point>();
    }
}
