using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(this, Resource.Layout.ListItem, 
                Resource.Id.textView1, Resource.Id.textView2, Resource.Id.imageView1);

            Validate();
        }

        private async void Validate()
        {
            var ServiceClient = new SALLab12.ServiceClient();
            string Email = "";
            string Password = "";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, 
                Android.Provider.Settings.Secure.AndroidId);

            var Result = await ServiceClient.ValidateAsync(Email, Password, myDevice);
            string ResultMessage = $"{Result.Status}\n{Result.FullName}\n{Result.Token}";

            var ResultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
            ResultTextView.Text = ResultMessage;
        }
    }
}

