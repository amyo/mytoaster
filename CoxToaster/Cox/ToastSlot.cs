using System;
using System.Collections.Generic;
using System.Text;

namespace CoxToaster.Cox
{
    public class ToastSlot : ISlot
    {
        private IToastable toastable;
        private bool isOn;
        private int slotId;
        public void EjectBread()
        {
            isOn = false;
            System.Console.WriteLine($"Bread ejected from slot.");
        }

        public void InsertBread(IToastable toastable)
        {
            this.toastable = toastable;
            System.Console.WriteLine($"Bread inseted into slot.");
        }

        public bool IsOn()
        {
            return isOn;
        }

        public bool StartToasting()
        {
            if (!IsOn())
            {
                this.isOn = true;
                this.toastable.Toast();
                System.Console.WriteLine($"Toasting started for slot.");
                return true;
            }
            else {
                System.Console.WriteLine($"Toasting already in-progress.");
                return false;
            }
        }
    }
}
