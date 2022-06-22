using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _102200024_NVManh.BLL;//+
using _102200024_NVManh.DTO;//+
using _102200024_NVManh.DAL;//+

namespace _102200024_NVManh
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetComboBox();
        }

        public void SetComboBox()
        {
        }

        SanPhamView sanPhamView;
        int count_select;
        string maSP;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DetailForm detailForm = new DetailForm("add",sanPhamView,this);
            detailForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (count_select > 0)
            {
                DetailForm detailForm = new DetailForm("edit", sanPhamView, this);
                detailForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to Edit !!!");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (count_select > 0)
            {
                SanPhamBLL.Instance.DeleteSanPham(maSP);
                MessageBox.Show("Delete Success !");
                MainForm_Load(sender,e);
            }
            else
            {
                MessageBox.Show("Please select a row to Delete !!!");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cbbSort.Text != "")
            {
                dataGridView1.DataSource = SanPhamBLL.Instance.SortAllSanPhamView(cbbSort.Text);
            }
            else
            {
                MessageBox.Show("Hãy chọn một tiêu chí để sắp xếp !!!");
            }
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            LoadMain();
        }

        public void LoadMain()
        {
            dataGridView1.DataSource = SanPhamBLL.Instance.GetAllSanPhamView();
            cbb_tenTP.Items.Add("All");
            cbb_tenTP.Items.AddRange(DiaChiBLL.Instance.GetAllTenTP().ToArray());
            cbb_tenNCC.Items.Add("All");
            cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCC().ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string tenNCC = cbb_tenNCC.Text;
            string text = txtSearch.Text;
            if (tenNCC == "All") tenNCC = "";
            dataGridView1.DataSource = SanPhamBLL.Instance.SearchSanPhamView(tenNCC,text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_tenTP.Text == "All")
            {
                cbb_tenNCC.Items.Clear();
                cbb_tenNCC.Items.Add("All");
                cbb_tenNCC.Text = "All";
                cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCC().ToArray());
            }
            else
            {
                cbb_tenNCC.Items.Clear();
                cbb_tenNCC.Text = "";
                cbb_tenNCC.Items.Add("All");
                cbb_tenNCC.Text = "All";
                cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCCbyTP(cbb_tenTP.Text).ToArray());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            count_select = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            maSP = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            sanPhamView = new SanPhamView
            {
                maSP = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                tenSP = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                giaNhap = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()),
                ngayNhap = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()),
                tinhTrang = bool.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()),
                tenNCC = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(),
                tenTP = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(),
                soLuongSP = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
            };
        }
        // vì ID của sản phẩm tự nhập nên còn cái kiểm tra ID đó đã tồn tại hay chưa nữa . 
    }
}
