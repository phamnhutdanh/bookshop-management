using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for SuaThongTin.xaml
	/// </summary>
	public partial class SuaThongTin : Window
	{
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		public SuaThongTin(MainWindow main)
		{
			InitializeComponent();
			_main = main;
		}

		private MainWindow _main;

		void displayInfo()
		{
			string hoten = "", sdt = "", gioitinh = "", diachi = "", ngaysinh = "", path = "";
			try
			{
				string query = "SELECT HOTEN,SDT,GIOITINH,DCHI,NGSINH,PHOTOURL FROM NHANVIEN WHERE MANV="+Login.manv;
				Con.Open();
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();

				while(dataReader.Read())
				{
					hoten = dataReader.GetString(0);
					sdt = dataReader.GetString(1);
					gioitinh = dataReader.GetString(2);
					diachi = dataReader.GetString(3);
					ngaysinh = dataReader.GetDateTime(4).ToString();
					path = dataReader.GetString(5);
				}

				Con.Close();
				txt_name_empl.Text = hoten;
				txt_phone_empl.Text = sdt;
				txt_gioitinh_empl.Text = gioitinh;
				txt_address_empl.Text = diachi;
				date_NgaySinh_empl.Text = ngaysinh;

				if (path != "")
					image_box.ImageSource = LoadImage(path);
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
			if (date_NgaySinh_empl.Text == "" || txt_name_empl.Text == "" || txt_address_empl.Text == "" || txt_gioitinh_empl.Text == "" || txt_phone_empl.Text == "")
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else if (!Regex.IsMatch(txt_phone_empl.Text, @"^[0-9]+$"))
			{
				MessageBox.Show("SDT phải là dãy số");
			}
			else
			{
				try
				{
					Con.Open();
					SqlCommand command = new SqlCommand("UPDATE NHANVIEN SET HOTEN=@HOTEN,GIOITINH=@GIOITINH,SDT=@SDT,DCHI=@DCHI,NGSINH=@NGSINH WHERE MANV=@MANV", Con);

					command.Parameters.AddWithValue("@HOTEN", txt_name_empl.Text);
					command.Parameters.AddWithValue("@GIOITINH", txt_gioitinh_empl.Text);
					command.Parameters.AddWithValue("@SDT", txt_phone_empl.Text);
					command.Parameters.AddWithValue("@DCHI", txt_address_empl.Text);
					command.Parameters.AddWithValue("@NGSINH", date_NgaySinh_empl.Text);
					command.Parameters.AddWithValue("@MANV", Login.manv);
					command.ExecuteNonQuery();
					MessageBox.Show("Đã lưu thông tin thành công");

					Con.Close();
				}
				catch (Exception ex)
				{
					Con.Close();
					MessageBox.Show(ex.Message);
				}


				if (isBrowse)
				{
					try
					{
						Con.Open();
						SqlCommand command = new SqlCommand("UPDATE NHANVIEN SET PHOTO=@PHOTO,PHOTOURL=@PHOTOURL WHERE MANV=@MANV", Con);

						command.Parameters.AddWithValue("@PHOTO", _imageBytes);
						command.Parameters.AddWithValue("@PHOTOURL", imageURL);
						command.Parameters.AddWithValue("@MANV", Login.manv);
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
			this.Close();
		}

		private void btn_save_Click(object sender, RoutedEventArgs e)
		{
			Save();
			_main.displayInfo();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
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
