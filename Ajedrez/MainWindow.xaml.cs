using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using System.Globalization;
using System.IO;
using Microsoft.Speech.AudioFormat;
using Microsoft.Speech.Recognition;
using System.ComponentModel;
using System.Windows.Threading;
using System.Timers;





namespace Ajedrez
{
    
    
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private KinectSensor myKinect;
        private SpeechRecognitionEngine speechEngine;
        private List<Span> recognitionSpans;
        private Rect sceneRect;



        enum Jugador : Int32
        {
            J1 = 1,
            J2 = 2
        }
        
        enum Camara : Int32
        {
            CAM1,
            CAM2,
            CAM3
        }

        enum color_fichas : Int32
        {
            BLANCAS,
            NEGRAS
        }


        Int32 turno_juega;
        int cam;
        int empieza;

        


        public MainWindow()
        {
            InitializeComponent();
        }

        private const int interval = 10;
        private TimeSpan countDown;
        private Timer timer;
        
        private static RecognizerInfo GetKinectRecognizer()
        {
            foreach (RecognizerInfo recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) && "es-ES".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }

            return null;
        }

        public static Label MakeSimpleLabel(string text, Rect bounds, System.Windows.Media.Brush brush)
        {
            Label label = new Label { Content = text };
            if (bounds.Width != 0)
            {
                label.SetValue(Canvas.LeftProperty, bounds.Left);
                label.SetValue(Canvas.TopProperty, bounds.Top);
                label.Width = bounds.Width;
                label.Height = bounds.Height;
            }

            label.Foreground = brush;
            label.FontFamily = new System.Windows.Media.FontFamily("Arial");
            label.FontWeight = FontWeight.FromOpenTypeWeight(600);
            label.FontStyle = FontStyles.Normal;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            return label;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myKinect = KinectSensor.KinectSensors[0];
            myKinect.ColorStream.Enable();
            myKinect.ColorFrameReady += MyKinect_ColorFrameReady;

            try
            {
                this.myKinect.Start();
            }
            catch (IOException)
            {
                this.myKinect = null;
            }


            /*countDown = TimeSpan.FromMinutes(0);
            timer = new Timer();
            timer.Interval = interval;
            countDown = countDown.Add(TimeSpan.FromMilliseconds(interval));

            Label timeText = MakeSimpleLabel(
                    Convert.ToString(countDown),
                    new Rect(
                        0.1 * this.sceneRect.Width, 0.25 * this.sceneRect.Height, 0.89 * this.sceneRect.Width, 0.72 * this.sceneRect.Height),
                    new SolidColorBrush(System.Windows.Media.Color.FromArgb(160, 255, 255, 255))); ;
            timeText.FontSize = Math.Max(1, this.sceneRect.Height / 16);
            timeText.HorizontalContentAlignment = HorizontalAlignment.Center;
            timeText.VerticalContentAlignment = VerticalAlignment.Top;*/
            


            

            RecognizerInfo ri = GetKinectRecognizer();

            if (null != ri)
            {
                recognitionSpans = new List<Span> { J1Span, J2Span };

                this.speechEngine = new SpeechRecognitionEngine(ri.Id);

                /****************************************************************
                * 
                * Use this code to create grammar programmatically rather than from
                * a grammar file.
                **/
                var directions = new Choices();
                directions.Add(new SemanticResultValue("inicio", "INICIO"));
                directions.Add(new SemanticResultValue("inicio partida", "INICIO"));
                directions.Add(new SemanticResultValue("comienzo", "COMIENZO"));
                directions.Add(new SemanticResultValue("empiezo", "COMIENZO"));
                directions.Add(new SemanticResultValue("comienzo turno", "COMIENZO"));
                directions.Add(new SemanticResultValue("fin", "FINAL"));
                directions.Add(new SemanticResultValue("final", "FINAL"));
                directions.Add(new SemanticResultValue("final turno", "FINAL"));
                directions.Add(new SemanticResultValue("finalizo turno", "FINAL"));
                directions.Add(new SemanticResultValue("seleccionar", "SELECCION"));
                directions.Add(new SemanticResultValue("mover", "MOVER"));
                directions.Add(new SemanticResultValue("desplazar", "MOVER"));
                directions.Add(new SemanticResultValue("quitar", "QUITAR"));
                directions.Add(new SemanticResultValue("arriba", "ARRIBA"));
                directions.Add(new SemanticResultValue("abajo", "ABAJO"));
                directions.Add(new SemanticResultValue("vision", "CAMARA")); 
                directions.Add(new SemanticResultValue("camara", "CAMARA"));
                directions.Add(new SemanticResultValue("cambiar vision", "CAMARA"));
                directions.Add(new SemanticResultValue("cambiar camara", "CAMARA"));


                var gb = new GrammarBuilder { Culture = ri.Culture };
                gb.Append(directions);

                var g = new Grammar(gb);

                //****************************************************************/

                // Create a grammar from grammar definition XML file.
                //using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(Properties.Resources.SpeechGrammar)))
                //{
                //    var g = new Grammar(memoryStream);
                speechEngine.LoadGrammar(g);
                //}

                speechEngine.SpeechRecognized += SpeechEngine_SpeechRecognized;
                speechEngine.SpeechRecognitionRejected += SpeechEngine_SpeechRecognitionRejected;

                // For long recognition sessions (a few hours or more), it may be beneficial to turn off adaptation of the acoustic model. 
                // This will prevent recognition accuracy from degrading over time.
                ////speechEngine.UpdateRecognizerSetting("AdaptationOn", 0);

                speechEngine.SetInputToAudioStream(
                myKinect.AudioSource.Start(), new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            
        }

        private void SpeechEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearRecognitionHighlights()
        {
            foreach (Span span in recognitionSpans)
            {
                span.FontSize = 26;
            }
        }

        private void SpeechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            const double ConfidenceThreshold = 0.3;



            //ClearRecognitionHighlights();

            if (e.Result.Confidence >= ConfidenceThreshold)
            {
                switch (e.Result.Semantics.Value.ToString())
                {
                    case "INICIO":
                        /*Se inicia la partida y se hace una seleccion
                         * aleatoria del jugador que empieza.
                         * Se marca por tanto el jugador, se hace el primer
                         * aumento de la letra del jugador y se comienza a
                         * contar los turnos de juego.
                         */

                        //   Declararla fuera de las funciones.
                        var juega = new Random();
                        turno_juega = Convert.ToInt32(juega.Next(1,3));
                       /// timer.Start();

                        if (turno_juega == 1)
                        {
                            //J1 se muestra mas grande el nombre
                            turno_juega = Convert.ToInt32(Jugador.J1);
                            J1Span.FontSize = 30;
                            J2Span.FontSize = 24;
                            empieza = Convert.ToInt32(Jugador.J1);
                        }
                        else if (turno_juega == 2)
                        {
                            //J2 se muestra mas grande el nombre
                            turno_juega = Convert.ToInt32(Jugador.J2);
                            J2Span.FontSize = 30;
                            J1Span.FontSize = 24;
                            empieza = Convert.ToInt32(Jugador.J2);
                        }
                        
                        //Comienza el contador del numero de turnos
                        
                        Cam_J1.Visibility = Visibility.Hidden;
                        Cam_J2.Visibility = Visibility.Hidden;
                        //Desaparecen las piezas de la zona de los cementerios
                        //Aparecen las piezas en el tablero

                        break;

                    case "COMIENZO":
                        /*Empieza el turno del jugador que se indique
                         * Aparece la mano que permite la selecion de pieza
                         */

                        if (turno_juega == Convert.ToInt32(Jugador.J1))
                        {
                            Cam_J1.Visibility = Visibility.Visible;
                            J1Span.FontSize = 30;
                            
                            //Aparece la mano del J1 que se encontrara
                            //a la izquierda de la kinect
                        }
                        else if (turno_juega == Convert.ToInt32(Jugador.J2))
                        {
                            Cam_J2.Visibility = Visibility.Visible;
                            J2Span.FontSize = 30;
                            
                            //Aparece la mano del J1 que se encontrara
                            //a la derecha de la kinect
                        }

                        break;

                     case "FINAL":

                        /*Termina el turno del jugador que se indique
                         * Aparece la mano que permite la selecion de pieza
                         */
                        if (turno_juega == Convert.ToInt32(Jugador.J1))
                        {
                            Cam_J1.Visibility = Visibility.Hidden;
                            //Desaparece la mano del J1 que se encontrara
                            //a la izquierda de la kinect
                            turno_juega = Convert.ToInt32(Jugador.J2);
                            J1Span.FontSize = 24;
                            J2Span.FontSize = 30;


                            
                        }
                        else if (turno_juega == Convert.ToInt32(Jugador.J2))
                        {
                            Cam_J2.Visibility = Visibility.Hidden;
                            //Desparece la mano del J2 que se encontrara
                            //a la derecha de la kinect

                            turno_juega = Convert.ToInt32(Jugador.J1);
                            J2Span.FontSize = 24;
                            J1Span.FontSize = 30;


                            
                        }



                        break;

                    case "SELECCION":
                        /*Marca la posicion que haya justo debajo de donde estala mano
                         * con una cierta altura por encima de las piezas
                         * Hay que tener en cuenta que segun el turno de jugador que sea
                         * puede coger entre las piezas blancas o negras
                         */

                        if (turno_juega == Convert.ToInt32(Jugador.J1))
                        {
                            //Solo puede jugar con las fichas blancas
                            //Si la ficha es negra no se puede elegir
                        }
                        else if (turno_juega == Convert.ToInt32(Jugador.J2))
                        {
                            //Solo puede jugar con las fichas negras
                            //Si la ficha es blanca no se puede elegir
                        }
                        
                        break;

                    case "MOVER":
                        /*Se empieza a realizar los desplazamientos de las piezas
                         * sobre el tablero, pudiendo moverse por cualquier posicion
                         * del tablero y marcando debajo donde se puede quedar la pieza
                         */

                        if (turno_juega == Convert.ToInt32(Jugador.J1))
                        {
                            //Permite el movimiento de las fichas blancas teniendo en cuenta
                            //si donde se va a colocar esta ocupado por una ficha blanca o negra
                            //Si es blanca no permite el movimiento
                            //Si es negra, eliminar la pieza y aparece en el cementerio
                            //del jugador contrario

                        }
                        else if (turno_juega == Convert.ToInt32(Jugador.J2))
                        {
                            //Permite el movimiento de las fichas negras teniendo en cuenta
                            //si donde se va a colocar esta ocupado por una ficha blanca o negra
                            //Si es negra no permite el movimiento
                            //Si es blanca, eliminar la pieza y aparece en el cementerio
                            //del jugador contrario
                        }

                        break;

                    case "QUITAR":
                        /*Quitala la seleccion que tenga hecha de la ficha del jugador correspondiente
                         * y la ficha vuelve a su posicion original
                         */
                        if (turno_juega == Convert.ToInt32(Jugador.J1))
                        {
                            //Devuelve la pieza blanca a su posicion de origen    

                        }
                        else if (turno_juega == Convert.ToInt32(Jugador.J2))
                        {
                            //Devuelve la pieza negra a su posicion de origen
                        }

                        break;
                    case "CAMARA":
                        /*Permite el cambio de la vision de la camara que enfoca al tablero
                         */
                        if (cam == Convert.ToInt32(Camara.CAM1))
                        {
                            cam = Convert.ToInt32(Camara.CAM2);
                            //Vision de la camara 2 (Desde arriba del tablero, Se veria todo en semi 3D)

                         }
                        else if (cam == Convert.ToInt32(Camara.CAM2))
                        {
                            cam = Convert.ToInt32(Camara.CAM3);
                            //Vision de la camara 3 (Desde detras de cada jugador)

                        }
                        else if (cam == Convert.ToInt32(Camara.CAM3))
                        {
                            cam = Convert.ToInt32(Camara.CAM1);
                            //Vision de la camara 1 (Lateral del tablero)

                        }

                        break;

                    case "ARRIBA":
                        //Sube el angulo de la kinect en 5º
                        this.myKinect.ElevationAngle += 5;
                        break;

                    case "ABAJO":
                        //Baja el angulo de la kinect en 5º
                        this.myKinect.ElevationAngle += -5;
                        break;

                    default:
                        break;
                }
            }
        }

        private void MyKinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame == null) return;

                byte[] colorData = new byte[colorFrame.PixelDataLength];
                colorFrame.CopyPixelDataTo(colorData);
                Cam_J1.Source = BitmapSource.Create(
                                        colorFrame.Width, colorFrame.Height,
                                        96, 96,
                                        PixelFormats.Bgr32,
                                        null,
                                        colorData,
                                        colorFrame.Width * colorFrame.BytesPerPixel);
                Cam_J2.Source = BitmapSource.Create(
                                        colorFrame.Width, colorFrame.Height,
                                        96, 96,
                                        PixelFormats.Bgr32,
                                        null,
                                        colorData,
                                        colorFrame.Width * colorFrame.BytesPerPixel);
                Tablero.Source = BitmapSource.Create(
                                        colorFrame.Width, colorFrame.Height,
                                        500, 500,
                                        PixelFormats.Bgr32,
                                        null,
                                        colorData,
                                        colorFrame.Width * colorFrame.BytesPerPixel);
                Cementerio_J1.Source = BitmapSource.Create(
                                        colorFrame.Width, colorFrame.Height,
                                        300, 100,
                                        PixelFormats.Bgr32,
                                        null,
                                        colorData,
                                        colorFrame.Width * colorFrame.BytesPerPixel);
                Cementerio_J2.Source = BitmapSource.Create(
                                        colorFrame.Width, colorFrame.Height,
                                        300, 100,
                                        PixelFormats.Bgr32,
                                        null,
                                        colorData,
                                        colorFrame.Width * colorFrame.BytesPerPixel);
            }
        }



    }
}
