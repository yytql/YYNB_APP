using System;
using System.Net.Http;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace YYNB
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageButton imageButton;
        private Random rand;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            rand = new Random();
            imageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageButton.LongClick += ImageButton_LongClick;
            imageButton.Click += ImageButton_Click;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            imageButton.Background = new ColorDrawable(new Color(rand.Next(255), rand.Next(255), rand.Next(255)));
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://busuanzi.ibruce.info/busuanzi?jsonpCallback=BusuanziCallback_854782526265"))
                {
                    request.Headers.TryAddWithoutValidation("Referer", "https://iamsmally.github.io/");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("DNT", "1");

                    httpClient.SendAsync(request);
                }
            }
        }

        private void ImageButton_LongClick(object sender, View.LongClickEventArgs e)
        {
            string uri = "https://iamsmally.github.io/";
            Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

