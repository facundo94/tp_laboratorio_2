using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.Security.Permissions;

namespace Hilo
{
    public class Descargador
    {        
        private string html;
        private Uri direccion;
        public delegate void EnProgreso(int progreso);
        public event EnProgreso enProgreso;
        public delegate void Completo(string datos);
        public event Completo completo;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();

                cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClientDownloadProgressChanged);
                cliente.DownloadStringCompleted += new DownloadStringCompletedEventHandler(WebClientDownloadCompleted);

                cliente.DownloadStringAsync(direccion, html);                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.enProgreso(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;            
            this.completo(this.html);
        }
    }
}
