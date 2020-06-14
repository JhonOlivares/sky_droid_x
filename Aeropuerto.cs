namespace AndroidAerolinea
{
    public class Aeropuerto
    {
        public string IATA_aeropuertoID { get; set; }
        public string nombreAeropuerto { get; set; }
        public Ciudad oCiudad { get; set; }


        public Aeropuerto()
        {
            oCiudad = new Ciudad();
        }

        public Aeropuerto(string IATA_aeropuertoID)
        {
            this.IATA_aeropuertoID = IATA_aeropuertoID;
        }

        public Aeropuerto(string IATA_aeropuertoID, string nombreAeropuerto, Ciudad oCiudad)
        {
            this.IATA_aeropuertoID = IATA_aeropuertoID;
            this.nombreAeropuerto = nombreAeropuerto;
            this.oCiudad = oCiudad;
        }

        public override string ToString()
        {
            return nombreAeropuerto;
        }
    }
}