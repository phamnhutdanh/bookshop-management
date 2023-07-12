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
using System.Text.RegularExpressions;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for CustomerPage.xaml
	/// </summary>
	public partial class CustomerPage : Page
	{
		private bool isSort;
		public CustomerPage()
		{
			InitializeComponent();
			
		}

		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);

		private void Clear()
		{
			txt_name_cus.Text = "";
			txt_phone_cus.Text = "";
			date_NgaySinh_cus.Text = "";
			date_NgayDangKy_cus.Text = "";
			txt_address_cus.Text = "";
		}
		private void displayCustomer()
		{
			Con.Open();
			string Query = "SELECT * FROM KHACHHANG";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, Con);
			SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

			DataTable dataTable = new DataTable("KHACHHANG");
			sqlDataAdapter.Fill(dataTable);
			list_KhachHang.ItemsSource = dataTable.DefaultView;
			sqlDataAdapter.Update(dataTable);

			Con.Close();
		}

		private void btn_save_cus_Click(object sender, RoutedEventArgs e)
		{
			if (txt_phone_cus.Text == "" || txt_name_cus.Text == "" || txt_address_cus.Text == "" || date_NgaySinh_cus.Text == "" || date_NgayDangKy_cus.Text == "")
			{
				MessageBox.Show("Hãy nhập đầy đủ thông tin!!!");
			}
			else if (!Regex.IsMatch(txt_phone_cus.Text, @"^[0-9]+$"))
			{
				MessageBox.Show("SDT phải là dãy số");
			}
			else
			{
				try
				{
					Con.Open();

					SqlCommand command = new SqlCommand("INSERT INTO KHACHHANG (HOTEN,SODT,DCHI,NGSINH,NGDK) VALUES (@HOTEN,@SODT,@DCHI,@NGSINH,@NGDK)", Con);

					command.Parameters.AddWithValue("@HOTEN", txt_name_cus.Text);
					command.Parameters.AddWithValue("@SODT", txt_phone_cus.Text);
					command.Parameters.AddWithValue("@DCHI", txt_address_cus.Text);
					command.Parameters.AddWithValue("@NGSINH", date_NgaySinh_cus.Text);
					command.Parameters.AddWithValue("@NGDK", date_NgayDangKy_cus.Text);

					command.ExecuteNonQuery();
					MessageBox.Show("Đã thêm khách hàng thành công");

					Con.Close();
					displayCustomer();
					Clear();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message); Con.Close();
				}
			}
		}

		private void btn_edit_cus_Click(object sender, RoutedEventArgs e)
		{
			if (hidden_textblock_id.Text == "")
			{
				MessageBox.Show("Hãy chọn khách hàng cần chỉnh sửa!!!");
			}
			else if (!Regex.IsMatch(txt_phone_cus.Text, @"^[0-9]+$"))
			{
				MessageBox.Show("SDT phải là dãy số");
			}
			else
			{
				try
				{
					Con.Open();

					SqlCommand command = new SqlCommand("UPDATE KHACHHANG SET HOTEN=@HOTEN,SODT=@SODT,DCHI=@DCHI,NGSINH=@NGSINH,NGDK=@NGDK WHERE MAKH=@MAKH", Con);
					command.Parameters.AddWithValue("@MAKH", hidden_textblock_id.Text);
					command.Parameters.AddWithValue("@HOTEN", txt_name_cus.Text);
					command.Parameters.AddWithValue("@SODT", txt_phone_cus.Text);
					command.Parameters.AddWithValue("@DCHI", txt_address_cus.Text);
					command.Parameters.AddWithValue("@NGSINH", date_NgaySinh_cus.Text);
					command.Parameters.AddWithValue("@NGDK", date_NgayDangKy_cus.Text);

					command.ExecuteNonQuery();
					MessageBox.Show("Đã chỉnh sửa khách hàng thành công");

					Con.Close();
					displayCustomer();
					Clear();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message); Con.Close();
				}
			}

		}

		private void btn_clear_cus_Click(object sender, RoutedEventArgs e)
		{
			Clear();
			displayCustomer();
		}

		private void btn_delete_cus_Click(object sender, RoutedEventArgs e)
		{
			if (hidden_textblock_id.Text == "")
			{
				MessageBox.Show("Hãy chọn khách hàng cần xoá!!!");
			}
			else
			{
				MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xoá khách hàng này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					try
					{
						Con.Open();

						SqlCommand command = new SqlCommand("DELETE FROM KHACHHANG WHERE MAKH=@MAKH", Con);
						command.Parameters.AddWithValue("@MAKH", hidden_textblock_id.Text);

						command.ExecuteNonQuery();
						MessageBox.Show("Đã xoá khách hàng thành công");

						Con.Close();
						displayCustomer();
						Clear();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message); Con.Close();
					}
				}
			}
		}

		#region gridviewcolumnHeader

		private string column = "";
		private void SortColumn()
		{
			try
			{
				if (list_KhachHang.Items.Count > 0)
				{
					CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(list_KhachHang.ItemsSource);

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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		private void GridViewColumnHeader_MAKH_Click(object sender, RoutedEventArgs e)
		{
			column = "MAKH";
			SortColumn();
		}

		private void GridViewColumnHeader_HOTEN_Click(object sender, RoutedEventArgs e)
		{
			column = "HOTEN";
			SortColumn();
		}
		private void GridViewColumnHeader_DCHI_Click(object sender, RoutedEventArgs e)
		{
			column = "DCHI";
			SortColumn();
		}
		private void GridViewColumnHeader_SODT_Click(object sender, RoutedEventArgs e)
		{
			column = "SODT";
			SortColumn();
		}
		private void GridViewColumnHeader_NGSINH_Click(object sender, RoutedEventArgs e)
		{
			column = "NGSINH";
			SortColumn();
		}
		private void GridViewColumnHeader_NGDK_Click(object sender, RoutedEventArgs e)
		{
			column = "NGDK";
			SortColumn();
		}
		private void GridViewColumnHeader_DOANHSO_Click(object sender, RoutedEventArgs e)
		{
			column = "DOANHSO";
			SortColumn();
		}
		#endregion

		private void displayCustomerForSearch()
		{
			try
			{
				Con.Open();
				string Query = "SELECT * FROM KHACHHANG WHERE MAKH LIKE '%'+@param+'%'";
				Query += " or HOTEN LIKE '%'+@param+'%' ";
				Query += " or DCHI LIKE '%'+@param+'%' ";
				Query += " or SODT LIKE '%'+@param+'%' ";
				Query += " or NGSINH LIKE '%'+@param+'%' ";
				Query += " or NGDK LIKE '%'+@param+'%' ";
				Query += " or DOANHSO LIKE '%'+@param+'%' ";
				SqlCommand sqlCommand = new SqlCommand(Query, Con);
				sqlCommand.Parameters.AddWithValue("@param", txbx_textfilter.Text.ToString());

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable("KHACHHANG");
				sqlDataAdapter.Fill(dataTable);
				list_KhachHang.ItemsSource = dataTable.DefaultView;
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
			displayCustomerForSearch();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			displayCustomer();
			isSort = true;
		}
	}
}
