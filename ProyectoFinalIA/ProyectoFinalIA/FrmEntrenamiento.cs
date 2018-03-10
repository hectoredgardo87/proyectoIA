using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.ML.Train;
using Encog.ML.Data.Basic;
using Encog.Persist;
using System.Data.OleDb;

namespace ProyectoFinalIA
{
    public partial class FrmEntrenamiento : Form
    {
        OleDbConnection con;
        // 10 imagenes para entrenar
        Bitmap imagen0, imagen1, imagen2, imagen3, imagen4, imagen5, imagen6, imagen7, imagen8, imagen9;

        int CicloE = 0;
        int ciclo = 0;
        List<double> cadena = new List<double>();
        List<int> cadena2 = new List<int>();
        int a, b, c, d;

        //arreglo de las diez imagenes
        Bitmap[] fotos;


        //arreglo final resultante

        double[][] E = new double[10][];
        //arreglo de archivos
        string[] files;

        // matriz de resultado ideal
        double[][] IDEAL =
         {
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
            new[] {1.0},
        };

        public FrmEntrenamiento(OleDbConnection con)
        {
            InitializeComponent();
            c = 0;
            progressBar1.Visible = false;
            BtnEntrenar.Enabled = false;
            this.con = con;
        }


        private void BtnSubirFirmas_Click(object sender, EventArgs e)
        {
            imagen0 = null;
            imagen1 = null;
            imagen2 = null;
            imagen3 = null;
            imagen4 = null;
            imagen5 = null;
            imagen6 = null;
            imagen7 = null;
            imagen8 = null;
            imagen9 = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            if (txtNombre.Text == "" || txtApellido.Text == "")
            {
                MessageBox.Show("Antes de subir la imagen coloque el nombre y apellido");
            }
            else
            {
                try
                {
                    FolderBrowserDialog Dialogo = new FolderBrowserDialog();
                    Dialogo.SelectedPath = Application.StartupPath;
                    DialogResult response = Dialogo.ShowDialog();
                    if (response == DialogResult.OK)
                    {
                        files = Directory.GetFiles(Dialogo.SelectedPath, "*.png");

                    }

                    //Pasando cada imagen a su respectivo bitmap
                    imagen0 = new Bitmap(files[0]);
                    imagen1 = new Bitmap(files[1]);
                    imagen2 = new Bitmap(files[2]);
                    imagen3 = new Bitmap(files[3]);
                    imagen4 = new Bitmap(files[4]);
                    imagen5 = new Bitmap(files[5]);
                    imagen6 = new Bitmap(files[6]);
                    imagen7 = new Bitmap(files[7]);
                    imagen8 = new Bitmap(files[8]);
                    imagen8 = new Bitmap(files[8]);
                    imagen8 = new Bitmap(files[8]);
                    imagen9 = new Bitmap(files[9]);

                    //Arreglo de Bitmaps
                    fotos = new Bitmap[] { imagen0, imagen1, imagen2, imagen3, imagen4, imagen5, imagen6, imagen7, imagen8, imagen9 };

                    //El arreglo tendrá las dimensiones de la primera imagen considerando
                    //que las imagenes por usuario tienen la misma dimensión
                    E[0] = new double[imagen0.Height * imagen0.Width];
                    E[1] = new double[imagen1.Height * imagen1.Width];
                    E[2] = new double[imagen2.Height * imagen2.Width];
                    E[3] = new double[imagen3.Height * imagen3.Width];
                    E[4] = new double[imagen4.Height * imagen4.Width];
                    E[5] = new double[imagen5.Height * imagen5.Width];
                    E[6] = new double[imagen6.Height * imagen6.Width];
                    E[7] = new double[imagen7.Height * imagen7.Width];
                    E[8] = new double[imagen8.Height * imagen8.Width];
                    E[9] = new double[imagen9.Height * imagen9.Width];
                    //comprobar si ha cargado la imagen

                    if (imagen0 == null)
                    {
                        MessageBox.Show("Error");
                    }
                    else
                    {
                        //MessageBox.Show("Archivos Cargados Exitosamente");

                        pictureBox1.Image = imagen1;
                        pictureBox2.Image = imagen2;
                        pictureBox3.Image = imagen3;
                        pictureBox4.Image = imagen4;
                        pictureBox5.Image = imagen5;
                        pictureBox6.Image = imagen6;
                        pictureBox7.Image = imagen7;
                        pictureBox8.Image = imagen8;
                        pictureBox9.Image = imagen9;
                        pictureBox10.Image = imagen0;
                    }

                    /*Armado del Arreglo*/
                    progressBar1.Visible = true;
                    //Ciclo que recorre las diez imagenes
                    for (int k = 0; k < 10; k++)
                    {
                        d = 0;
                        //Ciclo que recorre los pixeles verticalmente
                        for (int i = 0; i < fotos[k].Height; i++)
                        {
                            //Ciclo que recorre los pixeles horizontalmente
                            for (int j = 0; j < fotos[k].Width; j++)
                            {
                                //Guarda un -1 si el pixel es blanco 1 si no lo es (es negro)
                                if (fotos[k].GetPixel(j, i).Name == "ffffffff")
                                {
                                    E[k][d] = -1;

                                    a = a + 1;
                                    d = d + 1;
                                }
                                else
                                {
                                    E[k][d] = 1;

                                    b = b + 1;
                                    d = d + 1;
                                }
                            }

                        }
                        progressBar1.Value += 10;
                        this.BtnSubirFirmas.Enabled = false;
                        BtnEntrenar.Enabled = true;
                    }
                    progressBar1.Visible = false;
                    MessageBox.Show("Imágenes Subidas Exitosamente");
                   

            }
                catch (System.NullReferenceException)
            {
               
                    imagen0 = null;
                    imagen1 = null;
                    imagen2 = null;
                    imagen3 = null;
                    imagen4 = null;
                    imagen5 = null;
                    imagen6 = null;
                    imagen7 = null;
                    imagen8 = null;
                    imagen9 = null;
                    pictureBox1.Image = null;
                    pictureBox2.Image = null;
                    pictureBox3.Image = null;
                    pictureBox4.Image = null;
                    pictureBox5.Image = null;
                    pictureBox6.Image = null;
                    pictureBox7.Image = null;
                    pictureBox8.Image = null;
                    pictureBox9.Image = null;
                    pictureBox10.Image = null;
                    MessageBox.Show("Seleccione una carpeta con las 10 imagenes");
                }

            /*Fin del formado de arreglo*/
        }
   }

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            this.con.Open();
           
            var redN = new BasicNetwork();
            redN.AddLayer(new BasicLayer(null, false, imagen0.Height * imagen0.Width));
            redN.AddLayer(new BasicLayer(new ActivationLinear(), false, 2));
            redN.AddLayer(new BasicLayer(new ActivationLinear(), true, 1));
            redN.Structure.FinalizeStructure();
            redN.Reset();

            IMLDataSet Set = new BasicMLDataSet(E, IDEAL);

            
            IMLTrain train = new ResilientPropagation(redN, Set);
          
            
            do
            {

             CicloE++;
             train.Iteration();
             cadena.Add(train.Error);
             cadena2.Add(CicloE);


             }

             while (train.Error > 0.01);

                timer1.Enabled = true;
                timer1.Start();
                char i1;
                char i2;

            i1 = txtNombre.Text.ToUpper()[0];
            i2 = txtApellido.Text.ToUpper()[0];
            EncogDirectoryPersistence.SaveObject(new FileInfo(i1.ToString() + i2.ToString() + ".txt"), redN);

           
        }

        public void Mostrar(double e, int r)
        {
            txtRepeticion.Text = "";
            txtError.Text = "";

            txtRepeticion.Text = r.ToString();
            txtError.Text = e.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           Mostrar(cadena[ciclo], cadena2[ciclo]);
            
           ciclo++;

            if (ciclo == cadena.Count())
            {
                timer1.Stop();
                char i1;
                char i2;

                i1 = txtNombre.Text.ToUpper()[0];
                i2 = txtApellido.Text.ToUpper()[0];

                OleDbCommand comando = new OleDbCommand();
                comando.Connection = con;
                comando.CommandText = string.Format("Insert Into tbl_firmas(Pnombre,PApellido,ArchivoNeuronal,Ciclos,Error,Tamano) Values('{0}','{1}','{2}','{3}','{4}','{5}')", txtNombre.Text, txtApellido.Text, i1.ToString() + i2.ToString() + ".txt", txtRepeticion.Text, txtError.Text, Convert.ToString(imagen0.Width)+"x"+ Convert.ToString(imagen0.Height));
                comando.ExecuteNonQuery();
                con.Close();
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Entrenamiento Completado");
            }
        }


    }
}
