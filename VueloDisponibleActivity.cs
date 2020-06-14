using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.Widget;

namespace AndroidAerolinea
{
    [Activity(Label = "VueloDisponibleActivity", Theme = "@style/MiThemaPrincipalConBar")]
    public class VueloDisponibleActivity : Activity
    {
        private List<Vuelo> miVuelo;
        private RecyclerView rv;
        private MyAdapter _adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VueloDisponible);
            miVuelo = JsonConvert.DeserializeObject<List<Vuelo>>(Intent.GetStringExtra("Vuelo"));
            rv = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            rv.SetLayoutManager(new LinearLayoutManager(this));
            _adapter = new MyAdapter(miVuelo);
            rv.SetAdapter(_adapter);
        }
    }
}