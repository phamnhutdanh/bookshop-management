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
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for AddToBillPage.xaml
	/// </summary>
	public partial class AddToBillPage : Page
	{
		private int id_selected = -1;
		private string loai = "";
		private int sluong = -1;
		DataTable tb_hoadon = new DataTable();
		DataTable billTable = new DataTable();
		int stt = 0;
		private bool isSort;
		public AddToBillPage()
		{
			InitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			txbl_TongTien.Text = "0";
			GetCustomers();
			createTable();
			createBillTable();
			isSort = true;
			displayProduct();
		}
		private void createBillTable()
		{
			DataColumn id = new DataColumn("id", typeof(int));
			DataColumn emp_name = new DataColumn("emp_name", typeof(string));
			DataColumn cus_name = new DataColumn("cus_name", typeof(string));
			DataColumn date = new DataColumn("date", typeof(DateTime));
			DataColumn sum = new DataColumn("sum", typeof(int));

			billTable.Columns.Add(id);
			billTable.Columns.Add(emp_name);
			billTable.Columns.Add(cus_name);
			billTable.Columns.Add(date);
			billTable.Columns.Add(sum);
		}
		private void createTable()
		{
			DataColumn n = new DataColumn("stt", typeof(int));
			DataColumn id = new DataColumn("id", typeof(int));
			DataColumn name = new DataColumn("name", typeof(string));
			DataColumn price = new DataColumn("price", typeof(int));
			DataColumn qty = new DataColumn("qty", typeof(int));
			DataColumn sum = new DataColumn("sum", typeof(int));
			DataColumn loai = new DataColumn("loai", typeof(string));

			tb_hoadon.Columns.Add(n);
			tb_hoadon.Columns.Add(id);
			tb_hoadon.Columns.Add(name);
			tb_hoadon.Columns.Add(price);
			tb_hoadon.Columns.Add(qty);
			tb_hoadon.Columns.Add(sum);
			tb_hoadon.Columns.Add(loai);
		}
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		private void displayProduct()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM SANPHAM,LOAISANPHAM WHERE SANPHAM.MALOAI=LOAISANPHAM.MALOAI";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, Con);
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

				DataTable dataTable = new DataTable("SANPHAM");
				sqlDataAdapter.Fill(dataTable);

				List<ItemConTrol_product> _list = new List<ItemConTrol_product>();
				foreach (DataRow row in dataTable.Rows)
				{
					int masp;
					string tensp, loai, photourl, gia, soluong;

					masp = Convert.ToInt32(row["MASP"]);
					tensp = row["TENSP"].ToString();
					loai = row["LOAI"].ToString();
					photourl = row["PHOTOURL"].ToString();
					gia = Convert.ToInt32(row["GIA"]).ToString();
					soluong = row["SLUONG"].ToString();

					_list.Add(
						new ItemConTrol_product(masp, tensp, loai, soluong, gia, photourl)
						);
				}

				ListViewProducts.ItemsSource = _list;

				sqlDataAdapter.Update(dataTable);

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}

		}
		private void list_Bill_SANPHAM_Loaded(object sender, RoutedEventArgs e)
		{
			displayProduct();
		}
		private void GetCustomers()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM KHACHHANG";

				SqlCommand command = new SqlCommand(Query, Con);
				SqlDataReader dataReader;
				dataReader = command.ExecuteReader();

				DataTable dt = new DataTable();
				dt.Columns.Add("ID", typeof(int));
				dt.Load(dataReader);
				cmb_IDKH_bill.DisplayMemberPath = "MAKH";
				cmb_IDKH_bill.ItemsSource = dt.DefaultView;

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}

		}

		private void btn_addToBill_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int sl;
				bool isInt = int.TryParse(txt_SOLUONG_bill.Text, out sl);

				if (txt_SOLUONG_bill.Text == "" || txt_TENKHACHHANG_bill.Text == "" || id_selected<1)
				{
					MessageBox.Show("Hãy nhập đầy đủ thông tin");
				}
				else if (sluong==0)
				{
					MessageBox.Show("Đã hết hàng!!!");
				}
				else if (Convert.ToInt32(txt_SOLUONG_bill.Text) > sluong)
				{
					MessageBox.Show("Số lượng không đủ");
				}
				else if (!isInt)
				{
					MessageBox.Show("Hãy nhập số nguyên");
				}
				else if (sl > 0)
				{
					bool isExists = false;

					if (dataGrid_Bill_CTHD.Items.Count > 0)
					{
						foreach (DataRowView item in dataGrid_Bill_CTHD.Items)
						{
							if (Convert.ToInt32(item["id"]) == id_selected)
							{
								isExists = true;
							}
						}
					}

					if (!isExists)
					{
						double total = Convert.ToDouble(txt_GIA_bill.Text.ToString()) * int.Parse(txt_SOLUONG_bill.Text.ToString());
						DataRow dr = tb_hoadon.NewRow();
						dr[0] = ++stt;
						dr[1] = id_selected;
						dr[2] = txt_TENSANPHAM_bill.Text;
						dr[3] = double.Parse(txt_GIA_bill.Text.ToString());
						dr[4] = int.Parse(txt_SOLUONG_bill.Text.ToString());
						dr[5] = total;
						dr[6] = loai;

						tb_hoadon.Rows.Add(dr);
						dataGrid_Bill_CTHD.ItemsSource = tb_hoadon.DefaultView;

					}
					else
					{
						double total = 0;
						foreach (DataRow dr in tb_hoadon.Rows)
						{
							if (Convert.ToInt32(dr["id"]) == Convert.ToInt32(id_selected))
							{
								dr["qty"] = Convert.ToInt32(txt_SOLUONG_bill.Text) + Convert.ToInt32(dr["qty"]);
								total = Convert.ToDouble(dr["price"].ToString()) * Convert.ToInt32(dr["qty"].ToString());
								dr["sum"] = total.ToString();
							}
						}

						dataGrid_Bill_CTHD.ItemsSource = tb_hoadon.DefaultView;
					}

					cmb_IDKH_bill.IsEnabled = false;
					InTongTien();

					id_selected = -1;
					sluong = -1;
					loai = "";

					txt_GIA_bill.Text = "";
					txt_SOLUONG_bill.Text = "";
					txt_TENSANPHAM_bill.Text = "";
				}
				else if (sl <= 0)
					MessageBox.Show("Hãy nhập số nguyên dương lớn hơn 0");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void InTongTien()
		{
			double tb_TOTAL = 0;
			foreach (DataRow item in tb_hoadon.Rows)
			{
				tb_TOTAL += Convert.ToDouble(item["sum"].ToString());
			}
			txbl_TongTien.Text = tb_TOTAL.ToString();
		}
		private void btn_reset_Click(object sender, RoutedEventArgs e)
		{
			stt = 0;
			txbl_TongTien.Text = "0";
			tb_hoadon.Clear();
			cmb_IDKH_bill.IsEnabled = true;
			id_selected = -1;
			sluong = -1;
			loai = "";
			txt_TENSANPHAM_bill.Text = "";
			txt_SOLUONG_bill.Text = "";
			txt_GIA_bill.Text = "";
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
				Con.Close();
			}
			CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
			PrintPreview.pr_tennv = empname;
			PrintPreview.pr_cusname = cusname;
			PrintPreview.pr_sohd = sohd.ToString();
			PrintPreview.pr_sotien = trigia.ToString("#,### VND", cul);

			PrintPreview.initTable();
			try
			{
				query = "select CTHD.SL as COL_SL, SANPHAM.TENSP as COL_TEN, SANPHAM.GIA as COL_GIA, LOAISANPHAM.LOAI as COL_LOAI from CTHD,SANPHAM,LOAISANPHAM ";
				query += " where (CTHD.MASP=SANPHAM.MASP) AND (SANPHAM.MALOAI=LOAISANPHAM.MALOAI) and (SOHD='" + sohd.ToString() + "')";
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

		bool CoTheThem = false;
		/// <summary>
		/// Thêm vào CSDL dbo.HOADON
		/// </summary>
		private void ThemVaoHoaDon()
		{
			if (dataGrid_Bill_CTHD.Items.Count == 0)
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else
			{
				try
				{
					CoTheThem = false;
					Con.Close();
					foreach (DataRow item in tb_hoadon.Rows)
					{
						int id_hd = Convert.ToInt32(item["id"].ToString());
						int sl = Convert.ToInt32(item["qty"].ToString());
						Tru_SoLuongSanPhamCoID(id_hd, sl, ref CoTheThem);
					}

					if (CoTheThem)
					{
						displayProduct();

						string query;
						int manv;
						{
							Con.Open();
							query = "SELECT MANV FROM NHANVIEN WHERE USERNAME=@USERNAME";
							SqlCommand cmd = new SqlCommand(query, Con);
							cmd.CommandType = CommandType.Text;
							cmd.Parameters.AddWithValue("@USERNAME", Login.UserName);
							manv = Convert.ToInt32(cmd.ExecuteScalar());
							Con.Close();
						}

						Con.Open();
						query = "INSERT INTO HOADON (NGHD,MAKH,MANV,TRIGIA) VALUES (@NGHD,@MAKH,@MANV,@TRIGIA)";
						SqlCommand command = new SqlCommand(query, Con);

						command.Parameters.AddWithValue("@NGHD", DateTime.Now);
						command.Parameters.AddWithValue("@MAKH", cmb_IDKH_bill.Text);
						command.Parameters.AddWithValue("@TRIGIA", Convert.ToDouble(txbl_TongTien.Text.ToString()));
						command.Parameters.AddWithValue("@MANV", manv);

						command.ExecuteNonQuery();
						Con.Close();

						//tim sohoadon va them vao cthd
						int sohd;
						{
							Con.Open();
							query = "SELECT MAX(SOHD) FROM HOADON";
							SqlCommand cmd = new SqlCommand(query, Con);
							cmd.CommandType = CommandType.Text;
							sohd = Convert.ToInt32(cmd.ExecuteScalar());
							Con.Close();
						}

						foreach (DataRow item in tb_hoadon.Rows)
						{
							ThemVaoCTHD(sohd, Convert.ToInt32(item["id"]), Convert.ToInt32(item["qty"]));
						}

					}

				}
				catch (Exception ex)
				{
					Con.Close();
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void Tru_SoLuongSanPhamCoID(int id, int soluong, ref bool CoTheThem)
		{
			try
			{
				string query;
				int sl;
				{
					Con.Open();
					query = "SELECT SLUONG FROM SANPHAM WHERE MASP=@MASP";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MASP", id);

					sl = Convert.ToInt32(cmd.ExecuteScalar());
					Con.Close();
				}

				if (sl < soluong)
				{
					MessageBox.Show("Không đủ số lượng");
					CoTheThem = false;
				}
				else
				{
					Con.Open();

					SqlCommand command = new SqlCommand("UPDATE SANPHAM SET SLUONG=@SL WHERE MASP=@MASP", Con);
					command.Parameters.AddWithValue("@SL", sl - soluong);
					command.Parameters.AddWithValue("@MASP", id);

					command.ExecuteNonQuery();

					Con.Close();
					CoTheThem = true;
				}

			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}
		}

		/// <summary>
		/// Thêm vào CSDL dbo.CTHD
		/// </summary>
		/// <param name="sohd"></param>
		/// <param name="masp"></param>
		/// <param name="soluong"></param>
		private void ThemVaoCTHD(int sohd, int masp, int soluong)
		{
			try
			{
				Con.Open();
				string query = "INSERT INTO CTHD (SOHD,MASP,SL) VALUES (@SOHD,@MASP,@SL)";
				SqlCommand command = new SqlCommand(query, Con);

				command.Parameters.AddWithValue("@SOHD", sohd);
				command.Parameters.AddWithValue("@MASP", masp);
				command.Parameters.AddWithValue("@SL", soluong);

				command.ExecuteNonQuery();

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}

		}
		private void CapNhatDoanhSoKhachHang()
		{
			try
			{
				int doanhso;
				string query;
				{
					Con.Open();
					query = "SELECT DOANHSO FROM KHACHHANG WHERE MAKH=@MAKH";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MAKH", cmb_IDKH_bill.Text);

					doanhso = Convert.ToInt32(cmd.ExecuteScalar());
					Con.Close();
				}

				Con.Open();
				SqlCommand command = new SqlCommand("UPDATE KHACHHANG SET DOANHSO=@DOANHSO WHERE MAKH=@MAKH", Con);

				command.Parameters.AddWithValue("@MAKH", cmb_IDKH_bill.Text);
				doanhso += Convert.ToInt32(txbl_TongTien.Text);
				command.Parameters.AddWithValue("@DOANHSO", doanhso);

				command.ExecuteNonQuery();

				Con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message); Con.Close();
			}
		}

		private void btn_them_Click(object sender, RoutedEventArgs e)
		{
			ThemVaoHoaDon();
			CapNhatDoanhSoKhachHang();
			cmb_IDKH_bill.IsEnabled = true;

			billTable.Clear();
			tb_hoadon.Clear();

			txt_TENSANPHAM_bill.Text = "";
			txt_GIA_bill.Text = "";
			txt_SOLUONG_bill.Text = "";
		}

		private void displayProductForSearch()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM SANPHAM,LOAISANPHAM WHERE (SANPHAM.MALOAI=LOAISANPHAM.MALOAI) AND (MASP LIKE '%'+@param+'%'";
				Query += " or TENSP LIKE '%'+@param+'%' ";
				Query += " or NXB LIKE '%'+@param+'%' ";
				Query += " or TacGia LIKE '%'+@param+'%' ";
				Query += " or LOAI LIKE '%'+@param+'%' ";
				Query += " or SLUONG LIKE '%'+@param+'%' ";
				Query += " or GIA LIKE '%'+@param+'%') ";
				SqlCommand sqlCommand = new SqlCommand(Query, Con);
				sqlCommand.Parameters.AddWithValue("@param", txbx_textfilter_SP.Text.ToString());

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable("SANPHAM");
				sqlDataAdapter.Fill(dataTable);

				List<ItemConTrol_product> _list = new List<ItemConTrol_product>();
				foreach (DataRow row in dataTable.Rows)
				{
					int masp;
					string tensp, loai, photourl, gia, soluong;

					masp = Convert.ToInt32(row["MASP"]);
					tensp = row["TENSP"].ToString();
					loai = row["LOAI"].ToString();
					photourl = row["PHOTOURL"].ToString();
					gia = Convert.ToInt32(row["GIA"]).ToString();
					soluong = row["SLUONG"].ToString();

					_list.Add(
						new ItemConTrol_product(masp, tensp, loai, soluong, gia, photourl)
						);
				}

				ListViewProducts.ItemsSource = _list;

				sqlDataAdapter.Update(dataTable);

				Con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Con.Close();
			}

		}

		private void btn_item_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			var dataObject = button.DataContext as ItemConTrol_product;

			id_selected = Convert.ToInt32(dataObject._masp);
			try
			{
					Con.Open();
					string query = "SELECT LOAI FROM SANPHAM,LOAISANPHAM WHERE SANPHAM.MALOAI=LOAISANPHAM.MALOAI AND MASP=@MASP";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MASP", id_selected);

					loai = cmd.ExecuteScalar().ToString();
					Con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			sluong = Convert.ToInt32(dataObject._soluong);

			txt_TENSANPHAM_bill.Text = dataObject._tensp.ToString();
			txt_GIA_bill.Text = dataObject._gia.ToString();
			
		}

		private void txbx_textfilter_SP_TextChanged(object sender, TextChangedEventArgs e)
		{
			displayProductForSearch();
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
		#region CTHD
		private void GridViewColumnHeader_stt_Click(object sender, RoutedEventArgs e)
		{
			column = "stt";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);
		}
		private void GridViewColumnHeader_id_Click(object sender, RoutedEventArgs e)
		{
			column = "id";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);
		}
		private void GridViewColumnHeader_name_Click(object sender, RoutedEventArgs e)
		{
			column = "name";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);
		}
		private void GridViewColumnHeader_price_Click(object sender, RoutedEventArgs e)
		{
			column = "price";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);

		}
		private void GridViewColumnHeader_qty_Click(object sender, RoutedEventArgs e)
		{
			column = "qty";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);
		}
		private void GridViewColumnHeader_sum_Click(object sender, RoutedEventArgs e)
		{
			column = "sum";
			if (dataGrid_Bill_CTHD.Items.Count > 0)
				SortColumn(dataGrid_Bill_CTHD.ItemsSource);
		}
		#endregion

		#endregion

	}
}

