using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ExchangeApp.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        private void OnSelectNumber(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var pressed = button.Text;

            if (InputAmount.Text == "0") InputAmount.Text = "";

            InputAmount.Text += pressed;
        }

        private void OnClear(object sender, EventArgs e)
        {
            InputAmount.Text = "0";
        }

        private void OnDotPressed(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var pressed = button.Text;
            var contains = InputAmount.Text.Contains(".");
            if (contains == false) InputAmount.Text += pressed;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (InputAmount.Text != "0" && InputAmount.Text.Length > 1)
                InputAmount.Text = InputAmount.Text.Remove(InputAmount.Text.Length - 1);
            else
                InputAmount.Text = "0";
        }
    }
}