using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaMerger
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            proBar.Value = 0;
        }

        private void btnLoadDir_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if(folderBrowserDialog1.SelectedPath != null)
            {
                lstDir.Items.Clear();
                loadDirectories(folderBrowserDialog1.SelectedPath.ToString());
            }
        }

        private void loadDirectories(string dirpath)
        {
            int i = 0,j=0;
            try
            {
                // Set a variable to the My Documents path.
                string docPath = dirpath;

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(docPath));

                j = 100 / dirs.Count;
                MessageBox.Show("" + j);
                i = j;
                foreach (var dir in dirs)
                {
                    lstDir.Items.Add(dir);
                    i = i + j;
                    proBar.Value = i > 100? 100:i;
                   // lstDir.Items.Add($"{dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1)}");
                }
                Console.WriteLine($"{dirs.Count} directories found.");
                MessageBox.Show("" + dirs.Count);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
