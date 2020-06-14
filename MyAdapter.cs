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
using Android.Support.V7.Widget;

namespace AndroidAerolinea
{
    public class MyAdapter : RecyclerView.Adapter
    {
        private List<Vuelo> vuelos;
        public MyAdapter(List<Vuelo> VueloDisponible)
        {
            vuelos = VueloDisponible;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder vh = holder as MyViewHolder;
            vh.tvNumeroDeVuelo.Text = "Vuelo: " + vuelos[position].numeroVuelo.numeroVuelo.ToString();
            vh.tvFechaIda.Text = vuelos[position].fechaVuelo.ToString("MMMM dd, yyyy");
            vh.tvIATAOrigen.Text = vuelos[position].numeroVuelo.origen.IATA_aeropuertoID.ToString();
            vh.tvHoraDeSalida.Text = vuelos[position].numeroVuelo.horaSalida.ToShortTimeString();
            vh.tvTiempoDeVuelo.Text = "t: " + (TimeSpan.FromHours(vuelos[position].numeroVuelo.tiempoDeVuelo)).ToString("h\\:mm");
            vh.tvIATADestino.Text = vuelos[position].numeroVuelo.destino.IATA_aeropuertoID.ToString();
            vh.tvHoraDeLLegada.Text = (vuelos[position].numeroVuelo.horaSalida.AddHours(vuelos[position].numeroVuelo.tiempoDeVuelo)).ToShortTimeString();
            vh.tvCiudadAeropuertoOrigen.Text = vuelos[position].numeroVuelo.origen.nombreAeropuerto + System.Environment.NewLine + vuelos[position].numeroVuelo.origen.oCiudad.nombreCiudad;
            vh.tvCiudadAeropuertoDestino.Text = vuelos[position].numeroVuelo.destino.nombreAeropuerto + System.Environment.NewLine + vuelos[position].numeroVuelo.destino.oCiudad.nombreCiudad;            

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.VuelosCardView, parent, false);
            return new MyViewHolder(itemView);
        }
        public override int ItemCount => vuelos.Count;
    }
}