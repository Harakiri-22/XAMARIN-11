using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace App411
{
    public partial class MainPage : ContentPage

    {
        private int currentState;
        private double firstNumber;
        private double secondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btn_OpenSafePage_Clicked(object sender, EventArgs e)
        {
            if (Password.Text == "123")
            {
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PushAsync(new SafePage());
            }
            else
            {
                DisplayAlert("Ошибка", "Пароль неверен!", "Ок");
            }
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;


            this.Password.Text += pressed;

            double number;
            if (double.TryParse(this.Password.Text, out number))
            {
                this.Password.Text = number.ToString("");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }

            return;

        }

        void Clear(object sender, EventArgs e)
        {
            if (Password.Text.Length != 0)
            {
                Password.Text = Password.Text.Remove(Password.Text.Length - 1);
            }
            else
            {
                DisplayAlert("Ошибка", "Введите пароль", "Ок");
            }
        }
    }
}
