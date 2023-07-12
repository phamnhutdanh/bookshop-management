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
using System.Data;
namespace BookShop
{
	/// <summary>
	/// Interaction logic for PrintPreview.xaml
	/// </summary>
	public partial class PrintPreview : Window
	{
		public static string pr_sohd = "0";
		public static string pr_cusname = "cusname";
		public static string pr_tennv = "tennv";
		public static string pr_sotien = "sotien";
		public static DataTable pr_billTB = new DataTable();

		public PrintPreview()
		{
			InitializeComponent();
		}

		private void AddInfo()
		{
			DateTime dateTime = DateTime.Now;
			txt_date.Text = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
			txt_cusname.Text = pr_cusname;
			txt_sohd.Text = pr_sohd;
			txt_tennv.Text = pr_tennv;
			txt_sotien.Text = pr_sotien;
		}

		public static void initTable()
		{
			DataColumnCollection columns = pr_billTB.Columns;
			if (!columns.Contains("name"))
			{
				DataColumn name = new DataColumn("name", typeof(string));
				pr_billTB.Columns.Add(name);
			}
			
			if (!columns.Contains("price"))
			{
				DataColumn price = new DataColumn("price", typeof(int));
				pr_billTB.Columns.Add(price);
			}
			
			if (!columns.Contains("qty"))
			{
				DataColumn qty = new DataColumn("qty", typeof(int));
				pr_billTB.Columns.Add(qty);
			}

			if (!columns.Contains("sum"))
			{
				DataColumn sum = new DataColumn("sum", typeof(int));
				pr_billTB.Columns.Add(sum);

			}
			if (!columns.Contains("loai"))
			{
				DataColumn loai = new DataColumn("loai", typeof(string));
				pr_billTB.Columns.Add(loai);

			}

		}
		private void displayBill()
		{
			listview_hoadon.ItemsSource = pr_billTB.DefaultView;
		}

		private void btn_exit_Click(object sender, RoutedEventArgs e)
		{
			pr_billTB.Clear();
			this.Close();
		}

		private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

		private void print_btn_Click(object sender, RoutedEventArgs e)
		{
			Window1 window = new Window1();
			window.Show();

			this.Close();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			AddInfo();
			displayBill();
		}
	}
}
