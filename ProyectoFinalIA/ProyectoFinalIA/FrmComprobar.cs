using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Encog.Neural.Networks;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Persist;
using System.Data.OleDb;

namespace ProyectoFinalIA
{
    public partial class FrmComprobar : Form
    {
        OleDbConnection conect;

        Bitmap i0;
        Bitmap[] fotos;
        double[][] E = new double[1][];
        int a, b, c, d;
        string[] files;
        string tam = null;

        double[][] IDEAL =
         {
            new[] {1.0}
        };

        public FrmComprobar(OleDbConnection conect)
        {
            InitializeComponent();
            this.conect = conect;
        }


        private void BtnSubir_Click(object sender, EventArgs e)
        {
            try
            {



                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen|*.png";
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    String Direccion = BuscarImagen.FileName;
                    this.pictureBox1.ImageLocation = Direccion;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    i0 = new Bitmap(Direccion);
                    E[0] = new double[i0.Height * i0.Width];
                }


                //Ciclo que recorre los pixeles verticalmente

                d = 0;
                for (int i = 0; i < i0.Height; i++)
                {
                    //Ciclo que recorre los pixeles horizontalmente
                    for (int j = 0; j < i0.Width; j++)
                    {
                        //Guarda un 1 si el pixel es blanco -1 si no lo es (es negro)
                        if (i0.GetPixel(j, i).Name == "ffffffff")
                        {
                            E[0][d] = -1;

                            a = a + 1;
                            d = d + 1;
                            // LblPrueba.Text = LblPrueba.Text + E[0][d].ToString();
                        }
                        else
                        {
                            E[0][d] = 1;

                            b = b + 1;
                            d = d + 1;
                            //  LblPrueba.Text = LblPrueba.Text + E[0][d].ToString();
                        }
                    }
                }



                MessageBox.Show("Imagen Subida!");
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Seleccione una Imagen");
            }
}
   

        private void BtnComprobar_Click(object sender, EventArgs e)
        {

            try
            {
                if (i0 != null)
                {
                    this.conect.Open();

                    OleDbCommand comando = new OleDbCommand(string.Format("select ArchivoNeuronal,Tamano from tbl_firmas where Pnombre = '{0}' and PApellido = '{1}' ", txtNombre.Text, txtApellido.Text), this.conect);
                    OleDbDataReader lector = comando.ExecuteReader();
                    string dirArchivo = null;
                    
                    if (lector.HasRows)
                    {



                        while (lector.Read())
                        {
                            dirArchivo = Application.StartupPath + "\\" + lector.GetString(0);
                            tam = lector.GetString(1);
                        }

                        BasicNetwork RedExtraida = (BasicNetwork)EncogDirectoryPersistence.LoadObject(new FileInfo(dirArchivo));

                        IMLDataSet par = new BasicMLDataSet(E, IDEAL);

                        double Respuesta = RedExtraida.CalculateError(par);

                        if (Respuesta <= .20)
                        {
                            MessageBox.Show("La firma Introducida Tiene un nivel de aceptacion del : " + Convert.ToString(100-Math.Round(Respuesta, 3) * 100) + "%, la firma ha sido ACEPTADA");
                        }
                        else
                        {

                            MessageBox.Show("La firma Introducida Tiene un nivel de aceptacion del : " + Convert.ToString(100 - Math.Round(Respuesta, 3) * 100) + "%, la firma ha sido RECHAZADA");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Nombre y apellido no existe");
                    }
                }
                else
                {
                    MessageBox.Show("No hay imagen cargada");
                }

            }
            catch(System.ArgumentException)
            {
                MessageBox.Show("Verifique que la imagen tenga un tamaño de " + tam);
            }
            this.conect.Close();

        }

    }
}
