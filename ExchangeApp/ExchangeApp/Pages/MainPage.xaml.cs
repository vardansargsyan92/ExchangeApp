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
            var button = (Button) sender;
            var pressed = button.Text;

            if (resultText.Text == "0") resultText.Text = "";

            resultText.Text += pressed;
        }

        private void OnClear(object sender, EventArgs e)
        {
            resultText.Text = "0";
        }

        private void OnDotPressed(object sender, EventArgs e)
        {
            var button = (Button) sender;
            var pressed = button.Text;
            var contains = resultText.Text.Contains(".");
            if (contains == false) resultText.Text += pressed;
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (resultText.Text != "0" && resultText.Text.Length > 1)
                resultText.Text = resultText.Text.Remove(resultText.Text.Length - 1);
            else
                resultText.Text = "0";
        }
    }
}