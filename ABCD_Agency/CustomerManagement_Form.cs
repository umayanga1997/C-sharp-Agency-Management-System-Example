using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ABCD_Agency
{
    public partial class CustomerManagement_Form : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CRO4EQ0\AVISQL;Initial Catalog=ABCD_AGENCY;User ID=sa;Password=avishka.1997");
        public CustomerManagement_Form()
        {
            InitializeComponent();
            this.ActiveControl = cid_txt;
            GrideLoad();
            AutoValueAdd();
        }
        public void Clear()
        {
            try
            {
               
                cid_txt.Text = null;
                name_txt.Text = null;
                Shopname_txt.Text = null;
                address_txt.Text = null;
                nic_txt.Text = null;
                phone_txt.Text = null;
                lone_txt.Text = "0.0";
                cashDisplay_txt.Text = "0.0";
                checkDisplay_txt.Text = "0.0";
                //creditDisplay_txt.Text = "0.0";
                balance_txt.Text = "0.0";
                customerimage_picbox.Image = null;
            }
            catch (Exception ex)
            {

            }
        }

        public void GrideLoad()
        {
            try
            {
                customergrideview.Rows.Clear();
                string loadQuery = "select * from dbo.Customer_Management";
                SqlCommand cmd = new SqlCommand(loadQuery, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customergrideview.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void AutoValueAdd()
        {
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            try
            {
                string addvalueQuery = "select * from dbo.Customer_Management";
                SqlCommand cmd = new SqlCommand(addvalueQuery, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    col.Add(reader[0].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {

            }
            cid_txt.AutoCompleteCustomSource = col;
        }
        public void InsertSQl()
        {
            try
            {

                if (cid_txt.Text =="")
                {
                    MessageBox.Show("Please Enter Customer ID...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (name_txt.Text =="")
                {
                    MessageBox.Show("Please Enter Customer Name...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Shopname_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Shop Name...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (address_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer or Shop Address...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nic_txt.Text =="")
                {
                    MessageBox.Show("Please Enter Customer NIC...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (phone_txt.Text =="")
                {
                    MessageBox.Show("Please Enter Customer or Shop Phone Number...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    customerimage_picbox.Image.Save(ms, customerimage_picbox.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    ms.Close();

                    string insertQuery = "insert into dbo.Customer_Management (customer_id,customer_name,shop_name,address,nic,phone,image)values(@customer_id,@customer_name,@shop_name,@address,@nic,@phone,@image)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@customer_id",cid_txt.Text);
                    cmd.Parameters.AddWithValue("@customer_name",name_txt.Text);
                    cmd.Parameters.AddWithValue("@shop_name",Shopname_txt.Text);
                    cmd.Parameters.AddWithValue("@address",address_txt.Text);
                    cmd.Parameters.AddWithValue("@nic",nic_txt.Text);
                    cmd.Parameters.AddWithValue("@phone",phone_txt.Text);
                    cmd.Parameters.AddWithValue("@image",img);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Values are Inserted...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    GrideLoad();
                    AutoValueAdd();
                }
                
            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateSQL()
        {
            
            try
            {
                if (cid_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer ID...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (name_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer Name...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Shopname_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Shop Name...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (address_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer or Shop Address...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nic_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer NIC...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (phone_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer or Shop Phone Number...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    customerimage_picbox.Image.Save(ms, customerimage_picbox.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    ms.Close();

                    string updateQuery = "update dbo.Customer_Management set customer_id ='" + cid_txt.Text + "',customer_name ='" + name_txt.Text + "',shop_name ='" + Shopname_txt.Text + "',address ='" + address_txt.Text + "',nic ='" + nic_txt.Text + "',phone='" + phone_txt.Text + "',image=@image where customer_id='" + cid_txt.Text+"'";
                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.Add(new SqlParameter("@image", img));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Values are Updated...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    GrideLoad();
                    AutoValueAdd();
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void DeleteSQL()
        {
            try
            {
                if (cid_txt.Text == "")
                {
                    MessageBox.Show("Please Enter Customer ID...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string deleteQuery = "delete from dbo.Customer_Management where customer_id ='" + cid_txt.Text + "'";
                    SqlCommand cmd = new SqlCommand(deleteQuery, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record is Deleted...", "ABCD Agency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    GrideLoad();
                    AutoValueAdd();
                }
            }
            catch (Exception ex)
            {

            }
        }

       
        public void GrideClick()
        {
            try
            {
                cid_txt.Text = customergrideview.CurrentRow.Cells[0].Value.ToString();
                name_txt.Text = customergrideview.CurrentRow.Cells[1].Value.ToString();
                Shopname_txt.Text = customergrideview.CurrentRow.Cells[2].Value.ToString();
                address_txt.Text = customergrideview.CurrentRow.Cells[3].Value.ToString();
                nic_txt.Text = customergrideview.CurrentRow.Cells[4].Value.ToString();
                phone_txt.Text = customergrideview.CurrentRow.Cells[5].Value.ToString();
                lone_txt.Text = customergrideview.CurrentRow.Cells[6].Value.ToString();
                cashDisplay_txt.Text = customergrideview.CurrentRow.Cells[7].Value.ToString();
                checkDisplay_txt.Text = customergrideview.CurrentRow.Cells[8].Value.ToString();              
                balance_txt.Text = customergrideview.CurrentRow.Cells[9].Value.ToString();

                string searchingQuery = "select * from dbo.Customer_Management where customer_id ='" + customergrideview.CurrentRow.Cells[0].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(searchingQuery, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] img = (byte[])reader[10];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        customerimage_picbox.Image = Image.FromStream(ms);
                    }
                }
                reader.Close();
                con.Close();
               
            }
            catch (Exception ex)
            {

            }
        }
        public void TextChengSearching()
        {
            try
            {
                DataSet dataSet = new DataSet();
                string searchingQuery = "select * from dbo.Customer_Management where customer_id ='" + cid_txt.Text + "'";
                SqlCommand cmd = new SqlCommand(searchingQuery, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
                int rowcount = dataSet.Tables[0].Rows.Count;

                if (rowcount == 0 && cid_txt.Text != "")
                {
                    customergrideview.Rows.Clear();
                    name_txt.Text = null;
                    Shopname_txt.Text = null;
                    address_txt.Text = null;
                    nic_txt.Text = null;
                    phone_txt.Text = null;
                    lone_txt.Text = "0.0";
                    cashDisplay_txt.Text = "0.0";
                    checkDisplay_txt.Text = "0.0";
                    balance_txt.Text = "0.0";
                    customerimage_picbox.Image = null;
                }
                else if (cid_txt.Text == "")
                {
                    GrideLoad();
                    Clear();
                }
                else
                {
                    if(cid_txt.Focused == true)
                    {
                        customergrideview.Rows.Clear();
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customergrideview.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]);
                            name_txt.Text = reader[1].ToString();
                            Shopname_txt.Text = reader[2].ToString();
                            address_txt.Text = reader[3].ToString();
                            nic_txt.Text = reader[4].ToString();
                            phone_txt.Text = reader[5].ToString();
                            lone_txt.Text = reader[6].ToString();
                            cashDisplay_txt.Text = reader[7].ToString();
                            checkDisplay_txt.Text = reader[8].ToString();
                            balance_txt.Text = reader[9].ToString();

                            byte[] img = (byte[])reader[10];
                            if (img != null)
                            {
                                MemoryStream ms = new MemoryStream(img);
                                customerimage_picbox.Image = Image.FromStream(ms);
                            }

                        }
                        reader.Close();
                        con.Close();
                    }
                    
                }

            }
            catch (Exception ex)
            {

            }
            //con.Close();
        }
        private void insert_btn_Click(object sender, EventArgs e)
        {
            InsertSQl();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            UpdateSQL();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteSQL();
        }

        private void cid_txt_TextChanged(object sender, EventArgs e)
        {
            TextChengSearching();
        }

        private void customergrideview_Click(object sender, EventArgs e)
        {
            GrideClick();
        }

        private void customerimage_picbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "(*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                
                customerimage_picbox.Image = Image.FromFile(opd.FileName);
            }
            
        }
    }

}
