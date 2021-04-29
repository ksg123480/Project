using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Map
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string url = "https://bit-map-project.neocities.org/";//https://pothole-map.neocities.org/  , https://bit-map-project.neocities.org/,http://localhost:8888/
                this.webBrowser1.Navigate(url);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }     
        }
    }
}
