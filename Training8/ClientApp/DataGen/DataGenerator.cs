using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp.DataGen
{
    public class DataGenerator
    {
        string[] cargos = new string[] {
            "Recorder,20000,25000|DVDPlayer,10000,20000|PCs,50000,200000",
            "RCCar,100000,10000|BluRayDisks,300000,20000|Joysticks,20000,3000",
            "Lego,500000,55000|Playmobil,663332,22133|Sonos,2212311,22245",
            "GameBoy,112311,231311|PlayStation4,2221311,22311|XBoxOne,12123113,543432" };

        static Random rnd = new Random();
        Action<string> generated;
        Thread generatingThread;

        public DataGenerator(Action<string> generated)
        {
            this.generated = generated;
            StartGenerating();
        }

        private void StartGenerating()
        {
            generatingThread = new Thread(Generate);
            generatingThread.IsBackground = true;
            generatingThread.Start();
        }

        private void Generate()
        {
            while (generatingThread.IsAlive)
            {
                generated(cargos[rnd.Next(0,3)]);
                Thread.Sleep(5000);
            }
        }
    }
}
