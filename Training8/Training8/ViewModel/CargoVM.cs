using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training8.ViewModel
{
    public class CargoVM : ViewModelBase
    {
        private string shipID;
        ObservableCollection<PayloadItemVM> items;
        int totalWeight = 0;

        public CargoVM()
        {
        }

        public CargoVM(string shipID)
        {
            this.ShipID = shipID;
            Items = new ObservableCollection<PayloadItemVM>();
        }

        public string ShipID { get => shipID; set => shipID = value; }
        public ObservableCollection<PayloadItemVM> Items
        {
            get => items;
            set
            {
                items = value;
                RaisePropertyChanged();
            }
        }

        public int TotalWeight
        {
            get
            {
                if (items != null)
                {
                    foreach(var item in items)
                    {
                        totalWeight += item.WeightSum;
                    }
                }
                return totalWeight;
            }
            set
            {
                totalWeight = value;
                RaisePropertyChanged();
            }
        }
    }
}
