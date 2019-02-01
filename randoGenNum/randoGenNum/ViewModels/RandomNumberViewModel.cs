using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace randoGenNum.ViewModels
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {
        

        private int _randNum1;
        private int _randNum2;
        private List<int> _randNumList;
        private string _stringNumList;

        public int RandNum1
        {

            get { return _randNum1; }
            set
            {
                _randNum1 = value;
                OnPropertyChanged();
            }
        }

        public int RandNum2
        {

            get { return _randNum2; }
            set
            {
                _randNum2 = value;
                OnPropertyChanged();
            }
        }

        public List<int> RandNumList
        {
            get { return _randNumList; }
            set
            {
                _randNumList = value;
                OnPropertyChanged();
            }
        }

        public string StringNumList
        {
            get { return _stringNumList; }
            set
            {
                _stringNumList = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNumListCommand
        {
            get
            {
                return new Command(() =>
                {

                    Random r = new Random();
                    int arraySize = r.Next(1, 10);

                    var randNumArray = new List<int>();

                    for (int i = 0; i < arraySize; i++)
                    {
                        int temp = r.Next(_randNum1, _randNum2);
                        randNumArray.Add(temp);
                        temp = 0;
                    }

                    RandNumList = randNumArray;
                    StringNumList = string.Join(",", new List<int>(_randNumList).ConvertAll(i => i.ToString()).ToArray());

                });
            }
        }

        /*
        
        I was trying to convert the string version into a command so it can be called from MainPage.xaml
        But there is no trigger with the button so I could create this a function to be called upon by CreateNumList
        public ICommand CreateStringListCommand
        {
            get
            {
                return new Command(() =>
                {
                    StringNumList = string.Join(",", new List<int>(_randNumList).ConvertAll(i => i.ToString()).ToArray());
                });
            }
        }*/

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
