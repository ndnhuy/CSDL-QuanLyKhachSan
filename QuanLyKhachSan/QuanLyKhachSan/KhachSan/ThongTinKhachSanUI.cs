using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.KhachSan
{
    public partial class ThongTinKhachSanUI : Form
    {
        private BindingSource khachsanBindingSource = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public ThongTinKhachSanUI()
        {
            InitializeComponent();
            

            // Người dùng chỉ được nhập số vào ô giá cả
            this.txtFrom.KeyPress += new KeyPressEventHandler(GiaTextBox_KeyPress);
            this.txtTo.KeyPress += new KeyPressEventHandler(GiaTextBox_KeyPress);
        }

        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                khachsanBindingSource.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                gridviewKhachSan.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("Đã xảy ra lỗi.");
            }
        }

        private void ThongTinKhachSanUI_Load(object sender, EventArgs e)
        {
            this.comboboxHangSao.SelectedIndex = 2;
            this.checkboxGiaTB.Checked = false;
            this.checkboxHangSao.Checked = false;
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
            comboboxHangSao.Enabled = false;

            gridviewKhachSan.DataSource = khachsanBindingSource;

            GetData(getQuery());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            GetData(getQuery());
        }

        string getQuery()
        {
            if (checkboxGiaTB.Checked && checkboxHangSao.Checked)
            {
                return String.Format("select * from KhachSan where ( (giaTB > {0} AND giaTB < {1}) and (soSao = {2}) ) and thanhPho = {3}",
                                    txtFrom.Text == "" ? "0" : txtFrom.Text,
                                    txtTo.Text == "" ? "0" : txtTo.Text,
                                    comboboxHangSao.SelectedItem,
                                    "'" + txtThanhPho.Text + "'"
                                    );
            }

            if (checkboxGiaTB.Checked)
            {
                return String.Format("select * from KhachSan where (giaTB > {0} AND giaTB < {1}) AND thanhPho = {2}",
                                    txtFrom.Text == "" ? "0" : txtFrom.Text,
                                    txtTo.Text == "" ? "0" : txtTo.Text,
                                    "'" + txtThanhPho.Text + "'"
                                    );
            }

            if (checkboxHangSao.Checked)
            {
                return String.Format("select * from KhachSan where soSao = {0} AND thanhPho = {1}",
                                    comboboxHangSao.SelectedItem,
                                    "'" + txtThanhPho.Text + "'"
                                    );
            }

            return String.Format("select * from KhachSan where thanhPho = {0}",
                                "'" + txtThanhPho.Text + "'"
                                );
        }


        private void GiaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkboxGiaTB_CheckedChanged(object sender, EventArgs e)
        {
            txtFrom.Enabled = ((CheckBox)sender).Checked;
            txtTo.Enabled = ((CheckBox)sender).Checked; 
        }

        private void checkboxHangSao_CheckedChanged(object sender, EventArgs e)
        {
            comboboxHangSao.Enabled = ((CheckBox)sender).Checked;
        }
    }
}
