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



namespace randoGenNum.ViewModels
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {

        private string _randNum1;
        private string _randNum2;
        private string _numRolls;

        private List<int> _randNumList;
        private string _stringNumList;
        private string _errorMessage;

        private string _EntryColor1;
        private string _EntryColor2;
        private string _EntryColor3;

        /* Input: Name: value       , type: string
        * Output: Name: _randNum1, type: string
        * Function: An attribute which handles  _randNum1
        *  - get - Returns the value of  _randNum1
        *  - set - Assigns value to  _randNum1
        *        - Changed the value of BGColor1 to Transparent
        *        - Changed the value of ErrorMessage to ""
        *        - Calls OnPropertyChanged() to notify there 
        *        has been a change for _randNum1. The background
        *        of the Entry element call Num1Entrybox will 
        *        become transparent, and the text in a label
         *       named "ErrorMessageLabel" will become blank
        */
        public string RandNum1
        {

            get { return _randNum1; }
            set
            {
                BGColor1 = "Transparent";
                ErrorMessage = "";
                _randNum1 = value;
                OnPropertyChanged();
            }
        }

        /* Input: Name: value       , type: string
        * Output: Name: _EntryColor1, type: string
        * Function: An attribute which handles  _EntryColor1
        *  - get - Returns the value of  _EntryColor1
        *  - set - Assigns value to  _EntryColor1
        *        - Calls OnPropertyChanged() to notify there 
        *        has been a change for  _EntryColor1 and 
        *        this function will update the background
        *        color on a Entry element named "Num1EntryBox"
        *        which is binded to this attribute.
        */
        public string BGColor1
        {
            get { return _EntryColor1; }
            set
            {
                _EntryColor1 = value;
                OnPropertyChanged();
            }
        }

        /* Input: Name: value       , type: string
        * Output: Name: _randNum2, type: string
        * Function: An attribute which handles  _randNum2
        *  - get - Returns the value of  _randNum2
        *  - set - Assigns value to  _randNum2
        *        - Changed the value of BGColor2 to Transparent
        *        - Changed the value of ErrorMessage to ""
        *        - Calls OnPropertyChanged() to notify there 
        *        has been a change for _randNum2. The background
        *        of the Entry element call Num2Entrybox will 
        *        become transparent, and the text in a label
         *       named "ErrorMessageLabel" will become blank
        */
        public string RandNum2
        {

            get { return _randNum2; }
            set
            {
                BGColor2 = "Transparent";
                ErrorMessage = "";
                _randNum2 = value;
                OnPropertyChanged();
            }
        }

        /* Input: Name: value       , type: string
        * Output: Name: _EntryColor2, type: string
        * Function: An attribute which handles  _EntryColor2
        *  - get - Returns the value of  _EntryColor2
        *  - set - Assigns value to  _EntryColor2
        *        - Calls OnPropertyChanged() to notify there 
        *        has been a change for  _EntryColor2 and 
        *        this function will update the background
        *        color on a Entry element named "Num2EntryBox"
        *        which is binded to this attribute.
        */
        public string BGColor2
        {
            get { return _EntryColor2; }
            set
            {
                _EntryColor2 = value;
                OnPropertyChanged();
            }

        }





        public string NumRolls
        {
            get { return _numRolls; }
            set
            {
                BGColor3 = "Transparent";
                ErrorMessage = "";
                _numRolls = value;
                OnPropertyChanged();
            }

        }

        public string BGColor3
        {
            get { return _EntryColor3; }
            set
            {
                _EntryColor3 = value;
                OnPropertyChanged();
            }

        }

        /* Input:  Name: value       , type: List<int>
         * Output: Name: _randNumList, type: List<int>
         * Function: An attribute which handles _randNumList
         *  - get - Returns the value of _randNumList
         *  - set - Assigns value to _randNumList 
         *        - Calls OnPropertyChanged() to notify 
         *        there has been a change for _randNumList 
         *        and this function will update the element 
         *        binded to this attribute.
         */



        public List<int> RandNumList
        {
            get { return _randNumList; }
            set
            {
                _randNumList = value;
                OnPropertyChanged();
            }
        }

        /* Input:  Name: value         , type: string
         * Output: Name: _stringNumList, type: string
         * Function: An attribute which handles _stringNumList
         *  - get - Returns the value of _stringNumList
         *  - set - Assigns value to _stringNumList 
         *        - Calls OnPropertyChanged() to notify there 
         *        has been a change for _stringNumList and 
         *        this function will update a label named 
         *        "ErrorMessageLabel" which is binded to 
         *        this attribute.
         */
        public string StringNumList
        {
            get { return _stringNumList; }
            set
            {
                _stringNumList = value;
                OnPropertyChanged();
            }
        }

        /* Input:  Name: value        , type: string
         * Output: Name: _errorMessage, type: string
         * Function: An attribute which handles _errorMessage
         *  - get - Returns the value of _errorMessage
         *  - set - Assigns value to _errorMessage
         *        - Calls OnPropertyChanged() to notify there 
         *        has been a change for _errorMessage and 
         *        this function will update a label named 
         *        "ErrorMessageLabel" which is binded to 
         *        this attribute.
         */
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        
        /* Input: N/A
        * Output: Name: StringNumList, type: string
        *         Name: RandNumList  , type: List<int>
        *         
        * Function: This ICommand is triggered when a click event happens
        * with a button called GenerateNumList. ICommand.execute will run and
        * do the following:
        *    -Checks if the values of _randNum1 and _randNum2 are valid string "integers"
        *       -If valid, it'll then try to convert them into integers
        *         -If the first number is bigger than the 2nd number, flipped
        *         them around.
        *         -Generate a list of random integers of a size between 100 to 500 entries.
        *         -Convert that list into a string so it can be displayed.
        *       -If the inputs cannot be converted, an error message will pop up and both
        *        Entry elements Num1EntryBox and Num2EntryBox backgrounds would become red.
        *    -The same happens if _randNum1 and _randNum2 are not valid string "integers"
        */
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
                        int tempNumRoll = 0;

                        if (Int32.TryParse(_randNum1, out tempNum1) && Int32.TryParse(_randNum2, out tempNum2) && Int32.TryParse(_numRolls, out tempNumRoll))
                        {
                            if (tempNum1 > tempNum2)
                            {
                                int tempNum = tempNum1;
                                tempNum1 = tempNum2;
                                tempNum2 = tempNum;
                            }

                            if (tempNumRoll < 1)
                            {
                                DisplayErrors();
                            }

                            Random r = new Random();
                            //int arraySize = r.Next(100, 500);

                            var randNumArray = new List<int>();

                            for (int i = 0; i < tempNumRoll; i++)
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
                            DisplayErrors();
                        }

                        

                    }
                    else
                    {
                        DisplayErrors();
                    }
                });
            }
        }



        /* Input: N/A
        * Output: Name: BGColor1     , type: string
        *         Name: BGColor2     , type: string
        *         Name: ErrorMessage , type: string
        *         Name: StringNumList, type: string
        *         
        * Function: Changes the attributes to handle error checking.
        * It changes the Entry element called Num1EntryBox to a red
        * or transparent background depending on the users input. The
        * same things goes for the Entry element called Num2EntryBox.
        * ErrorMessages has now a new message and StringNumList is blank.
        */
        private void DisplayErrors()
        {
            int tempPosNum = 0;

            if (!(GetValidation(_randNum1)))
            {
                BGColor1 = "Red";
            }
            else
            {
                BGColor1 = "Transparent";
            }

            if (!(GetValidation(_randNum2)))
            {
                BGColor2 = "Red";
            }
            else
            {
                BGColor2 = "Transparent";
            }

            
            if (Int32.TryParse(_numRolls, out tempPosNum))
            {
                if (tempPosNum < 1)
                {
                    BGColor3 = "Red";
                }
                else
                {
                    BGColor3 = "Transparent";
                }


            }
            else
            {
                BGColor3 = "Transparent";
            }

            ErrorMessage = "Invalid value(s). Please type in integers.";
            StringNumList = "";
        }

        /* Input: Name: string, type: string
        * Output: Name: N/A   , type: bool
        * Function: Gets a string and if the string passes of it is not Null, empty, containing whitespace, or 
        * pattern matches the regex for a valid integer, it returns true. Otherwise, it returns false.
        */
        private bool GetValidation(string strNum)
        {
            var intPattern = "^([+-]?[1-9]\\d*|0)$";

            if (!(String.IsNullOrEmpty(strNum)) && !(String.IsNullOrWhiteSpace(strNum)) && Regex.IsMatch(strNum, intPattern))
            {
                return true;
            }
            
            return false;          
        }

        /* Input: N/A
        * Output: N/A
        * Function: Handles and updates the binding bewtween binding target (Elements in MainPAge.xaml) and binding source (Attributes)
        * such that it enables the binding target properties to automatically reflect the dynamic changes of the binding source.
        * (Quote from https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/how-to-implement-property-change-notification)
        */
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
