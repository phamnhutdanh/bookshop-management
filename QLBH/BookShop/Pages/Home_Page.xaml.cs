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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using System.Globalization;

namespace BookShop.Pages
{
	/// <summary>
	/// Interaction logic for Home_Page.xaml
	/// </summary>
	public partial class Home_Page : Page
	{

		public SeriesCollection SeriesCollection { get; set; }
		public SeriesCollection SeriesCollection2 { get; set; }
		SqlConnection Con = new SqlConnection(Properties.Settings.Default.cn);

		public Home_Page()
		{
			InitializeComponent();
		}

		private void LoadCartesianChart()
		{
			CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

			cartesian_Chart.AxisX.Add(new LiveCharts.Wpf.Axis
			{
				Title = "Month",
				Labels = new[] {"Jan","Feb","Mar", "Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"}
			});
			cartesian_Chart.AxisY.Add(new LiveCharts.Wpf.Axis
			{
				Title = "Doanh thu",
				LabelFormatter = value => value.ToString("#,### VND", cul)
			});
			cartesian_Chart.LegendLocation = LiveCharts.LegendLocation.Left;

			SeriesCollection2 = new SeriesCollection();

			try
			{
				string query = "SELECT MONTH(NGHD) AS THANG, YEAR(NGHD) as NAM, SUM(TRIGIA) AS DOANHTHU FROM HOADON ";
				query += " GROUP BY MONTH(NGHD), YEAR(NGHD) ";

				Con.Open();
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();
				List<Revenue> list = new List<Revenue>();
				while (dataReader.Read())
				{
					Revenue revenue = new Revenue();
					revenue.Month = dataReader.GetInt32(0);
					revenue.Year = dataReader.GetInt32(1);
					revenue.Value = dataReader.GetInt32(2);
					list.Add(revenue);
				}
				Con.Close();

				var years = (from y in list
							 select new { Year = y.Year }).Distinct();

				foreach (var year in years)
				{
					List<int> values = new List<int>();
					for (int month = 1; month <= 12; month++)
					{
						int value = 0;
						var data = from y in list
								   where y.Year.Equals(year.Year) && y.Month.Equals(month)
								   orderby y.Month ascending
								   select new { y.Value, y.Month };

						if (data.SingleOrDefault()!=null)
						{
							value = data.SingleOrDefault().Value;
						}
						values.Add(value);
					
					}
					SeriesCollection2.Add(new LineSeries()
					{
						Title = year.Year.ToString(),
						Values=new ChartValues<int>(values)
					});
				}
				DataContext = this;
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}
		}

		private void LoadPieChart()
		{
			SeriesCollection = new SeriesCollection();
			try
			{

				string query = "select SANPHAM.MALOAI,LOAI,COUNT(*) AS SOLUONG from SANPHAM,LOAISANPHAM ";
				query += " where SANPHAM.MALOAI=LOAISANPHAM.MALOAI ";
				query += " GROUP BY SANPHAM.MALOAI,LOAI";
				Con.Open();
				SqlCommand command = new SqlCommand(query, Con);
				SqlDataReader dataReader = command.ExecuteReader();

				while(dataReader.Read())
				{
					int value = dataReader.GetInt32(2);
					PieSeries p = new PieSeries();
					p.Title = dataReader.GetString(1);
					p.DataLabels = true; 
					p.Values = new ChartValues<ObservableValue> { new ObservableValue(value)};
					SeriesCollection.Add(p);
					DataContext = this;
				}

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}
		}

		private void displayCount_NHANVIEN()
		{
			try
			{

				string query = "SELECT COUNT(*) FROM NHANVIEN";
				Con.Open();

				SqlCommand command = new SqlCommand(query, Con);
				command.CommandType = CommandType.Text;

				int count = Convert.ToInt32(command.ExecuteScalar());
				count--;
				if (count <= 0)
					txt_soluongnhanvien.Text = "0";
				else
					txt_soluongnhanvien.Text = count.ToString();

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}
		}

		private void displayCount_KHACHHANG()
		{
			try
			{
				string query = "SELECT COUNT(*) FROM KHACHHANG";
				Con.Open();

				SqlCommand command = new SqlCommand(query, Con);
				command.CommandType = CommandType.Text;

				int count = Convert.ToInt32(command.ExecuteScalar());
				txt_soluongkhach.Text = count.ToString();

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}
		}

		private void displayCount_DOANHTHU()
		{
			CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
			try
			{
				string query = "SELECT SUM(DOANHSO) FROM KHACHHANG";
				Con.Open();

				SqlCommand command = new SqlCommand(query, Con);
				command.CommandType = CommandType.Text;

				int count = Convert.ToInt32(command.ExecuteScalar());
				txt_doanhthu.Text = count.ToString("#,### VND", cul);

				Con.Close();
			}
			catch (Exception ex)
			{
				Con.Close();
				MessageBox.Show(ex.Message);

			}
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			LoadPieChart();
			LoadCartesianChart();
			displayCount_NHANVIEN();
			displayCount_KHACHHANG();
			displayCount_DOANHTHU();
		}
	}
}
