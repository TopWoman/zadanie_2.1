using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryCore.Data
{
    public enum OrderStatus
    {
        Accepted,  // принято
        Completed, // выполнен
        Canceled,  // отменено
        Assembling, //сборка
        Delivering  //доставляется
    }
}
