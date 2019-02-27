using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper.Model
{
   public class CellStatus
    {
        enum cell_status
        {
            Empty,
            Number,
            Bomb,
            Flag,
            Refuse
        }
    }
}
