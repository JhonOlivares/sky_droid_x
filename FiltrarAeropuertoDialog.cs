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
using Android.Views.InputMethods;

namespace AndroidAerolinea
{
    class FiltrarAeropuertoDialog : DialogFragment
    {
        public FiltrarAeropuertoDialog(Action<string> aeropuertoName, int _transision, string hint)
        {
            sendText = aeropuertoName;
            miTransicion = _transision;
            miHint = hint;
        }
        public int miTransicion { get; set; }

        public string miHint { get; set; }

        Action<string> sendText = delegate { };//lol
        Mensajero _DataSet;
        List<Aeropuerto> _Aeropuertos;
        EditText _editText;
        ListView _lvAeropuertos;
        ArrayAdapter<string> _miArrayAdapter;
        readonly IList<string> textos = new List<string>();
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceStated)
        {
            base.OnCreateView(inflater, container, savedInstanceStated);
            var view = inflater.Inflate(Resource.Layout.FiltrarAeropuerto, container, false);
            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = miTransicion;
            Dialog.Window.SetGravity(GravityFlags.Top);
            _editText = Dialog.Window.FindViewById<EditText>(Resource.Id.etIrDesdeDialog);
            _lvAeropuertos = Dialog.Window.FindViewById<ListView>(Resource.Id.lvAeropuetos);
            _editText.TextChanged += _editText_TextChanged;
            _lvAeropuertos.ItemClick += _lvAeropuertos_ItemClick;
            _editText.Hint = miHint;
            _editText.RequestFocus();
            Dialog.Window.SetSoftInputMode(SoftInput.StateVisible);

            _miArrayAdapter = new ArrayAdapter<string>(this.Context, Android.Resource.Layout.SimpleListItem1);
            _lvAeropuertos.Adapter = _miArrayAdapter;

        }

        private void _editText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {            
            try
            {
                if (_editText.Length() > 0)
                {
                    _miArrayAdapter.Clear();
                    _DataSet = new Mensajero();
                    _Aeropuertos = _DataSet.filtrarAeropuertos(_editText.Text.Trim());
                    foreach (Aeropuerto item in _Aeropuertos)
                    {
                        _miArrayAdapter.Add("" + item.oCiudad.nombreCiudad + "(" + item.IATA_aeropuertoID + ")");
                    }
                    return;
                }
                else if (_lvAeropuertos.Count > 0)
                {
                    _miArrayAdapter.Clear();
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void _lvAeropuertos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            sendText(_lvAeropuertos.GetItemAtPosition(e.Position).ToString());//lol
            this.Dismiss();//Dialog.Dismiss();

        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            //base.OnDismiss(dialog);
            //implemeta codigo
        }
    }
}