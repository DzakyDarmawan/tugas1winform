using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace crud_jek
{
    public partial class Form3 : Form
    {

        private NpgsqlConnection connection;
        private string koneksi = "Server=localhost;Port=5432;User Id=postgres;Password=Jack2002;Database=dzaky;";
        private NpgsqlDataAdapter Adapter;
        private DataTable tabel;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(koneksi);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO jack2(nama, tgl, laptop, stok) " +
                "VALUES (@value1, @value2, @value3, @value4)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            command.ExecuteNonQuery();
            tabel = new DataTable();
            Adapter = new NpgsqlDataAdapter("select * FROM jack2 order by id", connection);
            Adapter.Fill(tabel);
            connection.Close();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tabel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
