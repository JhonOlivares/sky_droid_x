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

namespace AndroidAerolinea
{
    public class Vuelo_Programado
    {
        public string numeroVuelo { get; set; }
        public Aeropuerto origen { get; set; }
        public Aeropuerto destino { get; set; }
        public DateTime horaSalida { get; set; }
        public double tiempoDeVuelo { get; set; }

        public Vuelo_Programado()
        {
            origen = new Aeropuerto();
            destino = new Aeropuerto();
        }

        public Vuelo_Programado(string _numeroVuelo)
        {
            numeroVuelo = _numeroVuelo;
        }

        public Vuelo_Programado(string _numeroVuelo, Aeropuerto _origen, Aeropuerto _destino, DateTime _horaSalida, double _tiempoDeVuelo)
        {
            numeroVuelo = _numeroVuelo;
            origen = _origen;
            destino = _destino;
            horaSalida = _horaSalida;
            tiempoDeVuelo = _tiempoDeVuelo;
        }
    }
}