using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Globalization;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for BillPage.xaml
	/// </summary>
	public partial class BillPage : Page
	{
		DataTable tb_hoadon = new DataTable();
		DataTable billTable = new DataTable();
		private bool isSort;
		
		public BillPage()
		{
			InitializeComponent();

		}
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);

		private void displayBill()
		{

			try
			{
				CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
				string Query = "select SOHD,NHANVIEN.HOTEN,KHACHHANG.HOTEN as TENKH,NGHD,TRIGIA,TRATRUOC,THANHTOAN,GIAOHANG from HOADON,KHACHHANG,NHANVIEN where HOADON.MANV = NHANVIEN.MANV and KHACHHANG.MAKH = HOADON.MAKH";
				Con.Close();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, Con);
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

				DataTable dataTable = new DataTable("HOADON");
				sqlDataAdapter.Fill(dataTable);
				
				list_Bill_HOADON.ItemsSource = dataTable.DefaultView;
				sqlDataAdapter.Update(dataTable);
				
				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Khởi tạo cho cửa sổ in
		/// </summary>
		private void Info_PrintWindow()
		{
			int sohd = Convert.ToInt32(hidden_sohd.Text.ToString());
			string query;

			string cusname;
			{
				Con.Open();
				query = "SELECT HOTEN FROM KHACHHANG,HOADON WHERE SOHD=@SOHD AND KHACHHANG.MAKH=HOADON.MAKH";
				SqlCommand cmd = new SqlCommand(query, Con);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@SOHD", sohd);

				cusname = cmd.ExecuteScalar().ToString();
				Con.Close();
			}

			string empname;
			{
				Con.Open();
				query = "SELECT HOTEN FROM NHANVIEN,HOADON WHERE SOHD=@SOHD AND NHANVIEN.MANV=HOADON.MANV";
				SqlCommand cmd = new SqlCommand(query, Con);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@SOHD", sohd);

				empname = cmd.ExecuteScalar().ToString();
				Con.Close();
			}

			int trigia = 0;
			{
				Con.Open();
				query = "SELECT TRIGIA FROM HOADON WHERE SOHD=@SOHD";
				SqlCommand cmd = new SqlCommand(query, Con);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@SOHD", sohd);

				trigia = Convert.ToInt32(cmd.ExecuteScalar().ToString());
				trigia = Convert.ToInt32(cmd.ExecuteScalar().ToString());
				Con.Close();
			}
			CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
			PrintPreview.pr_tennv = empname;
			PrintPreview.pr_cusname = cusname;
			PrintPreview.pr_sohd = sohd.ToString();
			PrintPreview.pr_sotien = Convert.ToInt32(trigia).ToString("#,### VND", cul);

			PrintPreview.initTable();
			try
			{
				query = "select CTHD.SL as COL_SL, SANPHAM.TENSP as COL_TEN, SANPHAM.GIA as COL_GIA, LOAISANPHAM.LOAI as COL_LOAI from CTHD,SANPHAM,LOAISANPHAM ";
				query+=" where (CTHD.MASP=SANPHAM.MASP) AND (SANPHAM.MALOAI=LOAISANPHAM.MALOAI) and (SOHD='" + sohd.ToString()+"')";
				Con.Open();
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					DataRow dr = PrintPreview.pr_billTB.NewRow();
					int sl = dataReader.GetInt32(0);
					string tensp = dataReader.GetString(1);
					int gia = dataReader.GetInt32(2);
					string loai = dataReader.GetString(3);

					dr["qty"] = sl;
					dr["name"] = tensp;
					dr["price"] = gia;
					dr["loai"] = loai;
					dr["sum"] = sl * gia;
					PrintPreview.pr_billTB.Rows.Add(dr);
				}

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}

		}

		private void btn_print_Click(object sender, RoutedEventArgs e)
		{
			if (hidden_sohd.Text=="")
			{
				MessageBox.Show("Hãy chọn hoá đơn cần in!");
			}
			else
			{
				Info_PrintWindow();
				PrintPreview pr = new PrintPreview();
				pr.ShowDialog();
			}
		}

		#region gridviewcolumnHeader
		private string column = "";
		private void SortColumn(object item)
		{
			try
			{
				CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(item);

				if (isSort)
				{
					view.SortDescriptions.Clear();
					view.SortDescriptions.Add(new SortDescription(column, ListSortDirection.Descending));
				}
				else
				{
					view.SortDescriptions.Clear();
					view.SortDescriptions.Add(new SortDescription(column, ListSortDirection.Ascending));
				}
				isSort = !isSort;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			

		}
		#region HOADON
		private void GridViewColumnHeader_SOHD_Click(object sender, RoutedEventArgs e)
		{
			column = "SOHD";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_HOTEN_Click(object sender, RoutedEventArgs e)
		{
			column = "HOTEN";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_TENKH_Click(object sender, RoutedEventArgs e)
		{
			column = "TENKH";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_NGHD_Click(object sender, RoutedEventArgs e)
		{
			column = "NGHD";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_TRIGIA_Click(object sender, RoutedEventArgs e)
		{
			column = "TRIGIA";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_TRATRUOC_Click(object sender, RoutedEventArgs e)
		{
			column = "TRATRUOC";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_THANHTOAN_Click(object sender, RoutedEventArgs e)
		{
			column = "THANHTOAN";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		private void GridViewColumnHeader_GIAOHANG_Click(object sender, RoutedEventArgs e)
		{
			column = "GIAOHANG";
			if (list_Bill_HOADON.Items.Count > 0)
				SortColumn(list_Bill_HOADON.ItemsSource);
		}
		#endregion

		#endregion

		private void displayBillForSearch()
		{
			
			try
			{
				Con.Open();
				string Query = "select SOHD, NHANVIEN.HOTEN,KHACHHANG.HOTEN as TENKH,NGHD,TRIGIA,TRATRUOC,TRIGIA,THANHTOAN,GIAOHANG from HOADON,KHACHHANG,NHANVIEN where (HOADON.MANV = NHANVIEN.MANV and KHACHHANG.MAKH = HOADON.MAKH)";
				Query += " AND (SOHD LIKE '%'+@param+'%' ";
				Query += " or NHANVIEN.HOTEN LIKE '%'+@param+'%' ";
				Query += " or KHACHHANG.HOTEN LIKE '%'+@param+'%' ";
				Query += " or NGHD LIKE '%'+@param+'%' ";
				Query += " or TRATRUOC LIKE '%'+@param+'%' ";
				Query += " or THANHTOAN LIKE '%'+@param+'%' ";
				Query += " or GIAOHANG LIKE '%'+@param+'%' ";
				Query += " or TRIGIA LIKE '%'+@param+'%' )";
				SqlCommand sqlCommand = new SqlCommand(Query, Con);
				sqlCommand.Parameters.AddWithValue("@param", txbx_textfilter_HoaDon.Text.ToString());

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable("HOADON");
				sqlDataAdapter.Fill(dataTable);
				list_Bill_HOADON.ItemsSource = dataTable.DefaultView;
				sqlDataAdapter.Update(dataTable);

				Con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Con.Close();
			}

		}
	
		private void txbx_textfilter_HoaDon_TextChanged(object sender, TextChangedEventArgs e)
		{
			displayBillForSearch();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			isSort = true;
			displayBill();
		}

		private void btn_dathanhtoan_Click(object sender, RoutedEventArgs e)
		{
			if (hidden_sohd.Text == "")
			{
				MessageBox.Show("Hãy chọn hoá đơn cần thay đổi");
			}
			else
			{
				System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Xác nhận khách hàng đã thanh toán?", "Thông báo", System.Windows.Forms.MessageBoxButtons.YesNo);
				if (dr == System.Windows.Forms.DialogResult.Yes)
				{
					try
					{
						Con.Open();

						SqlCommand command = new SqlCommand("UPDATE HOADON SET THANHTOAN=N'Đã thanh toán',TRATRUOC=TRIGIA WHERE SOHD=@params", Con);
						command.Parameters.AddWithValue("@params", hidden_sohd.Text);

						command.ExecuteNonQuery();
						displayBill();

						Con.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message); Con.Close();
					}
				}
			}
		}

		private void btn_dagiaohang_Click(object sender, RoutedEventArgs e)
		{
			if (hidden_sohd.Text == "")
			{
				MessageBox.Show("Hãy chọn hoá đơn cần thay đổi");
			}
			else
			{
				System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Xác nhận đã giao hàng?", "Thông báo", System.Windows.Forms.MessageBoxButtons.YesNo);
				if (dr == System.Windows.Forms.DialogResult.Yes)
				{
					try
					{
						Con.Open();

						SqlCommand command = new SqlCommand("UPDATE HOADON SET GIAOHANG=N'Đã giao hàng' WHERE SOHD=@params", Con);
						command.Parameters.AddWithValue("@params", hidden_sohd.Text);

						command.ExecuteNonQuery();
						displayBill();
						Con.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message); Con.Close();
					}
				}
			}
		}

		private void btn_capnhattratruoc_Click(object sender, RoutedEventArgs e)
		{
			int t;
			bool check = int.TryParse(txt_tratruoc.Text, out t);
			if (hidden_sohd.Text == "")
			{
				MessageBox.Show("Hãy chọn hoá đơn cần thay đổi");
			}
			else if (!check || t < 0)
			{
				MessageBox.Show("Hãy nhập số thích hợp");
			}
			else
			{
				try
				{
					Con.Open();

					SqlCommand command = new SqlCommand("UPDATE HOADON SET TRATRUOC=@TRATRUOC WHERE SOHD=@params and THANHTOAN=N'Chưa thanh toán'", Con);
					command.Parameters.AddWithValue("@params", hidden_sohd.Text);
					command.Parameters.AddWithValue("@TRATRUOC", txt_tratruoc.Text);

					command.ExecuteNonQuery();
					displayBill();
					Con.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message); Con.Close();
				}
			}
		}
	}
}
