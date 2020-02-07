using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCD_Agency
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerManagement_Form cmf = new CustomerManagement_Form();
            cmf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportManagement_Form cmf = new ReportManagement_Form();
            cmf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReturnItem_Formcs cmf = new ReturnItem_Formcs();
            cmf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaleManagement_Form cmf = new SaleManagement_Form();
            cmf.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StockManagement_Form cmf = new StockManagement_Form();
            cmf.Show();
        }
    }
}
