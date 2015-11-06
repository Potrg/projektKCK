using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public struct Koordynaty
    {
            public int row { get; set; }
            public int col { get; set; }

            public Koordynaty(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
    }
}
