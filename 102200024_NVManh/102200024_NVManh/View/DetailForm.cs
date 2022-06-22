using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _102200024_NVManh.BLL;
using _102200024_NVManh.DAL;
using _102200024_NVManh.DTO;

namespace _102200024_NVManh
{
    public partial class DetailForm : Form
    {
        SanPhamView sanPhamView;
        MainForm mainForm;
        string ev;
        public DetailForm(string _event,SanPhamView _sanPhamView,MainForm _mainForm)
        {
            InitializeComponent();
            sanPhamView = _sanPhamView;
            mainForm = _mainForm;
            ev = _event;
            if (_event == "edit") ShowDetail();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            cbb_tenTP.Items.Add("All");
            cbb_tenNCC.Items.Add("All");
            cbb_tenTP.Items.AddRange(DiaChiBLL.Instance.GetAllTenTP().ToArray());
            cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCC().ToArray());
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            //   txtNgayNhap.Text = dateTimePicker1.Value.ToString();
        }

        public void ShowDetail()
        {
            txtMaSP.Text = sanPhamView.maSP;
            txtTenSP.Text = sanPhamView.tenSP;
            txtSoLuong.Text = sanPhamView.soLuongSP.ToString();
            dateTimePicker1.Value = sanPhamView.ngayNhap;
            txtGiaNhap.Text = sanPhamView.giaNhap.ToString();
            cbTinhTrang.Checked = sanPhamView.tinhTrang;
            cbb_tenTP.Text = sanPhamView.tenTP;
            cbb_tenNCC.Text = sanPhamView.tenNCC;
        }

        public void SetComboBox()
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            bool tt;
            if (cbTinhTrang.Checked) tt = true;
            else tt = false;

            if (ev == "add")
            {
                try
                {
                    SanPhamBLL.Instance.AddSanPham(new SanPham
                    {
                        maSP = txtMaSP.Text,
                        tenSP = txtTenSP.Text,
                        giaNhap = float.Parse(txtGiaNhap.Text),
                        ngayNhap = dateTimePicker1.Value,
                        maNCC = SanPhamBLL.Instance.getMaNCCbyName(cbb_tenNCC.Text),
                        tinhTrang = tt,
                        soLuongSP = int.Parse(txtSoLuong.Text)
                    });
                    MessageBox.Show("Add Success !");
                    Reset_txt();
                }
                catch
                {
                    MessageBox.Show("Add false !!!");
                }
            }
            else
            {
                try
                {
                    SanPhamBLL.Instance.EditSanPham(new SanPham
                    {
                        maSP = txtMaSP.Text,
                        tenSP = txtTenSP.Text,
                        giaNhap = float.Parse(txtGiaNhap.Text),
                        ngayNhap = dateTimePicker1.Value,
                        maNCC = SanPhamBLL.Instance.getMaNCCbyName(cbb_tenNCC.Text),
                        tinhTrang = tt,
                        soLuongSP = int.Parse(txtSoLuong.Text),
                    });
                    MessageBox.Show("Edit Success !");
                }
                catch
                {
                    MessageBox.Show("Edit false !!!");
                }
            }
            mainForm.LoadMain();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbb_tenTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_tenTP.Text == "All")
            {
                cbb_tenNCC.Items.Clear();
                cbb_tenNCC.Items.Add("All");
                cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCC().ToArray());
            }
            else
            {
                cbb_tenNCC.Items.Clear();
                cbb_tenNCC.Text = "";
                cbb_tenNCC.Items.AddRange(NhaCungCapBLL.Instance.GetAllTenNCCbyTP(cbb_tenTP.Text).ToArray());
            }
        }

        public void Reset_txt()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaNhap.Text = "";
            txtSoLuong.Text = "";
            cbTinhTrang.Checked = false;
        }
    }
}
