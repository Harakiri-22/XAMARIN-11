using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App411
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        public ModalPage()
        {
            InitializeComponent();
        }

        private void dateBirth_DateSelected(object sender, DateChangedEventArgs e)
        {
            dateBirth.MaximumDate = DateTime.Now;
            int ageCount = DateTime.Now.Year - dateBirth.Date.Year;
            if (DateTime.Now.Month < dateBirth.Date.Month ||
                DateTime.Now.Month == dateBirth.Date.Month &&
                DateTime.Now.Day < dateBirth.Date.Day)
            {
                ageCount--;
            }
            age.Text = "Возраст " + ageCount.ToString();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.Properties["name"] = firstName.Text;

                App.Current.Properties["lastname"] = lastName.Text;

                App.Current.Properties["patronymic"] = Patronymic.Text;

                App.Current.Properties["gender"] = GenderPicker.SelectedItem.ToString();

                App.Current.Properties["age"] = dateBirth.Date;

                App.Current.Properties["needhostel"] = needHostel.SelectedItem.ToString();

                App.Current.Properties["isheadman"] = IsHeadman.SelectedItem.ToString();

                App.Current.Properties["progress"] = progress.SelectedItem.ToString();
            }
            catch (Exception)
            {
                DisplayAlert("Ошибка", "Заполните все поля", "Ок");
            }
            App.Current.SavePropertiesAsync();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            try
            {
                object value;
                if (App.Current.Properties.TryGetValue("name", out value))
                {
                    firstName.Text = (string)value;
                }
                if (App.Current.Properties.TryGetValue("lastname", out value))
                {
                    lastName.Text = (string)value;
                }
                if (App.Current.Properties.TryGetValue("patronymic", out value))
                {
                    Patronymic.Text = (string)value;
                }
                if (App.Current.Properties.TryGetValue("gender", out value))
                {
                    GenderPicker.SelectedItem = (string)value;
                }
                if (App.Current.Properties.TryGetValue("age", out value))
                {
                    dateBirth.Date = (DateTime)value;
                }
                if (App.Current.Properties.TryGetValue("needhostel", out value))
                {
                    needHostel.SelectedItem = (string)value;
                }
                if (App.Current.Properties.TryGetValue("isheadman", out value))
                {
                    IsHeadman.SelectedItem = (string)value;
                }
                if (App.Current.Properties.TryGetValue("progress", out value))
                {
                    progress.SelectedItem = (string)value;
                }
                if (App.Current.Properties.TryGetValue("photo1", out value))
                {
                    Image1.Source = (string)value;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Ошибка", ex.ToString(), "Ок");
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.SavePropertiesAsync();
        }

        async private void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
    public class EntryValidation2 : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            {
                int text;
                if (!Int32.TryParse(sender.Text, out text) == false)
                    sender.BackgroundColor = Color.Red;
                else
                    sender.BackgroundColor = Color.Default;
            }
        }
    }
}