using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CoxToaster.Cox
{
    public class Toaster : IToaster
    {
        private List<ISlot> slots;
        private int powerLevel = 3;
        private int maxSlot = 2;
        private System.Timers.Timer timer;
        public Toaster(int maxSlot)
        {
            this.slots = new List<ISlot>();
            this.maxSlot = maxSlot;
        }
        public void Cancel()
        {
            foreach (var slot in slots)
            {
                slot.EjectBread();
            }
        }

        public bool InsertBread(ISlot islot)
        {
            if (this.slots.Count < maxSlot)
            {
                this.slots.Add(islot);
                System.Console.WriteLine("Bread Inserted");
                return true;
            }
            else
            {
                System.Console.WriteLine("Max slot reached.");
                return false;
            }
        }

        public bool SetPower(int level)
        {
            this.powerLevel = level;
            System.Console.WriteLine($"Power level set to {level}");
            return true;
        }

        public bool StartToasting()
        {
            foreach (var slot in slots)
            {
                slot.StartToasting();
            }
            System.Console.WriteLine($"Toasting started.");
            timer = new System.Timers.Timer(GetInterval());
            timer.Elapsed += async (sender, e) => await HandleTimer();
            timer.Start();
            Console.WriteLine("Press any key to exit... ");
            Console.ReadKey();

            return true;
        }

        private Task HandleTimer()
        {
            foreach (var slot in slots)
            {
                slot.EjectBread();
            }
            System.Console.WriteLine($"Toasting finished.");
            timer.Stop();
            return Task.CompletedTask;
        }

        private int GetInterval()
        {

            return 100 * powerLevel;
        }
    }
}
