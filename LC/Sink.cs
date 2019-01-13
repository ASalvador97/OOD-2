using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LC
{
    [Serializable]
    class Sink:Component
    {
       
        public Sink(Point point,int id) : base(id, point)
        {
            this.Image = Properties.Resources.OffBulb1;
        }

       
        public override void Draw(Graphics g)
        {
            Size size = new Size(Image.Width + 50, Image.Height);
            Rectangle rect = new Rectangle(Pointer, size);
            g.DrawImage(Image, rect);
            g.DrawString("Flow:  " + output.ToString(), new Font("Calibri", 9, FontStyle.Regular), Brushes.Black, Pointer.X + 40, Pointer.Y - 10);
        }

        public override Component ConnectInput(Component e)
        {
            if (Input == null)  
            {
                Input = e;
                return this;
            }
            else
            {
                return null;
            }
        }

        public override bool CheckInput()
        {
            if (Input == null)
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
            if(Input != null)
            {
                this.output = Input.output;
                if(this.output ==1)
                {

                    this.Image = Properties.Resources.OnBulb1;
                }
                else
                {
                    this.Image = Properties.Resources.OffBulb1;
                }

            }
          
        }

        public override void DeleteOutput()
        {
            output = 0;
        }

        public override bool IsConnected()
        {
            if (Input != null)
            {
                return true;
            }
            return false;
        }
    }
}
