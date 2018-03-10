using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ProyectoFinalIA
{
    public partial class FrmInicio : Form
    {
        OleDbConnection coneccion;
        public FrmInicio()
        {

            InitializeComponent();
            coneccion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\BDFIRMAS.accdb");

            try
            {
                coneccion.Open();
                MessageBox.Show("Bienvenidos a nuestra aplicación de reconocimiento de firmas");

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            coneccion.Close();
        }

        private void BtnEntrenamiento_Click(object sender, EventArgs e)
        {
            FrmEntrenamiento F = new FrmEntrenamiento(coneccion);
            F.ShowDialog();
        }

        private void BtnComprobacion_Click(object sender, EventArgs e)
        {
            FrmComprobar FrmComprobar = new FrmComprobar(coneccion);
            FrmComprobar.ShowDialog();
        }
    }
}
