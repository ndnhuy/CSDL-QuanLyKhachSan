using QuanLyKhachSan.Phong;
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
                String connectionString =
                    ConfigurationManager.ConnectionStrings["QuanLyKhachSan"].ConnectionString;

                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                khachsanBindingSource.DataSource = table;
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
            gridviewKhachSan.SelectionChanged += GridviewKhachSan_SelectionChanged;


            gridviewKhachSan.DataSource = khachsanBindingSource;

            GetData(getQuery());
        }

        private void GridviewKhachSan_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void GridviewKhachSan_HandleCreated(object sender, EventArgs e)
        {
            Console.Write("CREATED");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            GetData(getQuery());
         
        }

        string getQuery()
        {
            if (checkboxGiaTB.Checked && checkboxHangSao.Checked)
            {
                return String.Format("select * from KhachSan where ( (giaTB > {0} AND giaTB < {1}) and (soSao = {2}) ) and thanhPho = N'{3}'",
                                    txtFrom.Text == "" ? "0" : txtFrom.Text,
                                    txtTo.Text == "" ? "0" : txtTo.Text,
                                    comboboxHangSao.SelectedItem,
                                    txtThanhPho.Text
                                    );
            }

            if (checkboxGiaTB.Checked)
            {
                return String.Format("select * from KhachSan where (giaTB > {0} AND giaTB < {1}) AND thanhPho = N'{2}'",
                                    txtFrom.Text == "" ? "0" : txtFrom.Text,
                                    txtTo.Text == "" ? "0" : txtTo.Text,
                                    txtThanhPho.Text
                                    );
            }

            if (checkboxHangSao.Checked)
            {
                return String.Format("select * from KhachSan where soSao = {0} AND thanhPho = N'{1}'",
                                    comboboxHangSao.SelectedItem,
                                    txtThanhPho.Text
                                    );
            }

            return String.Format("select * from KhachSan where thanhPho = N'{0}'",
                                txtThanhPho.Text
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

        private void gridviewKhachSan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gridviewKhachSan.SelectedRows[0].Cells["maKS"].Value.ToString());
            new DatPhongUI((int)gridviewKhachSan.SelectedRows[0].Cells["maKS"].Value).Show();
            Hide();
        }
    }
}
