using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace randoGenNum
{
    public class NumValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableOnTextChanged;

        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var num = e.NewTextValue;
            var intPattern = "^([+-]?[1-9]\\d*|0)$";

            var numEntry = sender as Entry;

            if (!(String.IsNullOrEmpty(num)) && !(String.IsNullOrWhiteSpace(num)) && Regex.IsMatch(num, intPattern)){
                numEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                numEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
