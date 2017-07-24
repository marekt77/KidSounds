using System;
using Xamarin.Forms;
using KidSounds.Droid;
using KidSounds.Interfaces;
using System.Threading.Tasks;
using Android.Media;
using Android.Content.Res;

[assembly: Dependency(typeof(AndroidSoundProvider))]
namespace KidSounds.Droid
{
    public class AndroidSoundProvider: ISoundProvider 
    {
        public Task PlaySoundAsync(string filename)
        {
            //Create media player
            var player = new MediaPlayer();

            //Create task comeltion source to support async/await
            var tcs = new TaskCompletionSource<bool>();
            

            //Open the resource
            var fd = Xamarin.Forms.Forms.Context.Assets.OpenFd(filename);

            player.Prepared += (s, e) =>
            {
                player.Start();
            };

            player.Completion += (sender, e) =>
            {
                tcs.SetResult(true);
            };

            //Initialize
            player.SetDataSource(fd.FileDescriptor);
            player.Prepare();

            return tcs.Task;
        }
    }
}