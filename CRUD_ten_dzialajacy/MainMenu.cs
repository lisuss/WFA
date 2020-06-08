using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_ten_dzialajacy
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            Customers f = new Customers();
            f.ShowDialog();
        }

        private void ArticlesButton_Click(object sender, EventArgs e)
        {
            Articles a = new Articles();
            a.ShowDialog();
         }

        private void specialIngredientsButton_Click(object sender, EventArgs e)
        {
            SpecialIngridients s = new SpecialIngridients();
            s.ShowDialog();
        }
    }
}
