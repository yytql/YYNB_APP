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
            //using (var httpClient = new HttpClient())
            //{
            //    using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://busuanzi.ibruce.info/busuanzi?jsonpCallback=BusuanziCallback_{Math.Floor(rand.NextDouble() * 1099511627776)}"))
            //    {
            //        request.Headers.TryAddWithoutValidation("Referer", "https://iamsmally.github.io/");
            //        request.Headers.TryAddWithoutValidation("User-Agent", RandomUseragent());
            //        request.Headers.TryAddWithoutValidation("DNT", "1");

            //        httpClient.SendAsync(request);
            //    }
            //}
            SendGet();
        }

        private async void SendGet()
        {
            try
            {
                string re;
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://busuanzi.ibruce.info/busuanzi?jsonpCallback=BusuanziCallback_{Math.Floor(rand.NextDouble() * 1099511627776)}"))
                    {
                        request.Headers.TryAddWithoutValidation("Referer", "https://iamsmally.github.io/");
                        request.Headers.TryAddWithoutValidation("User-Agent", RandomUseragent());
                        request.Headers.TryAddWithoutValidation("DNT", "1");

                         using (HttpResponseMessage response = httpClient.SendAsync(request).Result)
                         {
                             re = await response.Content.ReadAsStringAsync();
                         }
                    }
                }
                TextView textView = FindViewById<TextView>(Resource.Id.textView1);
                string rn = re.Split(',')[3].Split(':')[1].Split('}')[0];
                textView.Text = $"YY has {rn} views!";
            }
            catch (Exception)
            {
                // ignored
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

        private string RandomUseragent()
        {
            string[] usersagents = new string[]
            {
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/22.0.1207.1 Safari/537.1",
                "Mozilla/5.0 (X11; CrOS i686 2268.111.0) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.57 Safari/536.11",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6",
                "Mozilla/5.0 (Windows NT 6.2) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1090.0 Safari/536.6",
                "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/19.77.34.5 Safari/537.1",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.9 Safari/536.5",
                "Mozilla/5.0 (Windows NT 6.0) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.36 Safari/536.5",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3",
                "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3",
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_0) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.2) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1062.0 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1062.0 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.2) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1061.1 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1061.1 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1061.1 Safari/536.3",
                "Mozilla/5.0 (Windows NT 6.2) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1061.0 Safari/536.3",
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/535.24 (KHTML, like Gecko) Chrome/19.0.1055.1 Safari/535.24",
                "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/535.24 (KHTML, like Gecko) Chrome/19.0.1055.1 Safari/535.24"
            };
            var randomNumber = rand.Next(0, usersagents.Length);
            return usersagents[randomNumber];
        }
}
}

