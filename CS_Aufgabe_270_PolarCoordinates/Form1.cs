using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Aufgabe_270_PolarCoordinates
{
    /*
     * 1. Polarkoordinatensystem

Zuerst geht es darum ein Polarkoordinatensystem (auch als Kreiskoordinatensystem bekannt) zu zeichnen.
Der Ursprung des Koordinatensystems befindet sich im Zentrum der Zeichenfläche.

- Die X-Achse verläuft horizontal durch den Ursprung, die Y-Achse vertikal.
- Jede Längeneinheit soll von einem Kreis geschnitten werden, also jeweils bei X(n) und Y(n). Der Kreismittelpunkt befindet sich dementsprechend im Ursprung des Koordinatensystems.
- Des Weiteren soll alle 22,5° eine Linie vom Ursprung aus gezogen werden (dies sind insg. 16 Linien, damit sind auch die X- als auch die Y-Achse abgedeckt!).

Wenn ihr das geschafft habt, sollte das ca. so aussehen Beispiel Polarkoordinatensystem (Hier allerdings mit 30°-Schritten anstatt mit 22,5°)
Auf die Gradangaben kann verzichtet werden.
Zudem solltet ihr dezente Farben für das Koordinatensystem wählen.

2. Muster

Für das Muster sollt ihr nun Punkte in diesem Koordinatensystem einzeichnen.
Diese ergeben das Muster je nach Punktanzahl und Zoom.

Ein jeder dieser Punkte hat folgende Eigenschaften:
- Die X-Koordinate ist die Entfernung vom Koordinatenursprung (= der Radius)
- Die Y-Koordinate ist das Bogenmaß.

Jeder Punkt soll die gleiche Zahl für X und Y eingesetzt bekommen.
D.h. Punkt p: pX(n) und pY(n)
Hier ergibt sich jedoch eine Schwierigkeit für Y.
Der Wert der Y-Koordinate n ist das Bogenmaß und muss dementsprechend noch in eine Gradzahl konvertiert werden.
Ein Beispiel:
X = 3
Y = 3 (bzw. ~172°)

Ihr sollt das nun Punkte für 0 < n <= 100 auf diesem Koordinatensystem einzeichnen.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 500;
            Height = 500;
            BackColor = Color.White;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;             
            
            DrawLines(g,22.5f,1000.0f,Width/2.0f,Height/2.0f);
            DrawCircles(g, 16.0f);
            DrawAxes(g);
            DrawSpiral(g);
        }

        private void DrawSpiral(Graphics g)
        {
            // skalieren spiegeln verschieben
            Point[] spiral = new Point[100];

            List<double> spX = new List<double>();
            List<double> spY = new List<double>();
            
            for (int i = 0; i < 100; i++)
            {
                float j = i * 180.0f / (float)Math.PI;
                spX.Add(j * Math.Cos(j));
                spY.Add(j * Math.Sin(j));
                
            }

            float ScaleX = Width / ((float)spX.Max()-(float)spX.Min());
            float ScaleY = Height /( (float)spY.Max()- (float)spY.Min());


            for (int i = 0; i < 100; i++)
            {
                spiral[i] = new Point(
                    Convert.ToInt32(spX[i]*ScaleX+ Width / 2.0f), 
                    Convert.ToInt32(-(int)spY[i]*ScaleY + Height / 2.0f)
                    );

            }

            // Archimedean spiral
            g.DrawCurve(Pens.Red, spiral);
        }

        private void DrawCircles(Graphics g, float interval)
        {
            for (int i = 0; i < 2 * (int)interval; i++)
            {
                g.DrawEllipse(Pens.LightGray,
                    Width / 2.0f - i * Width / 2.0f / interval,
                    Height / 2.0f - i * Height / 2.0f / interval,
                    i * Width / interval,
                    i * Height / interval);
            }
            
        }

        private void DrawLines(Graphics g, float angle, float length, float startX, float startY)
        {
            if (360.0 % angle != 0)
                throw new ArgumentException("360 mod angle <> 0!!");

            float nrays = 360 / angle;            

            for (int i = 0; i < (int)nrays; i++)
            {
                double x = startX + Math.Cos(i*angle * Math.PI / 180.0) * length;
                double y = startY + Math.Sin(i*angle * Math.PI / 180.0) * length;

                g.DrawLine(Pens.LightGray, startX, startY, (float)x, (float)y);
            }
            
        }

        private void DrawAxes(Graphics g)
        {
            g.DrawLine(Pens.Black, Width / 2.0f, 0.0f, Width / 2.0f, Height);
            g.DrawLine(Pens.Black, 0.0f, Height/2.0f, Width, Height / 2.0f);
        }
    }
}
