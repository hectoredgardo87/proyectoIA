﻿using System;
using System.Windows.Forms;

namespace ProyectoFinalIA
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmInicio());
        }
    }
}
