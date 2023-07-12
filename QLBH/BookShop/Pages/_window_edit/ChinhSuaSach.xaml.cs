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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BookShop.Pages._window_edit
{
	/// <summary>
	/// Interaction logic for ChinhSuaSach.xaml
	/// </summary>
	public partial class ChinhSuaSach : Window
	{
		public int id_sp = ProductPage.id_selected;
		public ChinhSuaSach(ProductPage page)
		{
			InitializeComponent();
			product = page;
		}
		ProductPage product;

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

		void displayInfo()
		{
			string tensp = "", loai = "", gia = "", nxb = "", tacgia = "", sl = "", photourl = "";
			try
			{
				string query = "SELECT TENSP,LOAI,GIA,NXB,TacGia,SLUONG,PHOTOURL FROM SANPHAM,LOAISANPHAM WHERE SANPHAM.MALOAI=LOAISANPHAM.MALOAI and MASP=" + id_sp;
				Con.Open();
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();

				while (dataReader.Read())
				{
					tensp = dataReader.GetString(0);
					loai = dataReader.GetString(1);
					gia = dataReader.GetInt32(2).ToString();
					nxb = dataReader.GetString(3);
					tacgia = dataReader.GetString(4);
					sl = dataReader.GetInt32(5).ToString();
					photourl = dataReader.GetString(6);
				}

				Con.Close();
				txt_tensp_product.Text = tensp;
				txt_LOAI_product.Text = loai;
				txt_gia_product.Text = gia;
				txt_NXB_product.Text = nxb;
				txt_tacgia_product.Text = tacgia;
				txt_soluong_product.Text = sl;

				if (photourl != "")
					image_box.ImageSource = LoadImage(photourl);
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}


		}
		public ImageSource LoadImage(string filename)
		{
			var bitmap = new BitmapImage();
			try
			{
				var stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

				bitmap.BeginInit();
				bitmap.DecodePixelWidth = 200;
				bitmap.CacheOption = BitmapCacheOption.OnLoad;
				bitmap.StreamSource = stream;
				bitmap.EndInit();
				bitmap.Freeze();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return bitmap;
		}
		void Save()
		{
			if (txt_themsoluong.Text==""|| txt_tensp_product.Text == "" || txt_tacgia_product.Text ==""||txt_soluong_product.Text==""||txt_NXB_product.Text==""||txt_LOAI_product.Text==""||txt_gia_product.Text=="")
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin");
			}
			else if (!Regex.IsMatch(txt_gia_product.Text, @"^[0-9]+$") || !Regex.IsMatch(txt_themsoluong.Text, @"^[0-9]+$"))
			{
				MessageBox.Show("Giá hoặc số lượng phải là số nguyên dương");
			}
			else
			{
				try
				{
					txt_soluong_product.Text = (Convert.ToInt32(txt_soluong_product.Text) + Convert.ToInt32(txt_themsoluong.Text)).ToString();
					Con.Open();

					SqlCommand command = new SqlCommand("UPDATE SANPHAM SET TENSP=@TENSP,MALOAI=@MALOAI,NXB=@NXB,GIA=@GIA,SLUONG=@SLUONG,TacGia=@TACGIA WHERE MASP=@ID", Con);

					command.Parameters.AddWithValue("@TENSP", txt_tensp_product.Text);
					command.Parameters.AddWithValue("@MALOAI", txt_MALOAI_hidden.Text);
					command.Parameters.AddWithValue("@NXB", txt_NXB_product.Text);
					command.Parameters.AddWithValue("@GIA", txt_gia_product.Text);
					command.Parameters.AddWithValue("@SLUONG", txt_soluong_product.Text);
					command.Parameters.AddWithValue("@TACGIA", txt_tacgia_product.Text);
					command.Parameters.AddWithValue("@ID", id_sp);


					command.ExecuteNonQuery();
					MessageBox.Show("Đã chỉnh sửa sản phẩm thành công");

					Con.Close();

				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Con.Close();
				}

				if (isBrowse)
				{
					try
					{
						Con.Open();
						SqlCommand command = new SqlCommand("UPDATE SANPHAM SET PHOTO=@PHOTO,PHOTOURL=@PHOTOURL WHERE MASP=@ID", Con);

						command.Parameters.AddWithValue("PHOTO", _imageBytes);
						command.Parameters.AddWithValue("@PHOTOURL", imageURL);
						command.Parameters.AddWithValue("@ID", id_sp);
						command.ExecuteNonQuery();

						Con.Close();
						imageURL = null;
						isBrowse = false;
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message); Con.Close();
					}
				}
			}
		

		}

		private void btn_close_Click(object sender, RoutedEventArgs e)
		{
			ProductPage.id_selected = -1;	
			this.Close();
		}

		private void btn_save_Click(object sender, RoutedEventArgs e)
		{
			Save();
			product.displayProduct();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			fill_ComboBox();
			displayInfo();
		}

		#region image

		string imageURL = null;
		private byte[] _imageBytes = null;
		bool isBrowse = false;
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
					image_box.ImageSource = new BitmapImage(new Uri(imageURL));
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
			isBrowse = true;
		}

		#endregion
	}
}
