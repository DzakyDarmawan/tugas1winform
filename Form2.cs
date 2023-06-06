using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_jek
{
    public partial class Form2 : Form
    {
        private NpgsqlConnection connection;
        private string koneksi = "Server=localhost;Port=5432;User Id=postgres;Password=Jack2002;Database=dzaky;";
        private NpgsqlDataAdapter Adapter;
        private DataTable tabel;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(koneksi);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO jack(laptop, harga, stok) " +
                "VALUES (@value1, @value2, @value3)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data created success");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(koneksi);
            tabel = new DataTable();
            Adapter = new NpgsqlDataAdapter("select * FROM jack order by id", connection);
            connection.Open();
            Adapter.Fill(tabel);
            connection.Close();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tabel;
        }
    }
}
