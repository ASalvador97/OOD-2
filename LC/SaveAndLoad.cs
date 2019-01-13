using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LC
{
    class SavingAndLoading
    {
        public List<CircuitBoard> flowNets = new List<CircuitBoard>();

        public void SaveToFile(String fileName, CircuitBoard cb)
        {
            this.flowNets.Add(cb);

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                foreach (CircuitBoard fl in flowNets)
                {
                    bf.Serialize(fs, fl);
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public void LoadFile(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                while (fs.Position < fs.Length)
                {
                    flowNets.Add((CircuitBoard)bf.Deserialize(fs));
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
