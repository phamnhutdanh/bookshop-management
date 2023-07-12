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
using System.Media;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace BookShop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		public MainWindow()
		{
			InitializeComponent();
		}

		private void LoadUser()
		{
			if (Login.isAdmin)
			{
				nhanvien_QuyenTruyCap.Visibility = Visibility.Hidden;
				admin_QuyenTruyCap.Visibility = Visibility.Visible;
			}
			else
			{
				nhanvien_QuyenTruyCap.Visibility = Visibility.Visible;
				admin_QuyenTruyCap.Visibility = Visibility.Hidden;
				txt_nvQUanLy.Text = Login.UserName;
			}
		}

		#region button event 
		private void btn_exit_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Bạn có muốn thoát?", "Thông báo", System.Windows.Forms.MessageBoxButtons.YesNo);
			if (dr == System.Windows.Forms.DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void btn_employee_Click(object sender, RoutedEventArgs e)
		{
			if (Login.isAdmin)
				Main.Content = new Pages.EmployeePage();
			else System.Windows.MessageBox.Show("Người dùng không có quyền truy cập");
		}

		private void btn_home_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.Home_Page();
		}

		private void btn_customer_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.CustomerPage();
		}

		private void btn_product_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.ProductPage();
		}

		private void btn_bill_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.BillPage();
		}
		private void btn_addbill_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.AddToBillPage();
		}
		#endregion

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			this.DragMove();
		}

		private void btn_signout_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Close();
		}

		private void minimize_app(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Main.Content = new Pages.Home_Page();
			LoadUser();
			displayInfo();

			if (Login.isAdmin)
			{
				popup_box.Visibility = Visibility.Hidden;
			}
		}

		private void btn_suathongtin_Click(object sender, RoutedEventArgs e)
		{
			Pages.SuaThongTin window = new Pages.SuaThongTin(this);
			window.ShowDialog();
		}


		public void displayInfo()
		{
			if (!Login.isAdmin)
			{
				string path = "";
				try
				{
					{
						Con.Open();
						string query = "SELECT PHOTOURL FROM NHANVIEN WHERE MANV=@param";
						SqlCommand cmd = new SqlCommand(query, Con);
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@param", Login.manv);

						path = cmd.ExecuteScalar().ToString();
						Con.Close();
					}

					{
						Con.Open();
						string query = "SELECT USERNAME FROM NHANVIEN WHERE MANV=@param";
						SqlCommand cmd = new SqlCommand(query, Con);
						cmd.CommandType = CommandType.Text;
						cmd.Parameters.AddWithValue("@param", Login.manv);

						txt_nvQUanLy.Text = cmd.ExecuteScalar().ToString();
						Con.Close();
					}


					if (path != null)
						img_avatar.ImageSource = LoadImage(path);
				}
				catch (Exception ex)
				{
					Con.Close();
					MessageBox.Show(ex.Message);
				}
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

		private void btn_doimatkhau_Click(object sender, RoutedEventArgs e)
		{
			Pages.DoiMatKhau window = new Pages.DoiMatKhau();
			window.ShowDialog();
		}

	}
}
