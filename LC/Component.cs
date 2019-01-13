using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LC
{
    [Serializable]
    class Component
    {
        //fields
        public Point Pointer;

        public Image Image{ get; set; }

        public int Id;

        public Component Output { get; set; }
        public Component Input { get; set; }
        public double output { get; set; }

        //constructor
        public Component(int id, Point o )
        {
            this.Pointer = o;
            this.Id = id;            
        }

        //methods

        public virtual void Draw(Graphics gr)
        {
            
        }

        public bool CheckComponentLocation(Point p)
        {
            if (p == Pointer || ((p.X + 90 > Pointer.X && p.X < Pointer.X + 90) && (p.Y + 50 > Pointer.Y && p.Y < Pointer.Y + 50)))
            {
                return true;
            }
            return false;
        }

        public bool CheckComponentLocation2(Point p)
        {
            if (p == Pointer || ((p.X - 20 > Pointer.X && p.X < Pointer.X + 90) && (p.Y > Pointer.Y && p.Y < Pointer.Y + 50)))
            {
                return true;
            }
            return false;
        }
        public virtual void CalculateOutput(double flow) { }

        public virtual Component ConnectInput(Component e) { return null; }
        public virtual Component ConnectOutput(Component e) { return null; }

        

        public virtual void DeleteOutput() { }

        public virtual bool IsConnected() { return false; }
        public virtual bool CheckInput() { return false; }
        public virtual bool CheckOutput() { return false; }

    }
}
