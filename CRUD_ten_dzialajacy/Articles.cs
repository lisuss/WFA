using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_ten_dzialajacy
{
    public partial class Articles : Form
    {

        string conString = @"Server=127.0.0.1;Port=3306;Database=lastrada;username=root;password=;";
        int id;
        
        public Articles()
        {
            InitializeComponent();
        }
        void Clear()
        {
            MaterialGroupBox.Text = DiscountedBox.Text = NameTextBox.Text = PriceTextBox.Text = DescriptionTextBox.Text = ChangeableTextBox.Text = "";
            id = 0;
            insertButtonArticles.Text = "Insert";
            deleteButton.Enabled = false;
        }

        private void insertButtonArticles_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                DateTime localDate = DateTime.Now;
                MySqlCommand mySqlCmd = new MySqlCommand("ArticlesInsert", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_articleID", id);
                mySqlCmd.Parameters.AddWithValue("_mealID", id);
                mySqlCmd.Parameters.AddWithValue("_materialgroup", MaterialGroupBox.SelectedItem.ToString());
                mySqlCmd.Parameters.AddWithValue("_Date", localDate);
                mySqlCmd.Parameters.AddWithValue("_Discounted", DiscountedBox.SelectedItem.ToString());
                mySqlCmd.Parameters.AddWithValue("_Name", NameTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Price", PriceTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Description", DescriptionTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Changeable", ChangeableTextBox.SelectedItem.ToString());


                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Submited succesfully");
                Clear();
                GridFill();

            }
        }
        void GridFill()
        {
            using (MySqlConnection mySqlCon = new MySqlConnection(conString))
            {
                mySqlCon.Open();
                MySqlDataAdapter sqlDaArticles = new MySqlDataAdapter("ViewAllArticles", mySqlCon);
                sqlDaArticles.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblArticles = new DataTable();
                sqlDaArticles.Fill(dtblArticles);
                DataGridView dgv1 = dataGridView1;
                dgv1.DataSource = dtblArticles;
                dgv1.Columns[0].Visible = false;
                dgv1.Columns[1].Visible = false;


            }    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GridFill();

        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                
                MaterialGroupBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                
                DiscountedBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                NameTextBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                DescriptionTextBox.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                ChangeableTextBox.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                insertButtonArticles.Text = "Update";
                deleteButton.Enabled = Enabled;


            }
        }
        private void Form2_load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }
        private void Articles_load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("ArticleDeleteByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_ArticleID", id);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfully");
                Clear();
                GridFill();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDaArticles = new MySqlDataAdapter("ArticlesSearchByValue", mysqlCon);
                sqlDaArticles.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDaArticles.SelectCommand.Parameters.AddWithValue("_SearchValue", searchTextBox.Text);
                DataTable dtblArticles = new DataTable();
                sqlDaArticles.Fill(dtblArticles);
                DataGridView dgv1 = dataGridView1;
                dgv1.DataSource = dtblArticles;
                dgv1.Columns[0].Visible = false;
                dgv1.Columns[1].Visible = false;
            }
        }
        
    }
}
