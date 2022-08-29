using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace LabExcer01
{
    public partial class Form1 : Form
    {
        public Form1(string user)
        {
            
            InitializeComponent();
            label1.Text = user;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
         
            Item item = new Item();
            if (txt_Number.Text.Equals("") ||
                txt_Date.Text.Equals("") ||
                txt_Sku.Text.Equals("") ||
                txt_Item_name.Text.Equals("") ||
                txt_Quantity.Text.Equals("") ||
                txt_Price.Text.Equals("")) 
            {
                MessageBox.Show($"INVALID DATA ENTRY" +
               "\n" +
               $"ITEM NUMBER :-  {item.Number.ToString()} Is INVALID" +
               "\n" +
               $"ITEM DATE :-  {item.Date} Is INVALID" +
               "\n" +
               $"ITEM SKU :-  {item.Sku} Is INVALID" +
               "\n" +
               $"ITEM NAME :-  {item.Item_Name} Is INVALID" +
               "\n" +
               $"ITEM QUANTITY :-  {item.Quantity.ToString()} Is INVALID" +
               "\n" +
               $"ITEM PRICE :-  {item.Price.ToString()} Is INVALID");

            }
            else
            {
                item.Number = Convert.ToInt32(txt_Number.Text);
                item.Date = txt_Date.Text;
                item.Sku = txt_Sku.Text;
                item.Item_Name = txt_Item_name.Text;
                item.Quantity = Convert.ToInt32(txt_Quantity.Text);
                item.Price = Convert.ToDouble(txt_Price.Text);
                item.IsAvailable = checkBox1.Checked;

                string abc = " ";
                foreach(var it in checkedListBox1.CheckedItems)
                {
                    abc+="  " + it.ToString()+"  ";

                }
                string efg = " ";
                string hij = " ";

                if (radioButton1.Checked==true)
                efg = radioButton1.Text;
                else
                    efg= radioButton2.Text; 

                if (radioButton3.Checked == true)
                    hij = radioButton3.Text;
                else
                    hij = radioButton4.Text;

                MessageBox.Show($"DATA ADDED SUCCESSFULLY" +
                    "\n" +
                    $"ITEM NUMBER :-  {item.Number.ToString()}" +
                    "\n" +
                    $"ITEM DATE :-  {item.Date}" +
                    "\n" +
                    $"ITEM SKU :-  {item.Sku}" +
                    "\n" +
                    $"ITEM NAME :-  {item.Item_Name}" +
                    "\n" +
                    $"ITEM QUANTITY :-  {item.Quantity.ToString()}" +
                    "\n" +
                    $"ITEM PRICE :-  {item.Price.ToString()}" +
                    "\n" +
                    $"ITEM AVAILABILITY :- {item.IsAvailable.ToString()}" +
                    "\n" +
                    $"ITEM CHECKBOXLIST :- {abc}" +
                    "\n" +
                    $"ITEM GROUPBOX PRODUCT TYPE : - {efg}" +
                    "\n" +
                    $"ITEM GROUPBOX PAYMENT MODE :- {hij}"
                    );
                item.save();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Item.Getallproducts();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txt_Number.Text = "";
            txt_Date.Text = "";
            txt_Sku.Text = "";
            txt_Item_name.Text = "";
            txt_Quantity.Text = "";
            txt_Price.Text = "";
            checkBox1.Checked=false;
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            radioButton3.Checked=false;
            radioButton4.Checked=false;
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BMR8RO5\SQLEXPRESS;Initial Catalog=ProductscsharpLab;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Items values (@Number,@Timeofpurchase,@skunumber,@ItemName,@quantity,@Price,@isavailable)", con);
            cmd.Parameters.AddWithValue("@Number", int.Parse(txt_Number.Text));
            cmd.Parameters.AddWithValue("@Timeofpurchase", txt_Date.Text.ToString());
            cmd.Parameters.AddWithValue("@skunumber", txt_Sku.Text);
            cmd.Parameters.AddWithValue("@ItemName", txt_Item_name.Text);
            cmd.Parameters.AddWithValue("@quantity", int.Parse(txt_Quantity.Text));
            cmd.Parameters.AddWithValue("@Price", int.Parse(txt_Price.Text));
            cmd.Parameters.AddWithValue("@isavailable", Convert.ToBoolean(checkBox1.Checked));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully");
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BMR8RO5\SQLEXPRESS;Initial Catalog=ProductscsharpLab;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update Items set Number=@Number,Timeofpurchase=@Timeofpurchase,skunumber=@skunumber,ItemName=@ItemName,quantity=@quantity,Price=@Price,isavailable=@isavailable where Number=@Number ", con);
            cmd.Parameters.AddWithValue("@Number", int.Parse(txt_Number.Text));
            cmd.Parameters.AddWithValue("@Timeofpurchase", txt_Date.Text.ToString());
            cmd.Parameters.AddWithValue("@skunumber", txt_Sku.Text);
            cmd.Parameters.AddWithValue("@ItemName", txt_Item_name.Text);
            cmd.Parameters.AddWithValue("@quantity", int.Parse(txt_Quantity.Text));
            cmd.Parameters.AddWithValue("@Price", int.Parse(txt_Price.Text));
            cmd.Parameters.AddWithValue("@isavailable", Convert.ToBoolean(checkBox1.Checked));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BMR8RO5\SQLEXPRESS;Initial Catalog=ProductscsharpLab;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Items  where Number=@Number ", con);
            cmd.Parameters.AddWithValue("@Number", int.Parse(txt_Number.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-BMR8RO5\SQLEXPRESS;Initial Catalog=ProductscsharpLab;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Items  where Number=@Number ", con);
            cmd.Parameters.AddWithValue("@Number", int.Parse(txt_Number.Text));
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
