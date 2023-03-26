using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnjoyOnline.Shared.Models
{
    public static class Utilidades
    {
        public static IEnumerable<string> archivoCarpeta(string carpeta)
        {
            //string carpeta = @"C:\";
            string directorio = $"C:\\Users\\matias.osuna\\Documents\\PROYECTOS VISUAL STUDIO\\EnjoyOnline\\Client\\wwwroot\\Publicaciones\\{carpeta}";

            DirectoryInfo dir = new DirectoryInfo(directorio);
            List<string> directorioSalida = new List<string>();


            foreach (FileInfo file in dir.GetFiles())
            {
                directorioSalida.Add(file.Name);
                

            }

            Console.WriteLine(directorio.ToString());
            return directorioSalida;
        }

        public static IEnumerable<string> archivoCarpetaSubcarpeta(string carpeta,string subCarpeta)
        {
            //string carpeta = @"C:\";
            string directorio = $"C:\\Users\\matias.osuna\\Documents\\PROYECTOS VISUAL STUDIO\\EnjoyOnline\\Client\\wwwroot\\Publicaciones\\{subCarpeta}\\{carpeta}";

            DirectoryInfo dir = new DirectoryInfo(directorio);
            List<string> directorioSalida = new List<string>();


            foreach (FileInfo file in dir.GetFiles())
            {
                directorioSalida.Add(file.Name);


            }

            Console.WriteLine(directorio.ToString());
            return directorioSalida;
        }

        public static async Task <IEnumerable<FileInfo>> archivoCarpetaFiles()
        {
            string carpeta = @"C:\";

            DirectoryInfo dir = new DirectoryInfo(carpeta);
            List<FileInfo> archivos = new List<FileInfo>();


            foreach (FileInfo file in dir.GetFiles())
            {
                archivos.Add(file);
                Console.WriteLine(file.Name);
                Console.WriteLine(file.LinkTarget);

            }

            Console.WriteLine(archivos.ToString());
            return archivos;
        }
    }
}
