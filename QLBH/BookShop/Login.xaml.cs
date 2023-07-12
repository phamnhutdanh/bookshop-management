using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Data;
using MaterialDesignThemes.Wpf;

namespace BookShop
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		public static string UserName = "";
		public static bool isAdmin = false;
		public static int manv;

		private string adminUserName ;
		private string adminPassword ;
		public Login()
		{
			InitializeComponent();
			
		}

		private void DangNhap()
		{
			if (txt_username.Text == "" || txtb_password.Password == "")
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin");
			}
			else if (txt_username.Text == adminUserName && txtb_password.Password == adminPassword)
			{
				isAdmin = true;
				manv = 0;
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				this.Close();
			}
			else
			{
				try
				{
					Con.Open();

					SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM NHANVIEN WHERE USERNAME=@USER AND PASS=@PASS", Con);

					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("@USER", txt_username.Text);
					command.Parameters.AddWithValue("@PASS", EncryptAndDecrypt.Encrypt(txtb_password.Password));

					int count = Convert.ToInt32(command.ExecuteScalar());
					Con.Close();

					if (count == 1)
					{
						isAdmin = false;
						UserName = txt_username.Text;

						{
							Con.Open();
							String query = "SELECT MANV FROM NHANVIEN WHERE USERNAME=@USERNAME";
							SqlCommand cmd = new SqlCommand(query, Con);
							cmd.CommandType = CommandType.Text;
							cmd.Parameters.AddWithValue("@USERNAME", UserName);

							manv = Convert.ToInt32(cmd.ExecuteScalar().ToString());
							Con.Close();
						}

						MainWindow mainWindow = new MainWindow();
						mainWindow.Show();
						this.Close();
					}
					else
					{
						MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
					}
				}
				catch (Exception ex)
				{
					Con.Close();
					MessageBox.Show(ex.Message); 
				}
			}
		}

		private void btn_dangnhap_Click(object sender, RoutedEventArgs e)
		{
			DangNhap();
		}

		private void exit_app(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			DragMove();
		}

		private void minimize_app(object sender, RoutedEventArgs e)
		{
			this.WindowState = WindowState.Minimized;
		}

		private void getAdminPass()
		{
			try
			{
				Con.Open();
				string query = "select USERNAME,PASS from NHANVIEN where MANV=0";
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();

				while(dataReader.Read())
				{
					adminUserName = dataReader.GetString(0);
					adminPassword = EncryptAndDecrypt.Decrypt(dataReader.GetString(1));
				}

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			getAdminPass();
		}
	}
}
