using KidSounds.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KidSounds.Services
{
    public class SoundService
    {
        private readonly ISoundProvider mySoundProvider;
        public SoundService()
        {
            mySoundProvider = DependencyService.Get<ISoundProvider>();
        }

        public Task PlaySoundAsync(string filename)
        {
            return mySoundProvider.PlaySoundAsync(filename);
        }
    }
}
