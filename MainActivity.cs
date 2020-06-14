using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AndroidAerolinea
{
    [Activity(Label = "Aerolinea", MainLauncher = true, Theme = "@style/MiThemaPrincipal")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Button myButton = FindViewById<Button>(Resource.Id.btnBuscarVuelos);
            myButton.Click += (object sender, System.EventArgs e) =>
            {
                Intent _intent = new Intent(this,typeof(BuscarVueloActivity));
                StartActivity(_intent);
            };
        }
    }
}

