using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetApp.ViewModel
{
    public class BaseVm : INotifyPropertyChanged
    {
        public BaseVm()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

