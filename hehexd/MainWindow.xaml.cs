using hehexd.Tools;
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

namespace hehexd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private AbstractTool activeTool = new RectangleTool();
        string tool = "";
        private DrawingCanvas drawingCanvas;
        Point start;
        Point end;

        public MainWindow()
        {
            InitializeComponent();
            drawingCanvas = new DrawingCanvas(MyCanvas);
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new EllipseTool());
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            tool = "";
            drawingCanvas.SetActiveTool(new RectangleTool());       // repeat naar boeven en beneden met goede tools
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DragButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new DragTool());
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new ResizeTool());
        }


        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(MyCanvas);
            end = e.GetPosition(MyCanvas);
            drawingCanvas.mouseEnter(end);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            drawingCanvas.mouseOther(start, e.GetPosition(MyCanvas), false);
            end = new Point(-1, -1);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {         
            if (e.GetPosition(MyCanvas) != end && e.LeftButton == MouseButtonState.Pressed)
            {
                string s = activeTool.ToString();
                //if (tool == "b")
                //{
                //    drawingCanvas.mouseEnter(start);
                //}
                end = e.GetPosition(MyCanvas);
                drawingCanvas.mouseOther(start, end, true);
                start = end;
            } 
        }

        //private void Remove(UIElement child)
        //{
        //    MyCanvas.Children.Remove(child);
        //}

        //private void Resize()
        //{
        //    for (int i = MyCanvas.Children.Count - 1; i > -1; i--)
        //    {
        //        var child = MyCanvas.Children[i];
        //        double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
        //        double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
        //        double posz = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
        //        var size = child.RenderSize;
        //        double hight = size.Height;
        //        double width = size.Width;
        //        double xfield = posx + width;
        //        double yfield = posy + hight;

            //    if ((start.X > posx && start.X < xfield && start.Y - 50 > posy && start.Y - 50 < yfield && move == false) || currentobj == i && move == true)
            //    {
            //        var m = Mouse.GetPosition(child);
            //        double nposx = (start.X - end.X);
            //        double nposy = (start.Y - end.Y);
            //        double widthprop = (posx - nposx) + posx;
            //        double heightprop = (posy - nposy) + posy;
            //        if (widthprop > 0 && heightprop > 0)
            //        {
            //            child.SetValue(Canvas.WidthProperty, widthprop);
            //            child.SetValue(Canvas.HeightProperty, heightprop);
            //        }
            //        //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
            //        //start = end;
            //        //lastShape = MyShape.Resize;
            //    }
        //}

        //private void Select(string msg)
        //{
        //    {
        //        for (int i = MyCanvas.Children.Count - 1; i > -1; i--)
        //        {
        //            var child = MyCanvas.Children[i];
        //            string type = child.GetType().Name;
        //            double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
        //            double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
        //            var size = child.RenderSize;
        //            double hight = size.Height;
        //            double width = size.Width;
        //            double xfield = posx + width;
        //            double yfield = posy + hight;

        //            //if (start.X > posx && start.X < xfield && start.Y - 50 > posy && start.Y - 50 < yfield)
        //            //{
        //            //    if (msg == "sel")
        //            //    {
        //            //        Remove(child);
        //            //        start.X = posx; start.Y = posy + 50; end.X = xfield; end.Y = yfield + 50;
        //            //        if (type == "Rectangle")
        //            //            DrawRectangle(Brushes.Red, Brushes.Blue, 4, "g", i);
        //            //        else
        //            //            DrawEllipse(Brushes.Red, Brushes.Blue, 4, "g", i);
        //            //        //ShapeUpdate();
        //            //        Shapeprinter();
        //            //        lastShape = currShape;
        //            //    }

        //            //    else if (msg == "del")
        //            //    {
        //            //        Remove(child);
        //            //        lastShape = currShape;
        //            //    }
        //            //    break;
        //            //}
        //        }
        //    }
        //}

        //private void DrawLine()
        //{
        //    Line newLine = new Line()
        //    {
        //        Stroke = Brushes.Black,
        //        X1 = start.X,
        //        Y1 = start.Y - 50,
        //        X2 = end.X,
        //        Y2 = end.Y - 50
        //    };
        //    MyCanvas.Children.Add(newLine);
        //    //lastShape = currShape;
        //}
    }
}
