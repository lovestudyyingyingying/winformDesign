using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WinForm.MoveControl.Demo
{
    public class ControlManager
    {
        public PropertyGrid propertyGrid;
        public void GetContorl(Panel panel1)
        {
            ContorlDatasXml.Instance.Read();

            var con = ContorlDatasXml.Instance.ContorlDatasXmls;
            foreach (var item in con)
            {
                Control control = new Control();
                string typeStr = item.Type;
                string controlName = "Sunny.UI." + typeStr;
                Assembly winFormsAssembly = typeof(UIButton).Assembly;
                Type type = winFormsAssembly.GetType(controlName);
                // Type test = Type.GetType(controlName);
                if (type == null)
                    return;
                control = (Control)Activator.CreateInstance(type);
                control.Name = item.Name;
                control.Text = item.Text;
                control.Location = item.Location;
                control.Size = item.Size;
                control.ForeColor = System.Drawing.ColorTranslator.FromHtml(item.ForeColor);
                control.BackColor = System.Drawing.ColorTranslator.FromHtml(item.BackColor);
                panel1.Controls.Add(control);
            }
        }
        public void SaveContorl(Panel panel1)
        {
            ContorlDatasXml.Instance.Save(panel1.Controls);
        }
    }
    [Serializable]

    public class ContorlDatasXml
    {
        public List<ContorlData> ContorlDatasXmls = new List<ContorlData>();
        private static ContorlDatasXml instance = new ContorlDatasXml();

        public static ContorlDatasXml Instance
        {
            get
            {
                return instance;
            }
            set { instance = value; }
        }
        public void Save(Control.ControlCollection controls)
        {
            ContorlDatasXmls.Clear();
            foreach (Control control in controls)
            {
                if (control is FrameControl)
                    continue;
                ContorlData contorlData = new ContorlData();
                contorlData.Name = control.Name;
                contorlData.Location = control.Location;
                contorlData.Size = control.Size;
                contorlData.Type = control.GetType().Name.ToString();
                contorlData.Text = control.Text;
                contorlData.BackColor = System.Drawing.ColorTranslator.ToHtml(control.BackColor);
                contorlData.ForeColor = System.Drawing.ColorTranslator.ToHtml(control.ForeColor);
                ContorlDatasXmls.Add(contorlData);
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(GetType());
                string content = string.Empty;
                //serialize
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, this);
                    content = writer.ToString();
                }
                //save to file
                using (StreamWriter stream_writer = new StreamWriter("ContorlDatasXml.xml"))
                {
                    stream_writer.Write(content);
                }
                Console.WriteLine("配置文件保存成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("配置文件序列化文件失败:" + ex.Message);
            }
        }

        public void Read()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(GetType());
                using (StreamReader reader = new StreamReader("ContorlDatasXml.xml"))
                {
                    Instance = (ContorlDatasXml)serializer.Deserialize(reader);
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
    [Serializable]
    public class ContorlData
    {
        public string Name { get; set; }

        public string Text { get; set; }
        public Point Location { get; set; }

        public Size Size { get; set; }

        public string Type { get; set; }

        public string BackColor { get; set; }

        public string ForeColor { get; set; }
    }
}
