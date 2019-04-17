using hehexd.Tools;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static RoutedCommand MyCommand = new RoutedCommand();

        private AbstractTool activeTool = new RectangleTool();
        string tool = "";
        private DrawingCanvas drawingCanvas = DrawingCanvas.getinstance();
        Point start;
        Point end;

        public MainWindow()
        {
            InitializeComponent();
            drawingCanvas.setCanvas(MyCanvas);
        }

        public void hotkeys(RoutedCommand r)
        {
            RoutedCommand command = new RoutedCommand();
            command.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));
            command.InputGestures.Add(new KeyGesture(Key.Z, ModifierKeys.Control));
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
            drawingCanvas.SetActiveTool(new PaintTool());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new DeleteTool());
        }

        private void DragButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new DragTool());
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            drawingCanvas.SetActiveTool(new ResizeTool());
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        { 
            if (e.Key == Key.Z){ drawingCanvas.Undo(); }

            if (e.Key == Key.Y) { drawingCanvas.Redo(); }

            if (e.Key == Key.S)
            {
                File.Create(@"C:\Users\lhmbe\Desktop\save.txt").Close();
                drawingCanvas.Save();
            }

            if (e.Key == Key.L) { drawingCanvas.Load(); }
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
                //string s = activeTool.ToString();
                end = e.GetPosition(MyCanvas);
                drawingCanvas.mouseOther(start, end, true);
                start = end;
            } 
        }

        private void cp_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (cp.SelectedColor.HasValue)
            {
                Color c = cp.SelectedColor.Value;
                drawingCanvas.SetColor(c);
            }
        }
    }
}
