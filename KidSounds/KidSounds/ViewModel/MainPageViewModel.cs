using KidSounds.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KidSounds.ViewModel
{
    public class MainPageViewModel
    {
        private List<Sound> mySounds;

        public List<Sound> Sounds
        {
            get
            {
                return mySounds;
            }
        }

        public ICommand SoundClick { get; set; }

        public MainPageViewModel()
        {
            string resourcePrefix = string.Empty;

            #if __IOS__
                resourcePrefix = "KidSounds.iOS.";
            #else
            #if __ANDROID__
                resourcePrefix = "KidSounds.Droid.";
            #else
		        resourcePrefix = "KidSounds.UWP.";
            #endif
            #endif

            SoundClick = new Command(SoundClickAction);

            var assembly = typeof(MainPageViewModel).GetTypeInfo().Assembly;

            Stream myStream = assembly.GetManifestResourceStream(resourcePrefix + "Data.SoundData.json");

            using (var reader = new StreamReader(myStream))
            {
                var json = reader.ReadToEnd();
                var rootObject = JsonConvert.DeserializeObject<RootObject>(json);

                mySounds = rootObject.Sounds;
            }

        }

        public void SoundClickAction()
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }
    }
}
