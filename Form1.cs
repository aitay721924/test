using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace csharp
{
    public partial class Form1 : Form
    {
        int i = 0;
        int people, data;
        string[] temp;
        public Form1()
        {
            InitializeComponent();
        }

        public void pth(string path)
        {
            StreamReader str = new StreamReader(path,Encoding.Default);
            string line;
            while ((line = str.ReadLine()) != null)
            {
                if (i != 0)
                {
                    temp = line.Split(' ');
                    listView1.Items.Add((i-1).ToString(), (i-1).ToString(), 0);
                    listView1.Items[(i - 1).ToString()].SubItems.Add(temp[0]);
                    listView1.Items[(i - 1).ToString()].SubItems.Add(temp[1]);
                    if (listView1.Items.Count > people)
                    {
                        listView1.Items.Clear();
                        MessageBox.Show("失敗,資料太多");
                        break;
                    }
                }
                else
                {
                    string[] tmp = line.Split(' ');
                    people = Convert.ToInt32(tmp[0]);
                    people = int.Parse(tmp[0]);
                    data = Convert.ToInt32(tmp[1]);
                    data = int.Parse(tmp[1]);
                }
                i++;
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @".\\";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Comma-Delimited Files (*.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pth(openFileDialog1.FileName);
            }
        }

        private void btn_random_Click(object sender, EventArgs e)
        {

        }
    }
}
