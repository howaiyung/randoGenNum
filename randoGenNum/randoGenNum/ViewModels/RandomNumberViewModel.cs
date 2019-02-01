using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace randoGenNum.ViewModels
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {
        public int RandNum1 { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
