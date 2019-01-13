using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LC
{
    [Serializable]
    class Not:Component
    {
        
       public int InPut = 0;
       public int OutPut = 0;  


        
        public Not(Point point,int id) : base(id, point)
        {
            this.Image = Properties.Resources.Not;
        }

       

        public override void Draw(Graphics g)
        {
            Size size = new Size(Image.Width, Image.Height);
            Rectangle rect = new Rectangle(Pointer, size);
            g.DrawImage(Image, rect);
            g.DrawString("Flow  " + output.ToString(), new Font("Calibri", 9, FontStyle.Regular), Brushes.Black, Pointer.X + 20, Pointer.Y - 10);
        }
        public override void CalculateOutput(double flow)
        {
            if (Input!= null)
            {
                if(Input.output == 1)
                {
                    this.output = 0;
                }
                else
                {
                    this.output = 1;
                }
            }
            
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

        public override void DeleteOutput()
        {
            output = 0;
        }

        public override bool IsConnected()
        {
            if (Output != null ||  Input != null)
            {
                return true;
            }
            return false;
        }
    }
}
