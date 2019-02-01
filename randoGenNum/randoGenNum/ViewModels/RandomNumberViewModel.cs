using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace randoGenNum.ViewModels
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _randNum1;
        private int _randNum2;
        private List<int> _randNumList;

        public int RandNum1
        {

            get { return _randNum1; }
            set
            {
                _randNum1 = value;
                OnPropertyChange();
            }
        }

        public int RandNum2
        {

            get { return _randNum2; }
            set
            {
                _randNum2 = value;
                OnPropertyChange();
            }
        }

        public List<int> RandNumList
        {
            get { return _randNumList; }
            set
            {
                _randNumList = value;
                OnPropertyChange();
            }
        }

        public ICommand CreateNumListCommand
        {
            get
            {
                return new Command(() =>
                {

                    Random r = new Random();
                    int arraySize = r.Next(1, 1000);

                    var randNumArray = new List<int>();

                    for (int i = 0; i < arraySize; i++)
                    {
                        int temp = r.Next(_randNum1, _randNum2);
                        randNumArray.Add(temp);
                        temp = 0;
                    }

                    RandNumList = randNumArray;

                });
            }
        }


        private void OnPropertyChange()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
