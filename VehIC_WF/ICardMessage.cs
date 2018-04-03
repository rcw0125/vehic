using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehIC_WF.Device;

namespace VehIC_WF
{
    interface ICardMessage
    {
         void HandleCardMessage(CardReader device, string cardId);
    }
}
