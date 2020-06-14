using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Views.View;
using Newtonsoft.Json;

namespace AndroidAerolinea
{
    [Activity(Label = "Buscar Vuelo ", Theme = "@style/MiThemaPrincipalConBar")]
    public class BuscarVueloActivity : Activity
    {
        Mensajero _dataSet;
        EditText _irDesde;
        EditText _viajarA;
        TextView _fechaInicio;
        TextView _fechaFin;
        Button buttonBuscar;
        Spinner spinnerCabina;
        List<string> cabina;
        ArrayAdapter<string> cabinaAdapter;
        DateTime fechaDeVuelo;
        DateTime FechaDeVueloRetorno;
        List<Vuelo> vuelos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BuscarVuelo);

            fechaDeVuelo = DateTime.Today;
            FechaDeVueloRetorno = DateTime.Today;
            buttonBuscar = FindViewById<Button>(Resource.Id.btnBuscar);
            _irDesde = FindViewById<EditText>(Resource.Id.etIrDesde);
            _viajarA = FindViewById<EditText>(Resource.Id.etViajarA);
            _fechaInicio = FindViewById<TextView>(Resource.Id.etFechaInicio);
            _fechaInicio.Text = DateTime.Today.ToString("ddd, MMM d");
            _fechaFin = FindViewById<TextView>(Resource.Id.etFechaFin);
            _fechaFin.Text = DateTime.Today.AddDays(1).ToString("ddd, MMM d");
            spinnerCabina = FindViewById<Spinner>(Resource.Id.spinner1);
            _irDesde.Click += _irDesde_Click;
            _irDesde.FocusChange += _irDesde_FocusChange;
            _viajarA.Click += _viajarA_Click;
            _viajarA.FocusChange += _viajarA_FocusChange;
            _fechaInicio.Click += _fechaInicio_Click;
            _fechaFin.Click += _fechaFin_Click;
            buttonBuscar.Click += ButtonBuscar_Click;

            cabina = new List<string> { "Primera Clase", "Clase Ejecutiva", "Clase Económica" };
            cabinaAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, cabina);
            spinnerCabina.Adapter = cabinaAdapter;

        }

        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            //Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            //AlertDialog alert = dialog.Create();
            //alert.SetTitle("Error");
            //alert.SetMessage("Algo salió mal");
            //alert.SetIcon(Resource.Drawable.alert);
            //alert.SetButton("OK", (c, ev) =>
            //{
            //    // Ok button click task  
            //});
            //alert.SetButton2("CANCEL", (c, ev) => { });
            //alert.Show();

            _dataSet = new Mensajero();



            if (_irDesde.Text.Length > 0 && _viajarA.Text.Length > 0)
            {

                if (_dataSet.vuelosDisponibles(fechaDeVuelo, FechaDeVueloRetorno, _irDesde.Text.Substring(_irDesde.Length() - 4, 3), _viajarA.Text.Substring(_viajarA.Length() - 4, 3)) != null)
                {
                    vuelos = _dataSet.vuelosDisponibles(fechaDeVuelo, FechaDeVueloRetorno, _irDesde.Text.Substring(_irDesde.Length() - 4, 3), _viajarA.Text.Substring(_viajarA.Length() - 4, 3));

                    if (vuelos.Count < 1)
                    {
                        Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                        AlertDialog alert = dialog.Create();
                        alert.SetTitle("Disculpe la molestia");
                        alert.SetMessage("No hay vuelos disponibles");
                        alert.SetButton("OK", (c, ev) =>
                        {
                            // Ok button click task  
                        });
                        alert.Show();
                        return;
                    }

                    Intent _intent = new Intent(this, typeof(VueloDisponibleActivity));
                    _intent.PutExtra("Vuelo", JsonConvert.SerializeObject(vuelos));
                    StartActivity(_intent);
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                    AlertDialog alert = dialog.Create();
                    alert.SetTitle("Error");
                    alert.SetMessage("Algo salió mal");
                    alert.SetButton("OK", (c, ev) =>
                    {
                        // Ok button click task  
                    });
                    alert.Show();
                }
            }
            else
            {
                Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Error");
                alert.SetMessage("LLenar correctamente los campos Origen y Destino de Viaje");
                alert.SetButton("OK", (c, ev) =>
                {
                    // Ok button click task  
                });
                alert.Show();
            }
        }

        private void _fechaInicio_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime fecha)
            {
                fechaDeVuelo = fecha;
                _fechaInicio.Text = fecha.ToString("ddd, MMM d");
            }, DateTime.Today);
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void _fechaFin_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime fecha)
            {
                FechaDeVueloRetorno = fecha;
                _fechaFin.Text = fecha.ToString("ddd, MMM d");
            }, fechaDeVuelo);
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void _viajarA_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (_viajarA.IsFocused)
            {
                FragmentTransaction _transaction = FragmentManager.BeginTransaction();
                FiltrarAeropuertoDialog _FiltrarAeropuertoDialog = new FiltrarAeropuertoDialog(delegate (string aeropuerto) { _viajarA.Text = aeropuerto; }, Resource.Style.dialog_animation_ViajarA, _viajarA.Hint);
                _FiltrarAeropuertoDialog.Show(_transaction, "Filtrar Aeropuerto");
            }
        }

        private void _viajarA_Click(object sender, EventArgs e)
        {
            FragmentTransaction _transaction = FragmentManager.BeginTransaction();
            FiltrarAeropuertoDialog _FiltrarAeropuertoDialog = new FiltrarAeropuertoDialog(delegate (string aeropuerto) { _viajarA.Text = aeropuerto; }, Resource.Style.dialog_animation_ViajarA, _viajarA.Hint);
            _FiltrarAeropuertoDialog.Show(_transaction, "Filtrar Aeropuerto");
        }

        private void _irDesde_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (_irDesde.IsFocused)
            {
                FragmentTransaction _transaction = FragmentManager.BeginTransaction();
                FiltrarAeropuertoDialog _FiltrarAeropuertoDialog = new FiltrarAeropuertoDialog(delegate (string aeropuerto)
                {
                    _irDesde.Text = aeropuerto;
                }, Resource.Style.dialog_animation_IrDesde, _irDesde.Hint);
                _FiltrarAeropuertoDialog.Show(_transaction, "Filtrar Aeropuerto");
            }
        }

        private void _irDesde_Click(object sender, EventArgs e)
        {
            FragmentTransaction _transaction = FragmentManager.BeginTransaction();
            FiltrarAeropuertoDialog _FiltrarAeropuertoDialog = new FiltrarAeropuertoDialog(delegate (string aeropuerto)
            {
                _irDesde.Text = aeropuerto;
            }, Resource.Style.dialog_animation_IrDesde, _irDesde.Hint);
            _FiltrarAeropuertoDialog.Show(_transaction, "Filtrar Aeropuerto");
        }
    }
}