using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidAerolinea
{
    public class Mensajero
    {
        SqlConnection conexion = MiConexionSQL.getConexion();
        public List<Aeropuerto> filtrarAeropuertos(string criterio)
        {
            List<Aeropuerto> oListAeropuerto = new List<Aeropuerto>();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_FILTRAR_AEROPUERTO", conexion);
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Aeropuerto oAeropuerto = new Aeropuerto();
                    oAeropuerto.IATA_aeropuertoID = ((string)lector["IATA_aeropuertoID"]);
                    //oAeropuerto.nombreAeropuerto = ((string)lector["nombreAeropuerto"]);
                    oAeropuerto.oCiudad.nombreCiudad = ((string)lector["nombreCiudad"]);
                    oListAeropuerto.Add(oAeropuerto);
                }
                lector.Close();
                conexion.Close();
                return oListAeropuerto;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }


        public List<Vuelo> vuelosDisponibles(DateTime fecha, DateTime fechaRegreso, string origen, string destino)
        {
            List<Vuelo> listVuelo = new List<Vuelo>();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_SELECCIONAR_VUELOS", conexion);
                comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                comando.Parameters.Add("@origen", SqlDbType.Char).Value = origen;
                comando.Parameters.Add("@destino", SqlDbType.Char).Value = destino;
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Vuelo oVueloDisponible = new Vuelo();
                    oVueloDisponible.numeroVuelo.numeroVuelo = Convert.ToString(lector["numeroVuelo"]);
                    oVueloDisponible.fechaVuelo = Convert.ToDateTime(lector["fechaVuelo"]);
                    oVueloDisponible.numeroVuelo.origen.IATA_aeropuertoID = Convert.ToString(lector["IATA_AeropuertoOrigen"]);
                    oVueloDisponible.numeroVuelo.origen.oCiudad.nombreCiudad = Convert.ToString(lector["ciudadOrigen"]);
                    oVueloDisponible.numeroVuelo.destino.IATA_aeropuertoID = Convert.ToString(lector["IATA_AeropuertoDestino"]);
                    oVueloDisponible.numeroVuelo.destino.oCiudad.nombreCiudad = Convert.ToString(lector["ciudadDestino"]);
                    oVueloDisponible.numeroVuelo.origen.nombreAeropuerto = Convert.ToString(lector["nombreAeropuertoOrigen"]);
                    oVueloDisponible.numeroVuelo.destino.nombreAeropuerto = Convert.ToString(lector["nombreAeropuertoDestino"]);
                    oVueloDisponible.numeroVuelo.horaSalida = Convert.ToDateTime(lector["horaSalida"]);
                    oVueloDisponible.numeroVuelo.tiempoDeVuelo = Convert.ToDouble(lector["tiempoDeVuelo"]);
                    listVuelo.Add(oVueloDisponible);
                }

                lector.Close();
                conexion.Close();

                conexion.Open();
                SqlCommand comando2 = new SqlCommand("SP_SELECCIONAR_VUELOS", conexion);
                comando2.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fechaRegreso;
                comando2.Parameters.Add("@origen", SqlDbType.Char).Value = destino;
                comando2.Parameters.Add("@destino", SqlDbType.Char).Value = origen;
                comando2.CommandType = CommandType.StoredProcedure;
                SqlDataReader lector2 = comando2.ExecuteReader();

                while (lector2.Read())
                {
                    Vuelo oVueloDisponible = new Vuelo();
                    oVueloDisponible.numeroVuelo.numeroVuelo = Convert.ToString(lector2["numeroVuelo"]);
                    oVueloDisponible.fechaVuelo = Convert.ToDateTime(lector2["fechaVuelo"]);
                    oVueloDisponible.numeroVuelo.origen.IATA_aeropuertoID = Convert.ToString(lector2["IATA_AeropuertoOrigen"]);
                    oVueloDisponible.numeroVuelo.origen.oCiudad.nombreCiudad = Convert.ToString(lector2["ciudadOrigen"]);
                    oVueloDisponible.numeroVuelo.destino.IATA_aeropuertoID = Convert.ToString(lector2["IATA_AeropuertoDestino"]);
                    oVueloDisponible.numeroVuelo.destino.oCiudad.nombreCiudad = Convert.ToString(lector2["ciudadDestino"]);
                    oVueloDisponible.numeroVuelo.origen.nombreAeropuerto = Convert.ToString(lector2["nombreAeropuertoOrigen"]);
                    oVueloDisponible.numeroVuelo.destino.nombreAeropuerto = Convert.ToString(lector2["nombreAeropuertoDestino"]);
                    oVueloDisponible.numeroVuelo.horaSalida = Convert.ToDateTime(lector2["horaSalida"]);
                    oVueloDisponible.numeroVuelo.tiempoDeVuelo = Convert.ToDouble(lector2["tiempoDeVuelo"]);
                    listVuelo.Add(oVueloDisponible);
                }
                lector2.Close();
                conexion.Close();
                return listVuelo;
            }
            catch (Exception)
            {
                conexion.Close();
                return null;
            }
        }
    }
}