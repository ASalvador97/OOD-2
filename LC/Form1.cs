using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LC
{
    [Serializable]
    public partial class Form1 : Form
    {
        string SelectedElement = "";
        int IdLine = 0;
        int IdSource = 0;
        int IdAnd = 0;
        int IdOr = 0;
        int IdNot = 0;
        int IdSink = 0;
        int clicks = 1;
        Component one = null;
        Component two = null;        
        Point old;
        double oldCapacity, oldUpper;
        CircuitBoard cb;
        private SavingAndLoading sl;
        public Form1()
        {
            InitializeComponent();
            cb = new CircuitBoard();
            lblSelected.Visible = false;
        }

        //methods
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void InsertLocation(Point p, double oldCa)
        {
            old = p;
            oldCapacity = oldCa;
        }
        public void InsertLocation2(Point p, int oldUp)
        {
            old = p;
            oldUpper = oldUp;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            SelectedElement = "LINE";
            lblSelected.Text = SelectedElement;
            lblSelected.Visible = true;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            SelectedElement = "SOURCE";
            lblSelected.Text = "Selected: SOURCE";
            lblSelected.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SelectedElement = "AND";
            lblSelected.Text = "Selected: ADD";
            lblSelected.Visible = true;
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            SelectedElement = "OR";
            lblSelected.Text = "Selected: OR";
            lblSelected.Visible = true;
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            SelectedElement = "NOT";
            lblSelected.Text = "Selected: NOT";
            lblSelected.Visible = true;
        }

        private void btnSink_Click(object sender, EventArgs e)
        {
            SelectedElement = "SINK";
            lblSelected.Text = "Selected: SINK";
            lblSelected.Visible = true;
        }

        private void DrawingPlace_MouseClick(object sender, MouseEventArgs e)
        {
            
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (SelectedElement == "LINE" && clicks == 1)

                    {
                        Point p = new Point(e.X, e.Y);
                        one = cb.checkComponent(p);

                        if (one != null)
                        {
                            if (one.CheckOutput() != true)
                            {
                                clicks = 1;
                                one = null;
                                two = null;
                                MessageBox.Show("There isn't a free output");
                            }
                            else
                            {
                                clicks = 2;
                            }
                        }
                        else
                        {
                            clicks = 1;
                            one = null;
                            two = null;
                            MessageBox.Show("Select a component");
                        }
                    }


                    else if (clicks == 2)
                    {
                        Point p = new Point(e.X, e.Y);
                        two = cb.checkComponent(p);
                        if (two != null)
                        {
                            if (two.CheckInput() != true)
                            {
                                clicks = 1;
                                one = null;
                                two = null;
                                MessageBox.Show("There isn't a free input");
                            }
                            else if (two == one)
                            {
                                clicks = 1;
                                one = null;
                                two = null;
                                MessageBox.Show("Can't connect to the same element");
                            }
                            else if (two.Output == one)
                            {
                                clicks = 1;
                                one = null;
                                two = null;
                                MessageBox.Show("These connection will make a loop");
                            }
                            else if (two is Or)
                            {
                                if (((Or)two).SecondInput == one)
                                {
                                    clicks = 1;
                                    one = null;
                                    two = null;
                                    MessageBox.Show("These connection will make a loop");
                                }
                                else
                                {
                                    one.ConnectOutput(two);
                                    two.ConnectInput(one);
                                    ++IdLine;
                                    cb.addLine(IdLine, one, two);
                                    cb.calculateFlow();
                                }
                            }
                            else if (two is And)
                            {
                                if (((And)two).SecondInput == one)
                                {
                                    clicks = 1;
                                    one = null;
                                    two = null;
                                    MessageBox.Show("This connection will make a loop");
                                }
                                else
                                {
                                    one.ConnectOutput(two);
                                    two.ConnectInput(one);
                                    ++IdLine;
                                    cb.addLine(IdLine, one, two);
                                    cb.calculateFlow();
                                }
                            }
                            else
                            {
                                one.ConnectOutput(two);
                                two.ConnectInput(one);
                                ++IdLine;
                                cb.addLine(IdLine, one, two);
                                cb.calculateFlow();
                            }
                            //tb1.Clear();
                            one = null;
                            two = null;
                            clicks = 1;
                        }
                        else
                        {
                            MessageBox.Show("Select an element");
                            clicks = 1;
                            one = null;
                            two = null;
                        }

                    }


                    if (SelectedElement == "AND")
                    {
                        ++IdAnd;
                        cb.addAnd(IdAnd, new Point(e.X - 50, e.Y - 20));
                    }
                    if (SelectedElement == "OR")
                    {                        
                        ++IdOr;
                        cb.addOr(IdOr, new Point(e.X - 50, e.Y - 20));
                        cb.calculateFlow();
                    }
                    if (SelectedElement == "NOT")
                    {
                        ++IdNot;
                        cb.addNot(IdNot, new Point(e.X - 50, e.Y - 20));
                        cb.calculateFlow();
                    }
                    if (SelectedElement == "SINK")
                    {
                        ++IdSink;
                        cb.addSink(IdSink, new Point(e.X - 50, e.Y - 20));
                      //  cb.calculateFlow();
                    }
                    if (SelectedElement == "SOURCE")

                    {
                        ++IdSource;
                        lblSelected.Text = IdSource.ToString();
                        cb.addSource(IdSource, 1, new Point(e.X - 50, e.Y - 20));
                        // nm1.Value = 0;
                        // nm2.Value = 0;
                    }


                    if (SelectedElement == "EDIT")
                    {
                        EditComponent(new Point(e.X, e.Y));
                        pbDrawingArea.Update();
                        cb.calculateFlow();
                    }
                    cb.calculateFlow();
                    pbDrawingArea.Invalidate();
                }

                else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (MessageBox.Show("Do you want to delete?", "CircuitBoard App", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        // s.Cancel  = true;

                        SelectedElement = "DELETE";
                        if (SelectedElement == "DELETE")
                        {
                            lblSelected.Visible = false;

                            cb.deleteComponent(new Point(e.X, e.Y));
                            cb.calculateFlow();
                        }

                        pbDrawingArea.Invalidate();
                    }
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("You Cant connect those together");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            SelectedElement = "EDIT";            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        public void EditComponent(Point p)
        {
            Component comp = cb.checkComponentForEditingAndDeleting(p);

            if (comp is Source)
            {

                
                cb.editFlow(p);
                var obj = (Source)comp;
                InsertLocation(p, obj.output);

            }
            else
            {
                MessageBox.Show("Selected element is not correct");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sl = new SavingAndLoading();
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text|*.txt|All|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                sl.SaveToFile(save.FileName, cb);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sl = new SavingAndLoading();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text|*.txt|All|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                sl.LoadFile(open.FileName);
                cb = sl.flowNets.First();
                this.Refresh();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cb.newFile();
            pbDrawingArea.Invalidate();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string manual = AppDomain.CurrentDomain.BaseDirectory + "Manual.pdf";
            System.Diagnostics.Process.Start(manual);
        }

        private void DrawingPlace_Paint(object sender, PaintEventArgs e)
        {
            cb.DrawComponents(e.Graphics);
        }




    }

        
}

