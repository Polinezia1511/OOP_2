using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private List<InfoForJSON> JsonInfoList = new List<InfoForJSON>();


        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                var finish = new Point(e.X, e.Y);
                var g = Graphics.FromImage(bm); 
                shape.Draw(g, start, finish); 
                g.Save(); 
                g.Dispose();
                pictureBox1.Invalidate();
                drawing = false;
                JsonInfoList.Add(new InfoForJSON() { width = pen.Width, color = pen.Color, topLeft = start, bottomRight = finish, figureName = fabric.ToString() });
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
                GC.Collect();//Garbich
            }
        }



        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = ".";
            save.RestoreDirectory = true;
            save.FileName = "saving";
            save.DefaultExt = ".json";

            if(save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter stream = new StreamWriter(save.OpenFile()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    using (JsonWriter writer = new JsonTextWriter(stream))
                    {
                        for(int i = 0; i < JsonInfoList.Count; i++)
                        {
                            serializer.Serialize(writer, JsonInfoList[i]);
                            if(i != JsonInfoList.Count - 1)
                            {
                                stream.Write('\n');
                            }
                        }
                    }
                }
            }
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.InitialDirectory = "/files";
            open.RestoreDirectory = true;
            open.FileName = "saving";
            open.DefaultExt = ".json";

            if(open.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(open.OpenFile());
                string data = stream.ReadToEnd();
                {
                    string[] dataArray = data.Split('\n');
                    foreach(string dataBlock in dataArray)
                    {
                        try
                        {
                            InfoForJSON json = JsonConvert.DeserializeObject<InfoForJSON>(dataBlock);
                            foreach(Fabric fab in FabricList)
                            {
                                if(json.figureName == fab.ToString())
                                {
                                    JsonInfoList.Add(json);
                                    Fabric fabric = fab;
                                    shape = fabric.FactoryMethod(new Pen(json.color, json.width));
                                    shape.Draw(Graphics.FromImage(bm), json.topLeft, json.bottomRight);
                                    pictureBox1.Image = bm;
                                    break;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Some problems...", "Some", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                    }
                }
            }
        }
    }
}
