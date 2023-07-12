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
using System.Text.RegularExpressions;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for ProductPage.xaml
	/// </summary>
	public partial class ProductPage : Page
	{
		public static int id_selected = -1;
		public ProductPage()
		{
			InitializeComponent();
		}

		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);

		private void fill_ComboBox()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM LOAISANPHAM";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, Con);
				SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

				DataTable dataTable = new DataTable("SANPHAM");
				sqlDataAdapter.Fill(dataTable);
				txt_LOAI_product.ItemsSource = dataTable.DefaultView;
				sqlDataAdapter.Update(dataTable);

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}

		}

		private void Clear()
		{
			txt_tensp_product.Text = "";
			txt_LOAI_product.Text = "";
			txt_NXB_product.Text = "";
			txt_gia_product.Text = "";
			txt_tacgia_product.Text = "";
			txt_soluong_product.Text = "";
			imageURL = null;
			id_selected = -1;
		}

		public void displayProduct()
		{
			try
			{
				CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
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
					gia = Convert.ToInt32(row["GIA"]).ToString("#,### VND", cul);
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

		#region save delete reset button event
		private void btn_save_product_Click(object sender, RoutedEventArgs e)
		{

			if (txt_tacgia_product.Text == "" || txt_tensp_product.Text == "" || txt_LOAI_product.Text == "" || txt_NXB_product.Text == "" || txt_gia_product.Text == "" || txt_soluong_product.Text == "" || imageURL == null)
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else if (!Regex.IsMatch(txt_gia_product.Text, @"^[0-9]+$")|| !Regex.IsMatch(txt_soluong_product.Text, @"^[0-9]+$"))
			{
				MessageBox.Show("Giá hoặc số lượng phải là số nguyên dương");
			}
			else
			{
				try
				{
					Con.Open();

					SqlCommand command = new SqlCommand("INSERT INTO SANPHAM (TENSP,MALOAI,NXB,GIA,SLUONG,TacGia,PHOTO,PHOTOURL) VALUES (@TENSP,@MALOAI,@NXB,@GIA,@SLUONG,@TACGIA,@PHOTO,@PHOTOURL)", Con);

					command.Parameters.AddWithValue("@TENSP", txt_tensp_product.Text);
					command.Parameters.AddWithValue("@MALOAI", txt_MALOAI_hidden.Text);
					command.Parameters.AddWithValue("@NXB", txt_NXB_product.Text);
					command.Parameters.AddWithValue("@GIA", txt_gia_product.Text);
					command.Parameters.AddWithValue("@SLUONG", txt_soluong_product.Text);
					command.Parameters.AddWithValue("@TACGIA", txt_tacgia_product.Text);

					command.Parameters.AddWithValue("@PHOTO", _imageBytes);
					command.Parameters.AddWithValue("@PHOTOURL", imageURL);


					command.ExecuteNonQuery();
					MessageBox.Show("Đã thêm sản phẩm thành công");

					Con.Close();
					imageURL = null;
					displayProduct();
					Clear();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Con.Close();
				}
			}
		}

		private void btn_clear_product_Click(object sender, RoutedEventArgs e)
		{
			Clear();
			displayProduct();
		}

		private void btn_delete_product_Click(object sender, RoutedEventArgs e)
		{
			if (id_selected < 1)
			{
				MessageBox.Show("Hãy chọn sản phẩm cần xoá!!!");
			}
			else
			{

				string name;
				{
					Con.Open();
					string query = "SELECT TENSP FROM SANPHAM WHERE MASP=@MASP";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MASP", id_selected);

					name = cmd.ExecuteScalar().ToString();
					Con.Close();
				}

				MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xoá sản phẩm "+name+"?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						Con.Open();

						SqlCommand command = new SqlCommand("DELETE FROM SANPHAM WHERE MASP=@ID", Con);
						command.Parameters.AddWithValue("@ID", id_selected);

						command.ExecuteNonQuery();
						MessageBox.Show("Đã xoá sản phẩm thành công");

						Con.Close();
						displayProduct();
						Clear();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
						Con.Close();
					}
				}

			}
		}
		#endregion

		#region search box
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
				sqlCommand.Parameters.AddWithValue("@param", txbx_textfilter.Text.ToString());

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable("SANPHAM");
				sqlDataAdapter.Fill(dataTable);

				CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
				List<ItemConTrol_product> _list = new List<ItemConTrol_product>();
				foreach (DataRow row in dataTable.Rows)
				{
					int masp;
					string tensp, loai, photourl, gia, soluong;

					masp = Convert.ToInt32(row["MASP"]);
					tensp = row["TENSP"].ToString();
					loai = row["LOAI"].ToString();
					photourl = row["PHOTOURL"].ToString();
					gia = Convert.ToInt32(row["GIA"]).ToString("#,### VND", cul);
					soluong = row["SLUONG"].ToString();

					_list.Add(
						new ItemConTrol_product(masp,tensp,loai,soluong,gia,photourl)
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

		private void txbx_textfilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			displayProductForSearch();
		}
		#endregion

		private void btn_themloaisach_product_Click(object sender, RoutedEventArgs e)
		{
			if (txt_tenloai_product.Text == "")
			{
				MessageBox.Show("Hãy nhập tên loại!!!");
			}
			else
			{
				try
				{
					Con.Open();
					SqlCommand command = new SqlCommand("INSERT INTO LOAISANPHAM (LOAI) VALUES (@LOAI)", Con);

					command.Parameters.AddWithValue("@LOAI", txt_tenloai_product.Text);

					command.ExecuteNonQuery();
					MessageBox.Show("Đã thêm loại sách thành công");

					Con.Close();
					fill_ComboBox();
					displayProduct();
					txt_tenloai_product.Text = "";
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Con.Close();
				}
			}
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			fill_ComboBox();
			displayProduct();
		}

		#region image

		string imageURL = null;
		private byte[] _imageBytes = null;

		void Browse()
		{
			try
			{
				OpenFileDialog openFileDialog = new OpenFileDialog()
				{
					CheckFileExists = true,
					Multiselect = false,
					Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
				};

				if (openFileDialog.ShowDialog() == true)
				{
					imageURL = openFileDialog.FileName;
					image_box.Source = new BitmapImage(new Uri(imageURL));
				}

				using (var fs = new FileStream(imageURL, FileMode.Open, FileAccess.Read))
				{
					_imageBytes = new byte[fs.Length];
					fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private void btn_addimage_Click(object sender, RoutedEventArgs e)
		{
			Browse();
		}

		#endregion

		private void btn_item_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			var dataObject = button.DataContext as ItemConTrol_product;

			id_selected = Convert.ToInt32(dataObject._masp);
		}

		private void btn_item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Button button = sender as Button;
			var dataObject = button.DataContext as ItemConTrol_product;

			id_selected = Convert.ToInt32(dataObject._masp);
			_window_edit.ChinhSuaSach window = new _window_edit.ChinhSuaSach(this);
			window.ShowDialog();
		}
	}

	public class ItemConTrol_product
	{
		public int? _masp { get; set; }
		public string _tensp { get; set; }
		public string _loai { get; set; }
		public string _soluong { get; set; }
		public string _gia { get; set; }
		public string _photourl { get; set; }

		public ItemConTrol_product()
		{
			_masp = null;
			_tensp = null;
			_loai = null;
			_soluong = null;
			_gia = null;
			_photourl = null;
		}

		public ItemConTrol_product(int? masp, string tensp, string loai, string soluong, string gia, string photourl)
		{
			_masp = masp;
			_tensp = tensp;
			_loai = loai;
			_soluong = soluong;
			_gia = gia;
			_photourl = photourl;
		}
	}
}
