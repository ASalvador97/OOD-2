using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LC
{
    [Serializable]
    class CircuitBoard
    {
        public List<Component> listComponent = new List<Component>();
        public List<Line> listLine = new List<Line>();

        public CircuitBoard()
        {

        }


        public void addLine(int id, Component one, Component two)
        {
            listLine.Add(new Line(id, one, two));
        }

        public void addSource(int id, double output, Point p)
        {
            Component comp = checkComponent(p);
            {
                if (comp != null)
                {
                    MessageBox.Show("Please select an empty place");
                }
                else
                {
                    listComponent.Add(new Source(id, p, output));
                }
            }
        }

        public void addSink(int id, Point p)
        {
            Component comp = checkComponent(p);
            {
                if (comp != null)
                {
                    MessageBox.Show("Please select empty space.");
                }
                else
                {
                    listComponent.Add(new Sink(p, id));
                }
            }
        }

        public void addNot(int id, Point p)
        {
            Component comp = checkComponent(p);
            {
                if (comp != null)
                {
                    MessageBox.Show("Please select an empty place");
                }
                else
                {
                    listComponent.Add(new Not(p, id));
                }
            }
        }

        public void addOr(int id, Point p)
        {
            Component comp = checkComponent(p);
            {
                if (comp != null)
                {
                    MessageBox.Show("Please select empty space.");
                }
                else
                {
                    listComponent.Add(new Or(p, id));
                }
            }
        }

        public void addAnd(int id, Point p)
        {
            Component comp = checkComponent(p);
            {
                if (comp != null)
                {
                    MessageBox.Show("Please select an empty place");
                }
                else
                {
                    listComponent.Add(new And(p, id));
                }
            }
        }
        
        public void deleteComponent(Point p)
        {
            Component comp = checkComponentForEditingAndDeleting(p);
            Line line = checkLine(p);

            if (comp != null)
            {
                if (comp.IsConnected() == true)
                {
                    MessageBox.Show("Please remove line first");
                }
                else
                {
                    //removeFromId(id);
                    listComponent.Remove(comp);
                }
            }
            else if (line != null)
            {
                deleteLine(p);
                listLine.Remove(line);
            }
            else
                MessageBox.Show("Please select Component you want to remove");

        }
        public void deleteLine(Point p)
        {
            Line line = checkLine(p);
            bool oneOutput = true;
            bool oneInput = true;

            if (line != null)
            {
                if (line.Component is Not)
                {
                    
                    if (((Not)line.Component).Output == line.Component2)
                    {
                        ((Not)line.Component).Output = null;
                    }
                    
                }
                if (line.Component is Or)
                {
                    oneInput = false;
                    if (((Or)line.Component).Input == line.Component2)
                    {
                        ((Or)line.Component).Input = null;
                    }
                    else if (((Or)line.Component).SecondInput == line.Component2)
                    {
                        ((Or)line.Component).SecondInput = null;
                    }
                }
                if (line.Component2 is And)
                {
                    oneInput = false;
                    if (((And)line.Component2).Input == line.Component)
                    {
                        ((And)line.Component2).Input = null;
                    }
                    else if (((And)line.Component2).SecondInput == line.Component)
                    {
                        ((And)line.Component2).SecondInput = null;
                    }
                }

                if (oneOutput == true)
                {
                    ((Component)line.Component).Output = null;

                }
                if (oneInput == true)
                {
                    ((Component)line.Component2).Input = null;
                }



            }
        }

        public Component checkComponent(Point p) //Checking if this place have Component to add a one next to it
        {

            foreach (Component e in listComponent)
            {
                if (e.CheckComponentLocation(p) == true)
                {
                    return e;
                }
            }
            return null;
        }

        
        public Line checkLine(Point p) //Checking if this place have Line
        {

            foreach (Line line in listLine)
            {
                if (line.Contains(p) == true)
                {
                    return line;
                }
            }
            return null;
        }
      

        public void editFlow(Point p)
        {
            Component comp = checkComponentForEditingAndDeleting(p);

            if (comp != null)
            {
                if (comp is Source)
                {
                    if(comp.output == 1)
                    {
                        comp.output = 0;
                    }
                    else { comp.output = 1; }
                    
                }
                
            }

        }

        public Component checkComponentForEditingAndDeleting(Point p) //Checking if this place its empty with Components or not
        {

            foreach (Component e in listComponent)
            {
                if (e.CheckComponentLocation(p) == true)
                {
                    return e;
                }
            }
            return null;
        }
        public Component checkElementForEditingAndDeleting(Point p) //Checking if this place its empty with elements or not
        {

            foreach (Component e in listComponent)
            {
                if (e.CheckComponentLocation2(p) == true)
                {
                    return e;
                }
            }
            return null;
        }


        public void DrawComponents(Graphics g)
        {
            foreach (Component e in listComponent)
            {
                e.Draw(g);
            }
            foreach (Line p in listLine)
            {
                p.Draw(g);
            }
        }

        public void calculateFlow()
        {
            foreach (Component e in listComponent)
            {
                  e.DeleteOutput();
            }
            foreach (Component el in listComponent)
            {
                if (el.IsConnected())
                {
                    el.CalculateOutput(0);
                }
            }
            foreach (Line pl in listLine)
            {
                pl.CalculateResult();
            }
        }

        public void newFile() 
        {
            listComponent.Clear(); 
            listLine.Clear(); 
        }

    }
}
