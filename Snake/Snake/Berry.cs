using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Berry
    {
        static int width = 20, height = 20;
        public int x, y;
        public Berry()
        {
            ChangeCoordinate();
        }
        public void ChangeCoordinate()
        {
            Thread.Sleep(1);
            Random rand = new Random(DateTime.Now.Millisecond);
            this.x = rand.Next(2, width - 2);
            this.y = rand.Next(2, height - 2);
        }
    }
}
