using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Com;
using ClientApp.DataGen;

namespace ClientApp
{
    class Program
    {
        static int CargoCount = 1;
        static Client client = new Client();
        static void Main(string[] args)
        {
            DataGenerator dataGenerator = new DataGenerator(ShipCargo);
            while (true) ;
        }

        static private void ShipCargo(string msg)
        {
            client.Send(msg);
            Console.WriteLine("CargoNo "+CargoCount+": "+msg);
            CargoCount++;
        }

    }
}
