using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using hehexd.composite;
using hehexd.Visitors;
using System.Windows.Media;

namespace hehexd.Shapes
{
    public abstract class AbstractFigure : IComponent, IVisitable
    {

        public abstract void accept(IVisitor visitor);
        DrawingCanvas dc;

        protected Point BaseStart;
        protected Point start;
        protected Point end;

        protected UIElement child;
        protected int canvasindex;

        public abstract Shape GetObject();

        public void Drag(string s, Point Start, Point End)
        {
            Point a;
            Point b;
            if (s == "e")
            {
                a = start;
                b = end;
            }
            else if(s == "r")
            {
                a = Start;
                b = End;
            }
            else
            {
                a = End;
                b = Start;
            }

            double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
            double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
            double nposx = (a.X - b.X);
            double nposy = (a.Y - b.Y);
            child.SetValue(Canvas.LeftProperty, posx - nposx);
            child.SetValue(Canvas.TopProperty, posy - nposy);
        }

        public void Resize(string s, Point Start, Point End)
        {

            Point a;
            Point b;
            if(s == "e")
            {
                 a = start;
                 b = end;
            }
            else if (s == "r")
            {
                a = Start;
                b = End;
            }
            else
            {
                a = End;
                b = Start;
            }

            double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
            double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
            double height = Convert.ToDouble(child.GetValue(Canvas.HeightProperty));
            double width = Convert.ToDouble(child.GetValue(Canvas.WidthProperty));
            double nposx = (a.X - b.X);
            double nposy = (a.Y - b.Y);
            if ((height - nposy) > 0 && (width - nposx) > 0)
            {
                child.SetValue(Canvas.WidthProperty, width - nposx);
                child.SetValue(Canvas.HeightProperty, height - nposy);
            }
        }

        public void Drawshape()
        {
            var end = rEnd();
            var start = rStart();
            if (end.X >= start.X)
            {
                 child.SetValue(Canvas.LeftProperty, start.X);
                 child.SetValue(Canvas.WidthProperty, end.X- start.X);
            }
            else
            {
                child.SetValue(Canvas.LeftProperty, end.X);
                child.SetValue(Canvas.WidthProperty, start.X - end.X);
            }

            if (end.Y >= start.Y)
            {
                child.SetValue(Canvas.TopProperty, start.Y);
                child.SetValue(Canvas.HeightProperty, end.Y - start.Y);
            }
            else
            {
                child.SetValue(Canvas.TopProperty, end.Y);
                child.SetValue(Canvas.HeightProperty, start.Y - end.Y);
            }
        }

        public void Paint(Color c)
        {
            SolidColorBrush brush = new SolidColorBrush(c);
            child.SetValue(Canvas.BackgroundProperty, brush);
        }

        public AbstractFigure find(Point punt)
        {
            var s =  child.GetValue(Canvas.TopProperty);
            if (Convert.ToDouble(child.GetValue(Canvas.LeftProperty)) < punt.X && (Convert.ToDouble(child.GetValue(Canvas.LeftProperty)) + Convert.ToDouble(child.GetValue(Canvas.WidthProperty)) > punt.X && Convert.ToDouble(child.GetValue(Canvas.TopProperty)) < punt.Y && Convert.ToDouble(child.GetValue(Canvas.TopProperty)) + Convert.ToDouble(child.GetValue(Canvas.HeightProperty)) > punt.Y))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public Point rStart()
        {
            return start;
        }

        public Point rEnd()
        {
            return end;
        }

        public Point rBStart()
        {
            return BaseStart;
        }

        public void setPoints(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public void SetBaseStart(Point Bstart)
        {
            this.BaseStart = Bstart;
        }

        public UIElement rChild()
        {
            return child;
        }

        public void setindex(int i)
        {
            canvasindex = i;
        }

        public int getindex()
        {
            return canvasindex;
        }

        public UIElement GetChild()
        {
            return child;
        }

        public void SetChild(UIElement c)
        {
            this.child = c;
        }
    }
}
