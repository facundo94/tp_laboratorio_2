using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Layout
{
    public partial class Form1 : Form
    {
        private Numero numero1;
        private Numero numero2;
        private string operador;
        Calculadora calculadora = new Calculadora();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion;
            opcion = this.cmbOperacion.Text;
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {//Limpia el layaout         
            this.lblResultado.Text = "0";
            this.txtNumero1.ResetText();
            this.txtNumero2.ResetText();
            this.cmbOperacion.Text = "+";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {//se encarga de enviar los datos necesarios para la operacion 
            this.numero1 = new Numero(txtNumero1.Text);
            this.numero2 = new Numero(txtNumero2.Text);
            this.operador = cmbOperacion.Text;

            this.lblResultado.Text = Calculadora.Operar(this.numero1, this.numero2,
                Calculadora.validarOperador(this.operador)).ToString();
            this.txtNumero1.Text = this.numero1.getNumero().ToString();
            this.txtNumero2.Text = this.numero2.getNumero().ToString();
        }
    }
}
