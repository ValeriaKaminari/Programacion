using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrdenaNumeros
{
    public partial class Form1 : Form
    {
        private Logic miJuego;

        /// <summary>
        /// Constructor de la clase Form1
        /// </summary>
        public Form1()
        {
            miJuego = new Logic();

            InitializeComponent();

            //Aqui se invocan los metodos que inicializan las matrices
            miJuego.InicializaMatrizBotones(boton1, boton2, boton3, boton4, boton5, boton6, boton7, boton8, boton9, boton10, boton11, boton12, boton13, boton14, boton15, boton16);
            miJuego.InicializaMatrizValores();
        }

        /// <summary>
        /// Evento que se usa cuando se carga la forma por primera vez
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Se invoca la inicialización de botones
            miJuego.InicializaEtiquetaBotones(); //lógico
        }

        /// <summary>
        /// Evento para reiniciar el juego desde la barra de Menus - ItemReiniciaJuego
        /// </summary>
        private void menuItemReiniciaJuego_Click(object sender, EventArgs e)
        {
            //Se invoca la inicialización de botones
            miJuego.InicializaEtiquetaBotones();

            //Se activan los botones para que puedan ser usados 
            miJuego.ActivaBotones();

            //Se le coloca el color de fondo predeterminado
            miJuego.InicializaFondoBotones();

            //Se da la notificación si el valor se encuentra en la posición correcta
            miJuego.NotificaPosicionCorrectaValor();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(1, 0, 0);
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(2, 0, 1);
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(3, 0, 2);
        }

        private void boton4_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(4, 0, 3);
        }

        private void boton5_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(5, 1, 0);
        }

        private void boton6_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(6, 1, 1);
        }

        private void boton7_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(7, 1, 2);
        }

        private void boton8_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(8, 1, 3);
        }

        private void boton9_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(9, 2, 0);
        }

        private void boton10_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(10, 2, 1);
        }

        private void boton11_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(11, 2, 2);
        }

        private void boton12_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(12, 2, 3);
        }

        private void boton13_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(13, 3, 0);
        }

        private void boton14_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(14, 3, 1);
        }

        private void boton15_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(15, 3, 2);
        }

        private void boton16_Click(object sender, EventArgs e)
        {
            miJuego.EvaluaBotonPresionado(16, 3, 3);
        }

        /// <summary>
        /// Evento para item salir que cierra la aplicación
        /// </summary>
        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
