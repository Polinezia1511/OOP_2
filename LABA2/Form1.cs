using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA2
{
    public partial class Form1 : Form
    {
        bool drawing = false;
        List<Shape> shapesList = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {    //Передаются аргументы(е) для нажатия на кнопку мыши и передачи координат, создается точка для нового объекта
            drawing = true;
            shapesList.Last().setFirstPoint(new PointF(e.X, e.Y));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        { //Когда двигается мышка, за ней остается след из фигуры. При каждом движении е обновляется, устанавливается новая точка.
            if (drawing)
            {
                shapesList.Last().setLastPoint(new PointF(e.X, e.Y));
            }

            pictureBox1.Invalidate();

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        { // Запрещаем дальнейшее рисование фигуры, когда отпускается кнопка мыши
            drawing = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Активирует форму для рисования при нажатии на нее(на кнопку)
            pictureBox1.Enabled = false;
            shapesList.Add(new Line());
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Drawer drawer = new Drawer();
            Graphics gr1 = e.Graphics;
            drawer.SetGraphics(gr1);
            foreach (var i in shapesList)
            {
                i.OnChanged();
                drawer.DrawShape(i);
            }
            pictureBox1.Invalidate();
        }
    }
}
