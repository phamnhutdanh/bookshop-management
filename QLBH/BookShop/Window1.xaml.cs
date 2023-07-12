using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace BookShop
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private DataTable listBill;
		private DataTable groupInfo;
		Report.Report.CrystalReport1 report;
		public Window1()
		{
			InitializeComponent();
		}


		private void initTable_listBill()
		{
			DataColumnCollection columns = listBill.Columns;
			if (!columns.Contains("ten"))
			{
				DataColumn name = new DataColumn("ten", typeof(string));
				listBill.Columns.Add(name);
			}

			if (!columns.Contains("gia"))
			{
				DataColumn price = new DataColumn("gia", typeof(string));
				listBill.Columns.Add(price);
			}

			if (!columns.Contains("soluong"))
			{
				DataColumn qty = new DataColumn("soluong", typeof(int));
				listBill.Columns.Add(qty);
			}

			if (!columns.Contains("tong"))
			{
				DataColumn sum = new DataColumn("tong", typeof(string));
				listBill.Columns.Add(sum);

			}
			if (!columns.Contains("loai"))
			{
				DataColumn loai = new DataColumn("loai", typeof(string));
				listBill.Columns.Add(loai);

			}

		}
		private void LoadListBill()
		{
			initTable_listBill();
			CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

			foreach (DataRow item in PrintPreview.pr_billTB.Rows)
			{
				DataRow row = listBill.NewRow();
				row["ten"] = item["name"].ToString();
				row["loai"] = item["loai"].ToString();
				row["gia"] = Convert.ToInt32(item["price"]).ToString("#,### VND", cul);
				row["soluong"] = item["qty"].ToString();
				row["tong"] = Convert.ToInt32(item["sum"]).ToString("#,### VND", cul);
				listBill.Rows.Add(row);

				
			}
			report.Database.Tables["ListBill"].SetDataSource(listBill);

			viewer.ViewerCore.ReportSource = report;
			listBill.Clear();
		}


		private void initTable_groupInfo()
		{
			DataColumnCollection columns = groupInfo.Columns;

			if (!columns.Contains("tennv"))
			{
				DataColumn column= new DataColumn("tennv", typeof(string));
				groupInfo.Columns.Add(column);
			}
			if (!columns.Contains("tenkh"))
			{
				DataColumn column = new DataColumn("tenkh", typeof(string));
				groupInfo.Columns.Add(column);
			}
			if (!columns.Contains("sohd"))
			{
				DataColumn column = new DataColumn("sohd", typeof(string));
				groupInfo.Columns.Add(column);
			}
			if (!columns.Contains("tongtien"))
			{
				DataColumn column = new DataColumn("tongtien", typeof(string));
				groupInfo.Columns.Add(column);
			}
			if (!columns.Contains("ngay"))
			{
				DataColumn column = new DataColumn("ngay", typeof(string));
				groupInfo.Columns.Add(column);
			}
		}

		private void LoadGroupInfo()
		{
			initTable_groupInfo();

			DataRow row = groupInfo.NewRow();
			row["tennv"] = PrintPreview.pr_tennv;
			row["tenkh"] = PrintPreview.pr_cusname;
			row["sohd"] = PrintPreview.pr_sohd;
			row["tongtien"] = PrintPreview.pr_sotien;
			DateTime dateTime = DateTime.Now;
			row["ngay"] = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
			groupInfo.Rows.Add(row);
			
			report.Database.Tables["GroupInfo"].SetDataSource(groupInfo);

			viewer.ViewerCore.ReportSource = report;
			groupInfo.Clear();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			listBill = new DataTable();
			groupInfo = new DataTable();
			report = new Report.Report.CrystalReport1();
			LoadListBill();
			LoadGroupInfo();
		}
	}
}
