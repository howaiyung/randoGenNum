using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace randoGenNum
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnGenerateButtonClicked(object sender, EventArgs e)
        {

            randomNumList.Text = "";
            ErrorLabel.Text = "";

            var num1 = firstNumEntry.Text;
            var num2 = secondNumEntry.Text;

            
            if (int.TryParse(num1, out int nVal1) && int.TryParse(num2, out int nVal2))
            {
                if(nVal1 < nVal2)
                {
                    var randNumArray = GenerateNumbers(nVal1, nVal2);
                    randomNumList.Text = String.Join(",", new List<int>(randNumArray).ConvertAll(i => i.ToString()).ToArray());
                }
                else
                {
                    ErrorLabel.Text = "The first number is larger then the second number, please type the first number smaller than the 2nd number or type the 2nd number bigger than the first number.";
                }
                
            }

            /*
            
            Commenting this section out since it seems the input calculator forces the user to enter a integer number
            if(ProveInt(num1) == true)
            {
                ErrorLabelNum1.Text = "The first number is a valid integer";
            }
            else
            {
                ErrorLabelNum1.Text = "The first number is a invalid integer";
            }

            if (ProveInt(num2) == true)
            {
                ErrorLabelNum2.Text = "The second number is a valid integer";
            }
            else
            {
                ErrorLabelNum2.Text = "The second number is a invalid integer";
            }*/
        }

        /* private void GenerateNumbers(int num1, int num2, ref Object A) -- Is this more secure?*/
        private List<int> GenerateNumbers(int num1, int num2)
        {
            Random r = new Random();
            int arraySize = r.Next(1, 1000);

            var randNumArray = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                int temp = r.Next(num1, num2);
                randNumArray.Add(temp);
                temp = 0;
            }

            return randNumArray;
        }

        private bool ProveInt(String num)
        {

            if (int.TryParse(num, out int nVal))
            {
                return true;
            }

            return false;
        }
    }
}
