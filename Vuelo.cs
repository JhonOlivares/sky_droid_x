using System;
namespace AndroidAerolinea
{
    public class Vuelo
    {
        public int vueloID { get; set; }
        public Vuelo_Programado numeroVuelo { get; set; }
        public DateTime fechaVuelo { get; set; }

        public Vuelo()
        {
            numeroVuelo = new Vuelo_Programado();
        }

        public Vuelo(int vuelo)
        {
            vueloID = vuelo;
        }

        public Vuelo(int _vueloID, Vuelo_Programado _numeroVuelo, DateTime _fecha)
        {
            vueloID = _vueloID;
            numeroVuelo = _numeroVuelo;
            fechaVuelo = _fecha;
        }
    }
}