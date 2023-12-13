using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace git_molek
{
    public partial class MainPage : ContentPage
    {
        public async void LastDayDateAndMood()
        {
            var result = await App.Database.GetLastDayMood();

            if(result != null)
            {
                yourLastDayData.Text = result.Date.ToString();
                yourLastDayMood.Text = result.Mood.ToString();
            }
            else
            {
                yourLastDayData.Text = "Brak danych";
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        private void GoToDailyMoodsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DailyMoods());
        }
    }
}
