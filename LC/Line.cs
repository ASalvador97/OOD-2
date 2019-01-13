using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LC
{
    [Serializable]
    class Line
    {

        //properties

        public double Flow { get; set; }
        private Point FirstPoint;
        private Point SecondPoint;
        private int Id;

        public Component Component;
        public Component Component2;
        public Point Point { get; set; }

        //constructor
        public Line(int id, Component component, Component component2)
        {
            this.Id = id;
            this.Component = component;
            this.Component2 = component2;


        }

        //methods
        public void Draw(Graphics gr)
        {
            
            bool same = false;
            bool ConMid = true;
            bool Con2Mid = true;
            Point first1 = new Point();
            Point second1 = new Point();
            
            if (Component2 is And)
            {

                Con2Mid = false;
                if (((And)Component2).Input == Component)
                {

                    SecondPoint = new Point(Component2.Pointer.X + 20, Component2.Pointer.Y + 13);
                    if (((And)Component2).SecondInput == Component)
                    {
                        second1 = new Point(Component2.Pointer.X + 20, Component2.Pointer.Y + 41);

                    }

                }
                else
                {
                    SecondPoint = new Point(Component2.Pointer.X + 20, Component2.Pointer.Y + 41);
                }

            }
            if (ConMid == true)
            {
                FirstPoint = new Point(Component.Pointer.X + 32, Component.Pointer.Y + 27);
            }
            if (Con2Mid == true)
            {
                SecondPoint = new Point(Component2.Pointer.X + 16, Component2.Pointer.Y + 27);
            }

            if (Flow == 0)
            {
                Pen pen = new Pen(Color.Blue, 8);
                gr.DrawLine(pen, FirstPoint, SecondPoint);
                gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                if (same == true)
                {
                    Pen pen1 = new Pen(Color.Blue, 8);
                    gr.DrawLine(pen, first1, second1);
                    gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                }

            }
            else if(Flow ==1)
            {
                Pen pen = new Pen(Color.Red, 8);
                gr.DrawLine(pen, FirstPoint, SecondPoint);
                gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                if (same == true)
                {
                    Pen pen1 = new Pen(Color.Red, 8);
                    gr.DrawLine(pen, first1, second1);
                    gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                }

            }
            else 
            {
                Pen pen = new Pen(Color.Green, 8);
                gr.DrawLine(pen, FirstPoint, SecondPoint);
                gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                if (same == true)
                {
                    Pen pen1 = new Pen(Color.Green, 8);
                    gr.DrawLine(pen, first1, second1);
                    gr.DrawString("Flow " + Flow.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Green, FirstPoint.X + 20, FirstPoint.Y - 20);
                }

            }
        }
        

        public bool CheckComponentLocation(Point p)
        {
            if (p == Point || ((p.X + 100 > Point.X && p.X < Point.X + 100) && (p.Y + 50 > Point.Y && p.Y < Point.Y + 50)))
            {
                return true;
            }
            return false;
        }

        public bool Contains(Point p)
        {
            int a = Math.Min(FirstPoint.Y, SecondPoint.Y);
            int b = Math.Min(FirstPoint.X, SecondPoint.X);

            int c = Math.Max(FirstPoint.Y, SecondPoint.Y);
            int d = Math.Max(FirstPoint.X, SecondPoint.X);

            Rectangle rectangle = Rectangle.FromLTRB(b, a, d, c);


            if (rectangle.Contains(p) == true)
            {
                double x1 = FirstPoint.Y - SecondPoint.Y;
                double x2 = FirstPoint.X - SecondPoint.X;
                double xx = x1 / x2;
                double y1 = FirstPoint.X * xx;
                double yy = FirstPoint.Y - y1;

                if (p.Y + 30 > (xx * p.X + yy - 42) && p.Y - 40 < (xx * p.X + yy + 44))
                {
                    return true;
                }
            }
            return false;
        }

        public void CalculateResult()
        {
            
            Flow = Component.output;
            
        }
    }
}
