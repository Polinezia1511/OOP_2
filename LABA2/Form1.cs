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
        List<Fabric> fabricList = new List<Fabric>() {
            new EllipseFabric(),
            new LineFabric(),
            new RectangleFabric(),
            new SquareFabric(),
            //new TriangleFabric()
        };

        public Bitmap bm;
        public Bitmap bmTemp;
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmTemp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private Shape shape = null;

        private Point start;
        private Image orig; 
         
        private Fabric fabric = null;
        Pen pen = null;

        public List<Fabric> FabricList { get => FabricList1; set => FabricList1 = value; }
        public List<Fabric> FabricList1 { get => fabricList; set => fabricList = value; }
        public List<Fabric> FabricList2 { get => fabricList; set => fabricList = value; }

        private void cmb_choise_SelectionChangeCommitted(object sender, EventArgs e)
        { 
            fabric = FabricList[cmb_choise.SelectedIndex];
            switch (cmb_choise.SelectedIndex)
            {
                case 0:
                    {
                        pen = new Pen(Color.LightPink, 4);
                        break;
                    }
                case 1:
                    {
                        pen = new Pen(Color.Olive, 3);
                        break;
                    }
                case 2:
                    {
                        pen = new Pen(Color.DarkRed, 2);
                        break;
                    }
                case 3:
                    {
                        pen = new Pen(Color.PeachPuff, 2);
                        break;
                    }
            }
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (fabric != null)
            {
                start = new Point(e.X, e.Y);
                drawing = true;
                shape = fabric.FactoryMethod(pen);
                orig = bm;
            }

        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                var finish = new Point(e.X, e.Y);
                var g = Graphics.FromImage(bm); 
                shape.Draw(g, start, finish); ;
                g.Save(); 
                g.Dispose();
                pictureBox1.Invalidate();
                drawing = false;
            }
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                var finish = new Point(e.X, e.Y);
                bmTemp = new Bitmap(bm); ///то, на чем мы сейчас рисуем
                pictureBox1.Image = bmTemp; 
                var g = Graphics.FromImage(bmTemp);
                shape.Draw(g, start, finish);
                g.Dispose();
                pictureBox1.Invalidate();
            }
        }

       
    }
}
