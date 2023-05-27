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

namespace Stock_managment
{
    public partial class manageproduct : Form
    {
        // connection string, connection establishment, and cmd executions.
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\drago\OneDrive\Documents\newdb.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public manageproduct()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void manageproduct_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // sql query for inserting 
                cmd = new SqlCommand("insert into newprodTB(PID,name,price,Qty) values(@PID,@name,@price,@Qty)", conn);
               // adding parameters
                cmd.Parameters.AddWithValue("@name", username.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(qty.Text));
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt32(price.Text));
                cmd.Parameters.AddWithValue("@PID", Convert.ToInt32(pid.Text));




                MessageBox.Show("product added!");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Mainform mainform = new Mainform();
              
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear button
            username.Clear();
            qty.Clear();
            price.Clear();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // query for updating the table
                cmd = new SqlCommand("update newprodTB set PID=@PID,name=@name,Qty=@Qty,price=@price where PID like '" + pid.Text + "'", conn);
                cmd.Parameters.AddWithValue("@name", username.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt16(qty.Text));
                cmd.Parameters.AddWithValue("@Qty", Convert.ToInt16(price.Text));
                cmd.Parameters.AddWithValue("@PID", Convert.ToInt16(pid.Text));
                MessageBox.Show("Product updated!");
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Mainform mainform = new Mainform();
                mainform.ShowDialog();
                this.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
