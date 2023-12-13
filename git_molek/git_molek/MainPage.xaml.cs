using git_molek.Models;
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
        public static Dictionary<MoodEnum, string> DayMoodIcons = new Dictionary<MoodEnum, string>()
        {
            { MoodEnum.zadowolony, "good.png"},
            { MoodEnum.dobry, "mid.png"},
            { MoodEnum.przeciętny, "meh.png"},
            { MoodEnum.słaby, "sad.png"},
            { MoodEnum.okropny, "bad.png"}
        };

        private static List<ImageButton> dayMoodImageButtons = new List<ImageButton>()
        {
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.zadowolony]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.dobry]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.przeciętny]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.słaby]
            },
            new ImageButton()
            {
                Source = DayMoodIcons[MoodEnum.okropny]
            },
        };

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

            for(int i=0; i < dayMoodImageButtons.Count; i++)
            {
                dayMoodImageButtons[i].Padding = 4;
                buttonsGrid.Children.Add(dayMoodImageButtons[i]);
                Grid.SetColumn(dayMoodImageButtons[i], i);
                dayMoodImageButtons[i].Clicked += AddDayMoodButtonClicked;
            }

            LastDayDateAndMood();
        }

        private async void AddDayMoodButtonClicked(object sender, EventArgs e)
        {
            if (selectedData.Date <= DateTime.Now.Date)
            {
                int column = Grid.GetColumn((ImageButton)sender);
                var mood = Enum.Parse(typeof(MoodEnum), column.ToString());
                var dayMood = new DayMood();
                dayMood.Date = selectedData.Date;
                dayMood.Mood = (MoodEnum)mood;

                await App.Database.InsertDayMoodAsync(dayMood);

                DisableButons(column);
                LastDayDateAndMood();
            }
            else
                await DisplayAlert("Błąd", "Nieprawidłowa data", "OK");
        }

        private void EnableButons()
        {
            foreach(var button in dayMoodImageButtons)
            {
                button.IsEnabled = true;
                button.BackgroundColor = Color.Transparent;
            }
        }

        private void DisableButons(int buttonId)
        {
            EnableButons();

            for (int i = 0; i < dayMoodImageButtons.Count; i++)
            {
                if (i == buttonId)
                    dayMoodImageButtons[i].BackgroundColor = Color.LightGray;

                dayMoodImageButtons[i].IsEnabled = false;
            }
        }

        private async void SelectedDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var dayMood = await App.Database.GetDayMood(selectedData.Date);

            if (dayMood != null)
            {
                var column = (int)dayMood.Mood;
                DisableButons(column);
            }
            else
            {
                EnableButons();
            }
        }

        private void GoToDailyMoodsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DailyMoods());
        }
    }
}
