using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CRUD_ten_dzialajacy
{
    public partial class Customers : Form
    {



        string conString = @"Server=127.0.0.1;Port=3306;Database=lastrada;username=root;password=;";

        int id;
        private int intRow = 0;

        public Customers()
        {
            InitializeComponent();

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {


            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("INSERT", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_ID", id);
                mySqlCmd.Parameters.AddWithValue("_Company", CompanyTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Firstname", FirstNameTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Surname", LastNameTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Street", StreetTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Location", LocationTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Birthdate", BirthdayTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Phone", PhoneTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Email", EmailTextBox.Text.Trim());
                mySqlCmd.Parameters.AddWithValue("_Trusted", TrustedTextBox.Text.Trim());

                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Submited succesfully");
                Clear();
                GridFill();

            }
        }

        void GridFill()
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("CustomersViewAll", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtblCustomers = new DataTable();
                sqlDa.Fill(dtblCustomers);
                DataGridView dgv1 = dataGridView1;
                dgv1.DataSource = dtblCustomers;
                dgv1.Columns[0].Visible = false;

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void CompanyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            GridFill();
        }

        

        void Clear()
        {
            FirstNameTextBox.Text = SearchText.Text = LastNameTextBox.Text = PhoneTextBox.Text = StreetTextBox.Text =
            CompanyTextBox.Text = LocationTextBox.Text = BirthdayTextBox.Text = EmailTextBox.Text = TrustedTextBox.Text = "";
            id = 0;
            InsertButton.Text = "Insert";
            DeleteButton.Enabled = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                CompanyTextBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                FirstNameTextBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                LastNameTextBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                StreetTextBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                LocationTextBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                BirthdayTextBox.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                PhoneTextBox.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                EmailTextBox.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                TrustedTextBox.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                InsertButton.Text = "Update";
                DeleteButton.Enabled = Enabled;

            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("CustomerSearchByValue", mysqlCon);
                sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("_SearchValue",SearchText.Text);
                DataTable dtblCustomers = new DataTable();
                sqlDa.Fill(dtblCustomers);
                DataGridView dgv1 = dataGridView1;
                dgv1.DataSource = dtblCustomers;
                dgv1.Columns[0].Visible = false;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (MySqlConnection mysqlCon = new MySqlConnection(conString))
            {
                mysqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand("CustomerDeleteByID", mysqlCon);
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("_ID", id);
                mySqlCmd.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfully");
                Clear();
                GridFill();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

