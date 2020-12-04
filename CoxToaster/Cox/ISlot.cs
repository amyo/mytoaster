using System;
using System.Collections.Generic;
using System.Text;

namespace CoxToaster.Cox
{
    public interface ISlot
    {
        void InsertBread(IToastable toastable);
        void EjectBread();
        bool StartToasting();
        bool IsOn();
    }
}
