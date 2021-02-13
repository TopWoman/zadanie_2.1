using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    enum OrderStatus
    {
        Accepted,  // принято
        Completed, // выполнен
        Canceled,  // отменено
        Assemblys, //сборка
        Delivering  //доставляется
    }
}
