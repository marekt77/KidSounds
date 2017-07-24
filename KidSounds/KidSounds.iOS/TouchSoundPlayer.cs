using System;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using Xamarin.Forms;
using KidSounds.iOS;
using System.IO;
using KidSounds.Interfaces;

[assembly: Dependency(typeof(TouchSoundPlayer))]
namespace KidSounds.iOS
{
    public class TouchSoundPlayer: NSObject, ISoundProvider
    {
        private AVAudioPlayer myPlayer;

        public Task PlaySoundAsync(string filename)
        {
            var tcs = new TaskCompletionSource<bool>();

            string path = NSBundle.MainBundle.PathForResource(Path.GetFileNameWithoutExtension(filename),
                Path.GetExtension(filename));

            var url = NSUrl.FromString(path);

            myPlayer = AVAudioPlayer.FromUrl(url);

            myPlayer.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
            {
                myPlayer = null;
                tcs.SetResult(true);
            };

            myPlayer.Play();

            return tcs.Task;
        }
    }
}