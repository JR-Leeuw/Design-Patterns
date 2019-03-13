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
        public enum MyShape
        {
            Line, Ellipse, Rectangle, Selecter, Deleter, Drag, Resize
        }

        private MyShape currShape = MyShape.Line;
        private MyShape lastShape;
        Point start;
        Point end;
        int currentobj = -1;
        bool move = false;
        double posz = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Line;
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Ellipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Rectangle;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Selecter;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Deleter;
        }

        private void DragButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Drag;
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Resize;
        }

        private void Shapeprinter()
        {
            switch (currShape)
            {
                case MyShape.Line:
                    DrawLine();
                    break;
                case MyShape.Ellipse:
                    DrawEllipse(Brushes.Black, Brushes.White, 4, "m", 0);
                    break;
                case MyShape.Rectangle:
                    DrawRectangle(Brushes.Black, Brushes.White, 4, "m", 0);
                    break;
                case MyShape.Selecter:
                    Select("sel");
                    break;
                case MyShape.Deleter:
                    Select("del");
                    break;
                case MyShape.Drag:
                    break;
                case MyShape.Resize:
                    Resize();
                    break;
                default:
                    return;
            }
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
            currentobj = -1;
            move = false;
            lastShape = MyShape.Drag;
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lastShape == MyShape.Rectangle && currShape == MyShape.Rectangle || lastShape == MyShape.Ellipse && currShape == MyShape.Ellipse)
            {
                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
            }
            Shapeprinter();
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.GetPosition(this) != end && e.LeftButton == MouseButtonState.Pressed)
            {
                if (currShape != MyShape.Drag)
                {
                    end = e.GetPosition(this);
                    ShapeUpdate();
                    Shapeprinter();
                }
                else
                {
                    end = e.GetPosition(this);
                    Drag();
                    Shapeprinter();
                }
            }
        }

        private void ShapeUpdate()
        {
            if (MyCanvas.Children.Count > 0 && currShape != MyShape.Deleter && currShape != MyShape.Selecter && lastShape != MyShape.Selecter && lastShape != MyShape.Drag)
            {
                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
            }
        }

        private void Remove(UIElement child)
        {
            MyCanvas.Children.Remove(child);
        }

        private void Drag()
        {
            for (int i = MyCanvas.Children.Count - 1; i > -1; i--)
            {
                var child = MyCanvas.Children[i];
                double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
                double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                double posz = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                var size = child.RenderSize;
                double hight = size.Height;
                double width = size.Width;
                double xfield = posx + width;
                double yfield = posy + hight;

                if ((start.X > posx && start.X < xfield && start.Y - 50 > posy && start.Y - 50 < yfield && move == false) || currentobj == i && move == true)
                {
                    currentobj = i;
                    move = true;
                    double nposx = (start.X - end.X);
                    double nposy = (start.Y - end.Y);
                    child.SetValue(Canvas.LeftProperty, posx - nposx);
                    child.SetValue(Canvas.TopProperty, posy - nposy);
                    //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
                    start = end;
                    lastShape = MyShape.Drag;
                }
            }
        }

        private void Resize()
        {
            for (int i = MyCanvas.Children.Count - 1; i > -1; i--)
            {
                var child = MyCanvas.Children[i];
                double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
                double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                double posz = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                var size = child.RenderSize;
                double hight = size.Height;
                double width = size.Width;
                double xfield = posx + width;
                double yfield = posy + hight;

                if ((start.X > posx && start.X < xfield && start.Y - 50 > posy && start.Y - 50 < yfield && move == false) || currentobj == i && move == true)
                {
                    var m = Mouse.GetPosition(child);
                    currentobj = i;
                    move = true;
                    double nposx = (start.X - end.X);
                    double nposy = (start.Y - end.Y);
                    double widthprop = (posx - nposx) + posx;
                    double heightprop = (posy - nposy) + posy;
                    if (widthprop > 0 && heightprop > 0)
                    {
                        child.SetValue(Canvas.WidthProperty, widthprop);
                        child.SetValue(Canvas.HeightProperty, heightprop);
                    }
                    //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
                    //start = end;
                    //lastShape = MyShape.Resize;
                }
            }
        }

        private void Select(string msg)
        {
            {
                for (int i = MyCanvas.Children.Count - 1; i > -1; i--)
                {
                    var child = MyCanvas.Children[i];
                    string type = child.GetType().Name;
                    double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
                    double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                    var size = child.RenderSize;
                    double hight = size.Height;
                    double width = size.Width;
                    double xfield = posx + width;
                    double yfield = posy + hight;

                    if (start.X > posx && start.X < xfield && start.Y - 50 > posy && start.Y - 50 < yfield)
                    {
                        if (msg == "sel")
                        {
                            Remove(child);
                            start.X = posx; start.Y = posy + 50; end.X = xfield; end.Y = yfield + 50;
                            if (type == "Rectangle")
                                DrawRectangle(Brushes.Red, Brushes.Blue, 4, "g", i);
                            else
                                DrawEllipse(Brushes.Red, Brushes.Blue, 4, "g", i);
                            //ShapeUpdate();
                            Shapeprinter();
                            lastShape = currShape;
                        }

                        else if (msg == "del")
                        {
                            Remove(child);
                            lastShape = currShape;
                        }
                        break;
                    }
                }
            }
        }

        private void DrawLine()
        {
            Line newLine = new Line()
            {
                Stroke = Brushes.Black,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };
            MyCanvas.Children.Add(newLine);
            lastShape = currShape;
        }

        private void DrawEllipse(SolidColorBrush S, SolidColorBrush F, int ST, string type, int i)
        {
            Ellipse newEllipse = new Ellipse()
            {
                Fill = S,
                Stroke = F,
                StrokeThickness = ST
            };

            if (end.X >= start.X)
            {
                newEllipse.SetValue(Canvas.LeftProperty, start.X);
                newEllipse.Width = end.X - start.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, end.X);
                newEllipse.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                newEllipse.SetValue(Canvas.TopProperty, start.Y - 50);
                newEllipse.Height = end.Y - start.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, end.Y - 50);
                newEllipse.Height = start.Y - end.Y;
            }
            if (type == "g")
            {
                MyCanvas.Children.Insert(i, newEllipse);
            }
            else
            {
                MyCanvas.Children.Add(newEllipse);
                posz = Convert.ToDouble(newEllipse.GetValue(Canvas.LeftProperty));
            }
            lastShape = currShape;
        }


        private void DrawRectangle(SolidColorBrush S, SolidColorBrush F, int ST, string type, int i)
        {
            Rectangle newRectangle = new Rectangle()
            {
                Fill = S,
                Stroke = F,
                StrokeThickness = ST
            };

            if (end.X >= start.X)
            {
                newRectangle.SetValue(Canvas.LeftProperty, start.X);
                newRectangle.Width = end.X - start.X;
            }
            else
            {
                newRectangle.SetValue(Canvas.LeftProperty, end.X);
                newRectangle.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                newRectangle.SetValue(Canvas.TopProperty, start.Y - 50);
                newRectangle.Height = end.Y - start.Y;
            }
            else
            {
                newRectangle.SetValue(Canvas.TopProperty, end.Y - 50);
                newRectangle.Height = start.Y - end.Y;
            }
            if (type == "g")
            {
                MyCanvas.Children.Insert(i, newRectangle);
            }
            else
            {
                MyCanvas.Children.Add(newRectangle);
                posz = Convert.ToDouble(newRectangle.GetValue(Canvas.LeftProperty));
            }
            lastShape = currShape;
        }
    }
}
