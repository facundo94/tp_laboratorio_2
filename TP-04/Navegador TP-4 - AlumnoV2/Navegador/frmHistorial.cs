using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "Historial.txt";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga la lista de paginas visitadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> datos = new List<string>();

            archivos.leer(out datos);

            foreach (string i in datos)
            {
                lstHistorial.Items.Add(i);
            }
            
        }
    }
}
