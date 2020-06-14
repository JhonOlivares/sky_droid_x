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
    public class MyViewHolder : RecyclerView.ViewHolder
    {
        public TextView tvNumeroDeVuelo { get; set; }
        public TextView tvFechaIda { get; set; }
        public TextView tvIATAOrigen { get; set; }
        public TextView tvHoraDeSalida { get; set; }
        public TextView tvTiempoDeVuelo { get; set; }
        public TextView tvIATADestino { get; set; }
        public TextView tvHoraDeLLegada { get; set; }

        public TextView tvCiudadAeropuertoOrigen { get; set; }
        public TextView tvCiudadAeropuertoDestino { get; set; }


        public MyViewHolder(View _itemView) : base(_itemView)
        {
            tvNumeroDeVuelo = _itemView.FindViewById<TextView>(Resource.Id.tvNumeroDeVuelo);
            tvFechaIda = _itemView.FindViewById<TextView>(Resource.Id.tvFechaIda);
            tvIATAOrigen = _itemView.FindViewById<TextView>(Resource.Id.tvIATAOrigen);
            tvHoraDeSalida = _itemView.FindViewById<TextView>(Resource.Id.tvHoraDeSalida);
            tvTiempoDeVuelo = _itemView.FindViewById<TextView>(Resource.Id.tvTiempoDeVuelo);
            tvIATADestino = _itemView.FindViewById<TextView>(Resource.Id.tvIATADestino);
            tvHoraDeLLegada = _itemView.FindViewById<TextView>(Resource.Id.tvHoraDeLLegada);
            tvCiudadAeropuertoOrigen = _itemView.FindViewById<TextView>(Resource.Id.tvCiudadAeropuertoOrigen);
            tvCiudadAeropuertoDestino = _itemView.FindViewById<TextView>(Resource.Id.tvCiudadAeropuertoDestino);
        }
    }
}