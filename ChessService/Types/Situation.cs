using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessService.Types
{
    public enum Situation
    { 
        Checkmate = 0,
        Draw = 1,
        Pat = 2,
        OutOfTime = 3
    }
}
