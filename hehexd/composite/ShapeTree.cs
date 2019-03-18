using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.composite
{
    public class ShapeTree
    {
        private int hashcode;
        private string dept;
        private List<ShapeTree> Canvasshapes;

        //constructor
        public ShapeTree(int hashcode, string dept)
        {
            this.hashcode = hashcode;
            this.dept = dept;
            Canvasshapes = new List<ShapeTree>();
        }

        public void Add(int hashcode, string dept)
        {
            Canvasshapes.Add(new ShapeTree(hashcode, dept));
        }

        public int getHash(ShapeTree s)
        {
            int h = s.hashcode;
            return h;
        }

        public void Remove(int hashcode)
        {
            foreach (ShapeTree s in Canvasshapes)
            {
                int h = getHash(s);
                if(h == hashcode)
                {
                    Canvasshapes.Remove(s);
                }
            }
        }
    }
}
