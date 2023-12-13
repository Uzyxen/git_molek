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
        }

        private void AddDayMoodButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
