using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovidos_Library.EntityLayer
{
    public enum BookStockStatus
    {
        Reserved=0,Available=1
    }
    public enum BookTransactionStatus
    {
        Reserved=0,Returned=1, Delayed=2
    }
}
