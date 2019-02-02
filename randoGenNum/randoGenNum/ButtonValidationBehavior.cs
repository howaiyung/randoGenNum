using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace randoGenNum
{
    public class ButtonValidationBehavior : Behavior <Button>
    {
        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Clicked += BindableOnClick;

        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.Clicked -= BindableOnClick;

        }

        private void BindableOnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

       
    }
}
