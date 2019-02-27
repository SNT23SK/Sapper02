using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper.View
{
   public class Cell:Button
    {
        public Cell(int i, int j) : base()
        {
            I = i;
            J = j;
        }
        public int I { get; private set; }
        public int J { get; private set; }
    }
}
