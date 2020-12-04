using System;
using System.Collections.Generic;
using System.Text;

namespace CoxToaster.Cox
{
    public interface IToaster
    {
        bool InsertBread(ISlot islot);
        bool StartToasting();
        bool SetPower(int level);
        void Cancel();
    }
}
