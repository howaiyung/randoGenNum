using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel.DataAnnotations;



namespace randoGenNum.ViewModels
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {

        

        private string _randNum1;
        private string _randNum2;
        private List<int> _randNumList;
        private string _stringNumList;
        private string _errorMessage;

        private string _Entry1Color;
        private string _Entry2Color;

        private static RandomNumberViewModel _instance;
        public static RandomNumberViewModel Instance
        {
            get { return _instance ?? (_instance = new RandomNumberViewModel()); }
        }

        public string RandNum1
        {

            get { return _randNum1; }
            set
            {
                _randNum1 = value;
                OnPropertyChanged();
            }
        }

        public string RandNum2
        {

            get { return _randNum2; }
            set
            {
                if (GetValidation(value))
                {
                    _Entry2Color = "Transparent";
                }
                else
                {
                    _Entry2Color = "Red";
                }

                _randNum2 = value;
                OnPropertyChanged();
                //OnPropertyChanged(BGColor2);
            }
        }

        public string BGColor2
        {
            get { return _Entry2Color;  }
            set
            {
                OnPropertyChanged();
                OnPropertyChanged(RandNum2);
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

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand CreateNumListCommand
        {
            get
            {
                return new Command(() =>
                {

                    

                    if (GetValidation(_randNum1) && GetValidation(_randNum2))
                    {
                        int tempNum1 = 0;
                        int tempNum2 = 0;

                        if ((Int32.TryParse(_randNum1, out tempNum1)) && Int32.TryParse(_randNum2, out tempNum2))
                        {
                            Random r = new Random();
                            int arraySize = r.Next(1, 10);

                            var randNumArray = new List<int>();

                            for (int i = 0; i < arraySize; i++)
                            {
                                int temp = r.Next(tempNum1, tempNum2);
                                randNumArray.Add(temp);
                                temp = 0;
                            }

                            RandNumList = randNumArray;
                            StringNumList = string.Join(",", new List<int>(_randNumList).ConvertAll(i => i.ToString()).ToArray());
                        }
                        else
                        {
                            if (!(GetValidation(_randNum2)))
                            {
                                _Entry2Color = "Red";
                            }
                        }
                        

                    }

                });
            }
        }

        private bool GetValidation(string strNum)
        {
            var intPattern = "^([+-]?[1-9]\\d*|0)$";

            if (!(String.IsNullOrEmpty(strNum)) && !(String.IsNullOrWhiteSpace(strNum)) && Regex.IsMatch(strNum, intPattern))
            {
                return true;
            }
            
            return false;          
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
