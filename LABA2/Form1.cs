using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using Interfases;
using System.Linq;
using System.Xml.Linq;

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

            UpdatePlugins();
            UpdateFabric();

            try
            {
                XDocument xdoc = XDocument.Load("saveConfig.xml");
                string theme = "-1";

                foreach (XElement element in xdoc.Element("configurations").Elements("config"))
                {
                    theme = element.Element("theme").Value;
                }
                cmb_themes.SelectedIndex = currentTheme = Convert.ToInt32(theme, 10);
                configIsChange = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethings wrong...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        private void UpdatePlugins()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(pluginPath);//создаёт папку,если ее нет 
                if (!directory.Exists)
                {
                    directory.Create();
                }

                var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");//получает файлы по этому пути формата длл

                foreach(var file in pluginFiles)
                {
                    Assembly asm = Assembly.LoadFrom(file);//для длл файла
                    var types = asm.GetTypes().
                        Where(t => t.GetInterfaces().
                        Where(i => i.FullName == typeof(IShape).FullName).Any());

                    foreach (var type in types)
                    {
                        cmb_choise.Items.Add(type.Name);
                    }
                }
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateFabric()
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(pluginPath);
                if (!directory.Exists)
                {
                    directory.Create();
                }

                var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

                foreach (var file in pluginFiles)
                {
                    Assembly asm = Assembly.LoadFrom(file);
                    var types = asm.GetTypes().
                        Where(t => t.GetInterfaces().
                        Where(i => i.FullName == typeof(IFabric).FullName).Any());

                    foreach (var type in types)
                    {
                        fabricList.Add((Fabric)Activator.CreateInstance(type));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private Shape shape = null;

        private Point start;
        private Image orig; 
         
        private Fabric fabric = null;
        Pen pen = new Pen(Color.LightPink, 2);

        public List<Fabric> FabricList { get => FabricList1; set => FabricList1 = value; }
        public List<Fabric> FabricList1 { get => fabricList; set => fabricList = value; }
        public List<Fabric> FabricList2 { get => fabricList; set => fabricList = value; }

        private void cmb_choise_SelectionChangeCommitted(object sender, EventArgs e)
        { 
            fabric = FabricList[cmb_choise.SelectedIndex];
            /*switch (cmb_choise.SelectedIndex)
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
                
            }*/
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
                try
                {
                    using (StreamReader stream = new StreamReader(open.OpenFile()))
                    {
                        string data = stream.ReadToEnd();
                        {
                            string[] dataArray = data.Split('\n');
                            foreach (string dataBlock in dataArray)
                            {
                                //JsonConvert - convertor, DeserializeObject<IFJ> - deserialization into type in brackets, datablock - JSON, which is read
                                InfoForJSON json = JsonConvert.DeserializeObject<InfoForJSON>(dataBlock);
                                foreach (Fabric fab in FabricList)
                                {
                                    //checking of existing of fabricmethod
                                    if (json.figureName == fab.ToString())
                                    {
                                        JsonInfoList.Add(json);
                                        shape = fab.FactoryMethod(new Pen(json.color, json.width));
                                        shape.Draw(Graphics.FromImage(bm), json.topLeft, json.bottomRight);
                                        pictureBox1.Image = bm;
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            JsonInfoList.Clear();
            pictureBox1.Image = bm;
        }

        private void ChangeTheme(string config)
        {
            /*XDocument xdoc = new XDocument();
            XElement configurations = new XElement("configurations");

            //cmb_choise
            XElement choise = new XElement("element");
            XAttribute choiseAttr = new XAttribute("name", "cmb_choise");
            XElement colorChoise = new XElement("color", cmb_choise.BackColor.ToArgb());
            choise.Add(choiseAttr);
            choise.Add(colorChoise);
            configurations.Add(choise);

            //cmb_themes
            XElement themes = new XElement("element");
            XAttribute themesAttr = new XAttribute("name", "cmb_themes");
            XElement themesChoise = new XElement("color", cmb_themes.BackColor.ToArgb());
            themes.Add(themesAttr);
            themes.Add(themesChoise);
            configurations.Add(themes);

            //btn_clear
            XElement clear = new XElement("element");
            XAttribute clearAttr = new XAttribute("name", "clear_btn");
            XElement clearChoise = new XElement("color", clear_btn.BackColor.ToArgb());
            clear.Add(clearAttr);
            clear.Add(clearChoise);
            configurations.Add(clear);

            //open_btn
            XElement open = new XElement("element");
            XAttribute openAttr = new XAttribute("name", "open_btn");
            XElement openChoise = new XElement("color", open_btn.BackColor.ToArgb());
            open.Add(openAttr);
            open.Add(openChoise);
            configurations.Add(open);

            //save_btn
            XElement save = new XElement("element");
            XAttribute saveAttr = new XAttribute("name", "save_btn");
            XElement saveChoise = new XElement("color", save_btn.BackColor.ToArgb());
            save.Add(saveAttr);
            save.Add(saveChoise);
            configurations.Add(save);

            //form_background
            XElement form = new XElement("element");
            XAttribute formAttr = new XAttribute("name", "this");
            XElement formChoise = new XElement("color", this.BackColor.ToArgb());
            form.Add(formAttr);
            form.Add(formChoise);
            configurations.Add(form);

            xdoc.Add(configurations);


            xdoc.Save(config);*/

            try
            {
                Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();

                XDocument xdoc = XDocument.Load(config);
                foreach (XElement element in xdoc.Element("configurations").Elements("element"))
                {
                    XAttribute nameAttribute = element.Attribute("name");
                    XElement colorElement = element.Element("color");

                    if (nameAttribute != null && colorElement != null && element != null)
                    {
                        keyValuePairs.Add(nameAttribute.Value, Convert.ToInt32(colorElement.Value, 10));
                    }

                }

                foreach(Control c in this.Controls)
                {
                    if (keyValuePairs.ContainsKey(c.Name))
                    {
                        c.BackColor = Color.FromArgb(keyValuePairs[c.Name]);
                    }
                }

                if (keyValuePairs.ContainsKey("this"))
                {
                    this.BackColor = Color.FromArgb(keyValuePairs["this"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmb_themes_SelectedIndexChanged(object sender, EventArgs e)
        {
            configIsChange = true;
            if(cmb_themes.SelectedIndex == 0)
            {
                ChangeTheme("DarkConfig.xml");
            }
            else
            {
                ChangeTheme("LightConfig.xml");
            }

            currentTheme = cmb_themes.SelectedIndex;
        }

        private bool configIsChange = false;
        private int currentTheme = 0;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (configIsChange)
            {
                DialogResult result = MessageBox.Show("Do you want to save theme?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    XDocument xdoc = new XDocument(new XElement("configurations",
                        new XElement("config",
                            new XAttribute("name", "userConfig"),
                            new XElement("theme", currentTheme)))
                        );
                    xdoc.Save("saveConfig.xml");
                }
            }
        }
    }
}
