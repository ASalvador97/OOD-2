using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LC
{
    [Serializable]
    class Source:Component
    {
        
        public Source(int id, Point p, double output) : base(id, p)
        {
            this.output = output;
            this.Image = Properties.Resources.Source;
        }

        

        public override void Draw(Graphics g)
        {
            Size size = new Size(Image.Width, Image.Height);
            Rectangle rect = new Rectangle(Pointer, size);
            g.DrawImage(Image, rect);
            g.DrawString("Flow  " + output.ToString(), new Font("Calibri", 9, FontStyle.Regular), Brushes.Black, Pointer.X + 20, Pointer.Y - 10);
        }

        public override Component ConnectOutput(Component e)
        {
            if (Output == null)
            {
                Output = e;
                return this;
            }
            else
            {
                return null;
            }
        }

        public override bool CheckOutput()
        {
            if (Output == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void CalculateOutput(double flow)
        {
            if (Output != null)
            {
                Output.CalculateOutput(output);
            }

        }

        public override bool IsConnected()
        {
            if (Output != null)
            {
                return true;
            }
            return false;
        }
    }
}
