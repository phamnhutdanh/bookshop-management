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
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for EmployeePage.xaml
	/// </summary>
	public partial class EmployeePage : Page
	{
		public static int id_selected=0;
		public EmployeePage()
		{
			InitializeComponent();
		}

		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		private void Clear()
		{
			txt_address_empl.Text = "";
			txt_name_empl.Text = "";
			txt_password_empl.Password = "";
			txt_username_empl.Text = "";
			txt_phone_empl.Text = "";
			date_NgaySinh_empl.Text = "";
			date_NgayVaoLam_empl.Text = "";
			txt_gioitinh_empl.Text = "";
			imageURL = null;
			id_selected = -1;
		}
		public void displayEmployee()
		{
			Con.Open();
			string Query = "SELECT * FROM NHANVIEN WHERE MANV>=1";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, Con);

			DataTable dataTable = new DataTable("NHANVIEN");
			sqlDataAdapter.Fill(dataTable);

			List<ItemControl_Employee> list_employee = new List<ItemControl_Employee>();
			foreach (DataRow row in dataTable.Rows)
			{
				int manv;
				string hoten, sdt, photourl, dchi, gioitinh;

				manv = Convert.ToInt32(row["MANV"]);
				hoten = row["HOTEN"].ToString();
				sdt = row["SDT"].ToString();
				photourl = row["PHOTOURL"].ToString();
				dchi = row["DCHI"].ToString();
				gioitinh = row["GIOITINH"].ToString();

				list_employee.Add(
					new ItemControl_Employee(manv, hoten, sdt, photourl, dchi, gioitinh)
					);
			}

			ListViewProducts.ItemsSource = list_employee;
			sqlDataAdapter.Update(dataTable);
			
			Con.Close();

		}

		private void btn_save_empl_Click(object sender, RoutedEventArgs e)
		{
			if (txt_username_empl.Text == "" || txt_password_empl.Password == "" || txt_phone_empl.Text == "" || txt_name_empl.Text == "" || txt_address_empl.Text == "" || date_NgaySinh_empl.Text == "" || date_NgayVaoLam_empl.Text == "" || imageURL==null)
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else if (!Regex.IsMatch(txt_username_empl.Text, @"^[a-zA-Z0-9]+$")|| !Regex.IsMatch(txt_password_empl.Password, @"^[a-zA-Z0-9]+$"))
			{
				MessageBox.Show("Username và Password chỉ được chứa ký tự hoặc số");
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

					SqlCommand command = new SqlCommand("INSERT INTO NHANVIEN (HOTEN,GIOITINH,SDT,DCHI,NGSINH,NGVL,USERNAME,PASS,PHOTO,PHOTOURL) VALUES (@HOTEN,@GIOITINH,@SDT,@DCHI,@NGSINH,@NGVL,@USERNAME,@PASS,@PHOTO,@PHOTOURL)", Con);

					command.Parameters.AddWithValue("@HOTEN", txt_name_empl.Text);
					command.Parameters.AddWithValue("@GIOITINH", txt_gioitinh_empl.Text);
					command.Parameters.AddWithValue("@SDT", txt_phone_empl.Text);
					command.Parameters.AddWithValue("@DCHI", txt_address_empl.Text);
					command.Parameters.AddWithValue("@NGSINH", date_NgaySinh_empl.Text);
					command.Parameters.AddWithValue("@NGVL", date_NgayVaoLam_empl.Text);
					command.Parameters.AddWithValue("@USERNAME", txt_username_empl.Text);
					command.Parameters.AddWithValue("@PASS", EncryptAndDecrypt.Encrypt(txt_password_empl.Password));

					command.Parameters.AddWithValue("@PHOTO", _imageBytes);
					command.Parameters.AddWithValue("@PHOTOURL", imageURL);
					command.ExecuteNonQuery();
					MessageBox.Show("Đã thêm nhân viên thành công");

					Con.Close();
					imageURL = null;
					displayEmployee();
					Clear();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message); Con.Close();
				}
			}

		}

		private void btn_clear_empl_Click(object sender, RoutedEventArgs e)
		{
			Clear();

			displayEmployee();
		}

		private void btn_delete_empl_Click(object sender, RoutedEventArgs e)
		{
			if (id_selected < 1)
			{
				MessageBox.Show("Hãy chọn nhân viên cần xoá!!!");
			}
			else
			{
				string empname;
				{
					Con.Open();
					string query = "SELECT HOTEN FROM NHANVIEN WHERE MANV=@MANV";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MANV", id_selected);

					empname = cmd.ExecuteScalar().ToString();
					Con.Close();
				}
				MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xoá nhân viên " + empname +"?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						Con.Open();
						SqlCommand command = new SqlCommand("DELETE FROM NHANVIEN WHERE MANV=@MANV", Con);

						command.Parameters.AddWithValue("@MANV", id_selected);

						command.ExecuteNonQuery();
						MessageBox.Show("Đã xoá nhân viên thành công");

						Con.Close();
						displayEmployee();
						Clear();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message); Con.Close();
					}
				}
			}
		}

		private void displayEmployeeForSearch()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM NHANVIEN WHERE MANV>=1 AND (MANV LIKE '%'+@param+'%'";
				Query += " or HOTEN LIKE '%'+@param+'%' ";
				Query += " or GIOITINH LIKE '%'+@param+'%' ";
				Query += " or SDT LIKE '%'+@param+'%' ";
				Query += " or DCHI LIKE '%'+@param+'%' ";
				Query += " or NGSINH LIKE '%'+@param+'%' ";
				Query += " or NGVL LIKE '%'+@param+'%' ";
				Query += " or USERNAME LIKE '%'+@param+'%' )";
				SqlCommand sqlCommand = new SqlCommand(Query,Con);
				sqlCommand.Parameters.AddWithValue("@param", txbx_textfilter.Text.ToString());

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable("NHANVIEN");
				sqlDataAdapter.Fill(dataTable);

				List<ItemControl_Employee> list_employee = new List<ItemControl_Employee>();
				foreach (DataRow row in dataTable.Rows)
				{
					int manv;
					string hoten, sdt, photourl, dchi, gioitinh;

					manv = Convert.ToInt32(row["MANV"]);
					hoten = row["HOTEN"].ToString();
					sdt = row["SDT"].ToString();
					photourl = row["PHOTOURL"].ToString();
					dchi = row["DCHI"].ToString();
					gioitinh = row["GIOITINH"].ToString();

					list_employee.Add(
						new ItemControl_Employee(manv, hoten, sdt, photourl,dchi,gioitinh)
						);
				}

				ListViewProducts.ItemsSource = list_employee;

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
			displayEmployeeForSearch();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			displayEmployee();
	
		}

		#region image

		string imageURL = null;
		private byte[] _imageBytes = null;

		//public void InsertImage(string filePath, byte[] image)
		//{
		//	try
		//	{
		//		Con.Open();
		//		string query = "INSERT INTO NHANVIEN(PHOTO,PHOTOURL) VALUES (@PHOTO,@PHOTOURL)";
		//		SqlCommand command = new SqlCommand(query, Con);
		//		command.CommandType = CommandType.Text;
		//		command.Parameters.AddWithValue("@PHOTO",image);
		//		command.Parameters.AddWithValue("@PHOTOURL", filePath);
		//		command.ExecuteNonQuery();

		//		Con.Close();
		//	}
		//	catch (Exception ex)
		//	{
		//		Con.Close();
		//		MessageBox.Show(ex.Message);
		//	}
		//}

		//void SaveImage()
		//{
		//	if (!String.IsNullOrEmpty(imageURL))
		//	{
		//		var imageBuffer = BitmapSourceToByteArray((BitmapSource)image_box.Source);
		//	}

		//}

		//private byte[] BitmapSourceToByteArray(BitmapSource image)
		//{
		//	using (var stream = new MemoryStream())
		//	{
		//		var encoder = new PngBitmapEncoder();
		//		encoder.Frames.Add(BitmapFrame.Create(image));
		//		encoder.Save(stream);
		//		return stream.ToArray();
		//	}
		//}
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
			var dataObject = button.DataContext as ItemControl_Employee;
			id_selected = Convert.ToInt32(dataObject._manv);
		}


		private void btn_item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Button button = sender as Button;
			var dataObject = button.DataContext as ItemControl_Employee;

			id_selected = Convert.ToInt32(dataObject._manv);
			_window_edit.ChinhSuaNhanVien window = new _window_edit.ChinhSuaNhanVien(this);
			window.ShowDialog();
		}
	}

	public class ItemControl_Employee
	{
		public int? _manv { get; set; }
		public string _hoten { get; set; }
		public string _sdt { get; set; }
		public string _photourl { get; set; }
		public string _dchi { get; set; }
		public string _gioitinh { get; set; }
		public ItemControl_Employee()
		{
			_manv = null;
			_hoten = null;
			_sdt = null;
			_photourl = null;
			_dchi = null;
			_gioitinh = null;
		}

		public ItemControl_Employee(int? manv, string hoten, string sdt, string photourl, string dchi, string gioitinh)
		{
			_manv = manv;
			_hoten = hoten;
			_sdt = sdt;
			_photourl = photourl;
			_dchi = dchi;
			_gioitinh = gioitinh;
		}
	}
}
