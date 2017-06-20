using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Completa el url con 'htttp://' en caso de ser neceario, y se descarga el codigo fuente de la pagina web indicada.
        /// Las direcciones de las paginas se guardan en un archivo de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reg = new Regex(@"^[Hh]ttp://");
                if (!reg.IsMatch(txtUrl.Text))
                {
                    txtUrl.Text = "http://" + txtUrl.Text;
                }

                Descargador ds = new Descargador(new Uri(this.txtUrl.Text));
                ds.enProgreso += new Descargador.EnProgreso(this.ProgresoDescarga);
                ds.completo += new Descargador.Completo(this.FinDescarga);

                Thread hilo = new Thread(ds.IniciarDescarga);
                hilo.Start();

                archivos.guardar(this.txtUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Lee desde un archivo de texto y muesta la lista completa de sitios visitados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial historial = new frmHistorial();
            historial.ShowDialog();
        }

        
    }
}
