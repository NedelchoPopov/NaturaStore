using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Data.Common.Enums
{
    public enum OrderStatus
    {
        Pending,       // Очаква обработка
        Shipped,       // Изпратена
        Delivered,     // Доставена
        Cancelled      // Отменена
    }
}
