using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using hehexd.Shapes;
using hehexd.composite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace hehexd.SaveFile
{
    public class Save
    {
        List<IComponent> c = new List<IComponent>();
        string Type;
        double Left;
        double Top;
        double Width;
        double Height;
        string filename;

        public List<UIElement> LoadFile()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
            }
            bool shape = true;
            List<UIElement> list = new List<UIElement>();
            StreamReader sr = new StreamReader(filename);
            List<string> lines = new List<string>();
            Ellipse ellipse = new Ellipse() { Width = Width, Height = Height, Fill = Brushes.Black, };
            Rectangle rectangle = new Rectangle() { Width = Width, Height = Height, Fill = Brushes.Black, };
            string line;
            while ((line = sr.ReadLine()) != null) {lines.Add(line);}
            foreach(string l in lines)
            {
                String[] sp = l.Split(' ');
                Left = Convert.ToDouble(sp[1]);
                Top = Convert.ToDouble(sp[2]);
                Width = Convert.ToDouble(sp[3]);
                Height = Convert.ToDouble(sp[4]);
                if (sp[0] == "rectangle")
                {
                    rectangle = new Rectangle() { Width = Width, Height = Height, Fill = Brushes.Black, };
                    Canvas.SetLeft(rectangle, Left);
                    Canvas.SetTop(rectangle, Top);
                    shape = true;
                }
                else if(sp[0] =="ellipse")
                {
                    ellipse = new Ellipse() { Width = Width, Height = Height, Fill = Brushes.Black, };
                    Canvas.SetLeft(ellipse, Left);
                    Canvas.SetTop(ellipse, Top);
                    shape = false;
                }
                Canvas.SetLeft(ellipse, Left);
                Canvas.SetTop(ellipse, Top);
                if (shape) { list.Add(rectangle); }
                else { list.Add(ellipse); }
            }
            sr.Close();
            return list;
        }

        public void FileSave(UIElement u)
        {
            StreamWriter sw = new StreamWriter(@"C:\Users\lhmbe\Desktop\save.txt", true);
            UIElement Child = u;
                if (Child.ToString().Contains("Rectangle")) { Type = "rectangle"; }
                else if (Child.ToString().Contains("Ellipse")) { Type = "ellipse"; }
                Left = Convert.ToDouble(Child.GetValue(Canvas.LeftProperty));
                Top = Convert.ToDouble(Child.GetValue(Canvas.TopProperty));
                Width = Convert.ToDouble(Child.GetValue(Canvas.WidthProperty));
                Height = Convert.ToDouble(Child.GetValue(Canvas.HeightProperty));
                sw.WriteLine(Type + " " + Left + " " + Top + " " + Width + " " + Height);
            sw.Close();
        }
    }
}
