namespace AndroidAerolinea
{
    public class Ciudad
    {
        public int ciudadID { get; set; }
        public string nombreCiudad { get; set; }

        public override string ToString()
        {
            return nombreCiudad;
        }
    }
}