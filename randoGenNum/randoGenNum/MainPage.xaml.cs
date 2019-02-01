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
            var num1 = firstNumEntry.Text;
            var num2 = secondNumEntry.Text;

            if(ProveInt(num1) == true)
            {
                ErrorLabelNum1.Text = "This is a valid integer";
            }
            else
            {
                ErrorLabelNum1.Text = "This is a invalid integer";
            }

            if (ProveInt(num2) == true)
            {
                ErrorLabelNum2.Text = "This is a valid integer";
            }
            else
            {
                ErrorLabelNum2.Text = "This is a invalid integer";
            }
        }

        private int[] GenerateNumbers(int num1, int num2)
        {
            int[] randNumArray = new int[num1];

            return randNumArray;
        }

        private bool ProveInt(String num)
        {
            int nVal = 0;

            if(int.TryParse(num, out nVal))
            {
                return true;
            }

            return false;
        }
    }
}
