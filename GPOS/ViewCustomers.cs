﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPOS
{
    public partial class ViewCustomers : Form
    {
        public ViewCustomers()
        {
            InitializeComponent();
            DisplayCustomers();

            CustomerDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomerDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            CustomerDGV.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
        }

        private void ViewCustomers_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Mainmenu obj = new Mainmenu();
            obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\GidCode\Desktop\CodeMe\GPOSDB.mdf;Integrated Security=True;Connect Timeout=30");

        /// <summary>
        /// this function display product dataset/table
        /// </summary>
        private void DisplayCustomers()
        {
            Con.Open();
            string Query = "select * from CustomerTbl";
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            // we fill data grid with the acutal data in db
            CustomerDGV.DataSource = ds.Tables[0];


            CustomerDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            Con.Close();

        }

        int key = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // setting data in datagrid to fit text box for edit RESPECTIVELY 
            CusName.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CusAdd.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CusPhone.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CusRem.Text = CustomerDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (CusName.Text == "")
            {

                key = 0;
            }
            else
            {

                key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void CusPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            CusName.Text = "";
            CusAdd.Text = "";
            CusPhone.Text = "";
            CusRem.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CusName.Text == "" || CusAdd.Text == "" || CusPhone.Text == "" || CusRem.Text == "")
            {
                MBox1.Show("Select the Customer ");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(" Update CustomerTbl set CusName = @CN, CusAdd=@CA, CusPhone = @CP, CusRem = @CR where CusId = @Pkey", Con);
                    cmd.Parameters.AddWithValue("@CN", CusName.Text);
                    cmd.Parameters.AddWithValue("@CA", CusAdd.Text);
                    cmd.Parameters.AddWithValue("@CP", CusPhone.Text);
                    cmd.Parameters.AddWithValue("@CR", CusRem.Text);
                    cmd.Parameters.AddWithValue("@Pkey", key);

                    cmd.ExecuteNonQuery();
                    MBox1.Show("Supplier Detail Updated");
                    Con.Close();
                    DisplayCustomers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MBox1.Show("select the Customer");
            }
            else
            {
                try
                {
                    // we open db connection 
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(" delete from CustomerTbl where CusId=@Pkey", Con);
                    cmd.Parameters.AddWithValue("@PKey", key);


                    cmd.ExecuteNonQuery();
                    MBox1.Show("Customer Deleted ");
                    Con.Close();
                    DisplayCustomers();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MBox1.Show(Ex.Message);
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
