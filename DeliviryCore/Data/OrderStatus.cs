using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    enum OrderStatus
    {
        Accepted,  // принято
        Performed, // выполнено
        Completed, // завершено
        Canceled   // отменено
    }
}
