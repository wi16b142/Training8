using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Training8.Com;
using System.Data;
using ClientApp.DataGen;

namespace Training8.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        Server server;
        PayloadItemVM selectedPayloadItem;
        ObservableCollection<CargoVM> cargos;
        CargoVM selectedCargo;
        DataGenerator dataGenerator;

        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                dataGenerator = new DataGenerator(GenerateDemoData);
            }
            else
            {
                server = new Server(UpdateGui);
            }

            Cargos = new ObservableCollection<CargoVM>();
            SelectedCargo = new CargoVM();
            SelectedPayloadItem = new PayloadItemVM();
        }

        private void GenerateDemoData(string demo)
        {
            UpdateGui("demo1@" + demo);
        }

        private void UpdateGui(string newMsg)
        {
            App.Current.Dispatcher.Invoke(()=> 
            {
                string shipID = newMsg.Split('@')[0];
                string[] raw = newMsg.Split('@')[1].Split('|');

                Cargos.Add(new CargoVM(shipID));

                foreach(var item in raw)
                {
                    string name = item.Split(',')[0];
                    int amount = int.Parse(item.Split(',')[1]);
                    int weight = int.Parse(item.Split(',')[2]);

                    Cargos[Cargos.Count-1].Items.Add(new PayloadItemVM(name, amount, weight));
                }

            });
        }


        public PayloadItemVM SelectedPayloadItem
        {
            get
            {
                return selectedPayloadItem;
            }

            set
            {
                selectedPayloadItem = value;
                RaisePropertyChanged();
            }
        }
        public CargoVM SelectedCargo
        {
            get
            {
                return selectedCargo;
            }

            set
            {
                selectedCargo = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<CargoVM> Cargos
        {
            get
            {
                return cargos;
            }

            set
            {
                cargos = value;
                RaisePropertyChanged();
            }
        }
    }
}