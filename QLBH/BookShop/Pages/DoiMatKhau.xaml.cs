using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
	/// Interaction logic for DoiMatKhau.xaml
	/// </summary>
	public partial class DoiMatKhau : Window
	{

		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);
		public DoiMatKhau()
		{
			InitializeComponent();
		}

		private void btn_save_Click(object sender, RoutedEventArgs e)
		{
			;
			if (txt_pw.Password==""||txtb_password.Password==""||txtb_password2.Password=="")
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else if (!Regex.IsMatch(txtb_password.Password, @"^[a-zA-Z0-9]+$"))
			{
				MessageBox.Show("Mật khẩu chỉ được chứa chữ cái và số");
			}
			else if (txtb_password.Password!=txtb_password2.Password)
			{
				MessageBox.Show("Hai mật khẩu vừa nhập không giống nhau!!!");
			}
			else
			{
				string pass = "";
				{
					Con.Open();
					string query = "SELECT PASS FROM NHANVIEN WHERE MANV=@MANV";
					SqlCommand cmd = new SqlCommand(query, Con);
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@MANV", Login.manv);

					pass = cmd.ExecuteScalar().ToString();
					Con.Close();
				}

				if (pass != EncryptAndDecrypt.Encrypt(txt_pw.Password))
				{
					MessageBox.Show("Nhập mật khẩu cũ không đúng");
				}
				else
				{
					try
					{
						Con.Open();
						SqlCommand command = new SqlCommand("UPDATE NHANVIEN SET PASS=@PASS WHERE MANV=@MANV", Con);

						command.Parameters.AddWithValue("@PASS", EncryptAndDecrypt.Encrypt(txtb_password.Password));
						command.Parameters.AddWithValue("@MANV", Login.manv);
						command.ExecuteNonQuery();
						MessageBox.Show("Đổi mật khẩu thành công");

						Con.Close();
					}
					catch (Exception ex)
					{
						Con.Close();
						MessageBox.Show(ex.Message);
					}
				}
				
			}
		}

		private void btn_close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
