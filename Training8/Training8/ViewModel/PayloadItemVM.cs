using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training8.ViewModel
{
    public class PayloadItemVM:ViewModelBase
    {
        string name;
        int amount;
        int weightSum;

        public PayloadItemVM()
        {
        }

        public PayloadItemVM(string name, int amount, int weightSum)
        {
            this.Name = name;
            this.Amount = amount;
            this.WeightSum = weightSum;
        }

        public string Name { get => name; set => name = value; }
        public int Amount { get => amount; set => amount = value; }
        public int WeightSum { get => weightSum; set => weightSum = value; }
    }
}
