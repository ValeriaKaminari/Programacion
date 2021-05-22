using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace OrdenaNumeros
{
    public class LogicaOrdenaNumeros
    {
        //Atributos propios del juego
        private int[,] matrizValores;
        private Button[,] matrizBotones;
        private int posicionFila, posicionColumna;
        private Button[] botones;

        public LogicaOrdenaNumeros()
        {
            posicionFila = 0;
            posicionColumna = 0;

            matrizBotones = new Button[4, 4];
            matrizValores = new int[4, 4];
            botones = new Button[16];
        }

        public void SetButtons(Button boton1, Button boton2, Button boton3, Button boton4, Button boton5, Button boton6, Button boton7, Button boton8, Button boton9, Button boton10, Button boton11, Button boton12, Button boton13, Button boton14, Button boton15, Button boton16)
        {
            botones[0] = boton1;
            botones[1] = boton2;
            botones[2] = boton3;
            botones[3] = boton4;
            botones[4] = boton5;
            botones[5] = boton6;
            botones[6] = boton7;
            botones[7] = boton8;
            botones[8] = boton9;
            botones[9] = boton10;
            botones[10] = boton11;
            botones[11] = boton12;
            botones[12] = boton13;
            botones[13] = boton14;
            botones[14] = boton15;
            botones[15] = boton16;

            SetPositionButtons();
        }

        public void SetPositionButtons()
        {
            int botonNumero = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizBotones[i, j] = botones[botonNumero];

                    botonNumero++;
                }
            }
        }

        /// <summary>
        /// Inicializa la matriz de valores, asignando los numeros a organizar
        /// </summary>
        public void InicializaMatrizValores()
        {
            int valor = 0;

            //Inicialmente se asignan los números del 0 al 15 en toda la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrizValores[i, j] = valor;
                    valor++;
                }
            }

            //Luego, procedemos a cambiar los valores de posición de manera aleatoria

            Random aleatorio = new Random();
            int posicionHorizontal, posicionVertical, valorTemporal;

            //Aqui desordenamos la matriz, calculando posiciones horizontales y
            //verticales dentro de la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    valorTemporal = matrizValores[i, j];
                    posicionHorizontal = aleatorio.Next(4);
                    posicionVertical = aleatorio.Next(4);

                    matrizValores[i, j] = matrizValores[posicionHorizontal, posicionVertical];
                    matrizValores[posicionHorizontal, posicionVertical] = valorTemporal;


                }
            }
        }

        /// <summary>
        /// Asigna los valores de la matrizValores como etiquetas de los
        /// botones en la matrizBotones
        /// </summary>
        public void InicializaEtiquetaBotones()
        {
            //Recalculamos la matriz de valores
            InicializaMatrizValores();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //El botón que tenga el valor 0, se verá como vacío
                    //para que el usuario pueda "desplazar" el valor allí
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = matrizValores[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Evalua información asociada al botón presionado
        /// </summary>
        /// <param name="numeroBoton">Consecutivo del botón presionado</param>
        /// <param name="datoFila">Fila en la matriz a la que pertenece el botón</param>
        /// <param name="datoColumna">Columna en la matriz a la que pertenece el botón</param>
        public void EvaluaBotonPresionado(int numeroBoton, int datoFila, int datoColumna)
        {
            posicionFila = datoFila;
            posicionColumna = datoColumna;

            //Aqui evaluamos en la matrizValores, la posición correspondiente al botón presionado
            EvaluaPosicion();

            //Finalmente, se da la notificación si el valor se encuentra en la posición correcta
            NotificaPosicionCorrectaValor();
        }

        /// <summary>
        /// Evalua si la posición presionada está adjacente al espacio disponible para usar
        /// </summary>
        public void EvaluaPosicion()
        {
            int valorTemporal = 0;

            //Validamos el valor superior a donde presionamos si está el cero
            if (posicionFila > 0)
            {
                if (matrizValores[posicionFila - 1, posicionColumna] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila - 1, posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor inferior a donde presionamos si está el cero
            if (posicionFila < 3)
            {
                if (matrizValores[posicionFila + 1, posicionColumna] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila + 1, posicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor izquierdo a donde presionamos si está el cero
            if (posicionColumna > 0)
            {
                if (matrizValores[posicionFila, posicionColumna - 1] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila, posicionColumna - 1] = valorTemporal;
                }
            }

            //Validamos el valor derecho a donde presionamos si está el cero
            if (posicionColumna < 3)
            {
                if (matrizValores[posicionFila, posicionColumna + 1] == 0)
                {
                    valorTemporal = matrizValores[posicionFila, posicionColumna];
                    matrizValores[posicionFila, posicionColumna] = 0;
                    matrizValores[posicionFila, posicionColumna + 1] = valorTemporal;
                }
            }

            //Finalmente actualizamos etiquetas de los botones
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = matrizValores[i, j].ToString();
                }
            }

            //Y valoramos la condición de victoria
            EvaluaCondicionVictoria();
        }

        /// <summary>
        /// Esta función valida si todos los números están organizados
        /// </summary>
        public void EvaluaCondicionVictoria()
        {
            //Partimos del supuesto que ya logramos la condición de victoria
            bool condicionVictoria = true;

            int valorBuscado = 0;

            //Aqui recorremos la matriz de valores buscando para cada posición si el valor está en orden
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //incrementamos el valor buscado
                    valorBuscado++;

                    //Si los valores son diferentes, entonces todavía necesitamos seguir jugando!!!
                    if (matrizValores[i, j] != valorBuscado)
                    {
                        // Validamos si estamos en la última casilla, el valor existente es 0,
                        // el valor buscado ya llegó a 16 y la condición de victoria sigue siendo true
                        if (matrizValores[i, j] == 0 && valorBuscado == 16 && condicionVictoria == true)
                            condicionVictoria = true;

                        // De lo contrario, es porque estamos en cualquier otra casilla y los valores
                        // Todavía no son iguales
                        else
                            condicionVictoria = false;
                    }
                }
            }


            //Si la condición de victoria se logró, mostramos el mensaje de Victoria y desactivamos los botones
            if (condicionVictoria == true)
            {
                MessageBox.Show("Todos los números organizados, Felicitaciones!", "Victoria Alcanzada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InactivaBotones();
            }
        }

        /// <summary>
        /// Esta función inactiva los botones para ser utilizados en el juego
        /// </summary>
        public void InactivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = false;
        }

        /// <summary>
        /// Esta función activa los botones para ser utilizados en el juego
        /// </summary>
        public void ActivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = true;
        }

        /// <summary>
        /// Notifica que el número se encuentra en la posición correcta, cambiando el color de fondo del botón
        /// </summary>
        public void NotificaPosicionCorrectaValor()
        {

            int[,] valoresEsperados = new int[4, 4];
            int valor = 1;

            int totalFilas = valoresEsperados.GetLength(0);
            int totalColumnas = valoresEsperados.GetLength(1);

            //Aqui llenamos la matriz de los valores esperados
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    valoresEsperados[i, j] = valor;
                    valor++;
                }

            //Al finalizar el juego, en la posición 4,4 se encuentra el 0
            valoresEsperados[3, 3] = 0;

            //Ahora comparamos con los valores actuales para saber si están en la posición correcta
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    if (matrizValores[i, j] == valoresEsperados[i, j])
                        matrizBotones[i, j].BackColor = Color.LightGreen;
                    else
                        matrizBotones[i, j].BackColor = Color.LightGray;

                    //El botón que tiene el 0 no deberá cambiar de color
                    if (matrizValores[i, j] == 0)
                        matrizBotones[i, j].BackColor = Color.LightGray;
                }
        }

        /// <summary>
        /// Método que inicializa el fondo de los botones con un color gris claro
        /// </summary>
        public void InicializaFondoBotones()
        {
            int totalFilas = matrizBotones.GetLength(0);
            int totalColumnas = matrizBotones.GetLength(1);

            //Asignamos a todos los botones gris claro como color de fondo
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                    matrizBotones[i, j].BackColor = Color.LightGray;
        }

        public int Factorial(int numero)
        {
            if (numero == 0)
                return 1;

            int result = 1;

            for (int i = 1; i <= numero; i++)
            {
                result *= i;
            }

            return result;
        }

        public int Letras(string palabra)
        {
            int letras = 0;
            char[] letrasGuardadas = palabra.ToCharArray();

            foreach (char i in letrasGuardadas)
            {
                if (!char.IsNumber(i) && !char.IsPunctuation(i) && !char.IsWhiteSpace(i))
                    letras++;
            }

            return letras;
        }

        public string CifraPalabra(string palabraCifrada)
        {
            string palabraTemporal = palabraCifrada.ToLower();
            string resultado = "";
            char[] letrasCambiar = palabraCifrada.ToCharArray();

            foreach (char i in letrasCambiar)
            {
                string valorDeReemplazo = "0";
                switch (i)
                {
                    case 'a':
                    case 'b':
                    case 'c':
                        valorDeReemplazo = "1";
                        break;
                    case 'q':
                    case 'r':
                    case 's':
                        valorDeReemplazo = "2";
                        break;
                    case 't':
                    case 'u':
                    case 'v':
                        valorDeReemplazo = "3";
                        break;
                    default:
                        valorDeReemplazo = i.ToString();
                        break;
                }
                resultado += valorDeReemplazo;
            }
            return resultado;
        }
    }
}
