using KidSounds.Model;
using KidSounds.Services;
using KidSounds.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidSounds.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageView : ContentPage
	{
		public MainPageView ()
		{
			InitializeComponent ();

            BindingContext = new MainPageViewModel();
        }

        private async void GridView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var mySoundService = new SoundService();

            await mySoundService.PlaySoundAsync(((Sound)e.Item).SoundFile);

            await DisplayAlert("Alert", "Sound Should Play...", "OK");
        }
    }
}