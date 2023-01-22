using Aptus.Models;
using Aptus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aptus.ViewModels
{
    public class IntroScreenViewModel2 : BaseViewModel2
    {
        private string _buttonText = "NEXT";
        public string ButtonText
        {
            get => _buttonText;
            set => SetProperty(ref _buttonText, value);
        }

        private int _position;
        public int Position
        {
            get => _position;
            set => SetProperty(ref _position, value, onChanged: (() =>
            {
                if (value == IntroScreens.Count - 1)
                {
                    ButtonText = "CHOOSE";
                }
                else
                {
                    ButtonText = "CHOOSE";
                }
            }));
        }

        public ObservableCollection<IntroScreenModels> IntroScreens { get; set; } = new ObservableCollection<IntroScreenModels>();

        public IntroScreenViewModel2()
        {
            IntroScreens.Add(new IntroScreenModels
            {
                //IntroTitle = "Welcome To StudentApp",
                //IntroDescription = "Enjoy the captivating process of online education in a place and at a time of your choice",
                IntroImage = "femaleglutes"
            });

            IntroScreens.Add(new IntroScreenModels
            {
                //IntroTitle = "Anytime, Anywhere",
                //IntroDescription = "Now you can check homework anytime right from mobile",
                IntroImage = "femalehamstrings"
            });

            IntroScreens.Add(new IntroScreenModels
            {
                //    IntroTitle = "Ready to Find A Course",
                //    IntroDescription = "Join our online school that will help you learn the cutting-edge skills to scale new heights in your creative career.",
                IntroImage = "femalequads"
            });

            IntroScreens.Add(new IntroScreenModels
            {
                //IntroTitle = "Nesto Random",
                //IntroDescription = "Join our online school that will help you learn the cutting-edge skills to scale new heights in your creative career.",
                IntroImage = "femaleback"
            });
            IntroScreens.Add(new IntroScreenModels
            {
                //IntroTitle = "Nesto Random",
                //IntroDescription = "Join our online school that will help you learn the cutting-edge skills to scale new heights in your creative career.",
                IntroImage = "femalearms"
            });
        }

        public ICommand NextCommand => new Command(async () =>
        {
            if (Position >= IntroScreens.Count - 1)
            {
                await AppShell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                Position += 1;
            }
        });
    }
}
