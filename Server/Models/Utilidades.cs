namespace EnjoyOnline.Server.Models
{
    public static class Utilidades
    {
       private static string directorio = "C:\\placas";

        public static string[] Ficheros()
        {
            string[] ficheros = Directory.GetFiles(directorio);
            return ficheros;
        }

    }
}
