using CoxToaster.Cox;
using System;

namespace CoxToaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Toaster toaster = new Toaster(2);
            
            ISlot slot1 = new ToastSlot();
            slot1.InsertBread(new Bread());


            ISlot slot2 = new ToastSlot();
            slot2.InsertBread(new Bread());

            toaster.InsertBread(slot1);
            toaster.InsertBread(slot2);
            
            
            toaster.StartToasting();
        }
    }
}
