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

namespace TTMSViewWPF.View.Pages
{
    /// <summary>
    /// SellsManagementPage.xaml 的交互逻辑
    /// </summary>
    public partial class SellsManagementPage : Page
    {
        public List<string> SellSeatsLocationList;
        public List<Button> SellSeatList;
        public SellsManagementPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _CreateButtons(8 , 15);
            SellSeatsLocationList = new List<string>();
            SellSeatList = new List<Button>();
        }


        public void _CreateButtons(int _row, int _col)
        {
            for (int i = 1; i <= _row ; i++)
            {
                StackPanel sp = new StackPanel()
                {
                    Margin = new Thickness(10 , 10 , 10 , 10),
                    Orientation = Orientation.Horizontal
                };
                for (int j = 1; j < _col; j++)
                {
                    var b = new Button
                    {
                        Name = "第" + i + "排" + j + "列",
                        Background = Brushes.Green,
                        Width = 15,
                        Height = 15,
                        Margin = new Thickness(15 , 10 , 15 ,10),
                        ToolTip = "第" + i + "排" + j + "列"
                    };
                    b.Click += BOnClick;
                    b.MouseRightButtonDown += BOnMouseRightButtonDown;
                    sp.Children.Add(b);
                }
                SeatPanel.Children.Add(sp);
            }
        }

        /// <summary>
        /// 单买票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseButtonEventArgs"></param>
        private void BOnMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var b = (Button)sender;
            if (Equals(b.Background, Brushes.Red))
            {
                if (MessageBox.Show("是否退票?", "退票", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    b.Background = Brushes.Green;
                }
                return;
            }
            if (Equals(b.Background , Brushes.Green))
            {
                if (MessageBox.Show("是否购买?￥34", "购票", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    b.Background = Brushes.Red;
                }
                return;
            }
        }

        private void BOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var b = (Button) sender;
            if (Equals(b.Background, Brushes.Black) || Equals(b.Background, Brushes.Red))
            {
                MessageBox.Show("此座位已损坏或者被预定，无法选定!" , "错误" , MessageBoxButton.OK , MessageBoxImage.Error);
                return;
            }
            if (Equals(b.Background , Brushes.Cyan))
            {
                b.Background = Brushes.Green;
                SellSeatsLocationList.Remove(b.Name);
                SelledSeatList.Items.Remove(b.Name);
                SellSeatList.Remove(b);
                if (SelledSeatList.Items.Count > 1)
                {
                    SelledSeatList.ScrollIntoView(SelledSeatList.Items[SelledSeatList.Items.Count - 1]);
                }
                return;
            }
            if(Equals(b.Background , Brushes.Green))
            {
                b.Background = Brushes.Cyan;
                SellSeatsLocationList.Add(b.Name);
                SelledSeatList.Items.Add(b.Name);
                SellSeatList.Add(b);
                if (SelledSeatList.Items.Count > 1)
                {
                    SelledSeatList.ScrollIntoView(SelledSeatList.Items[SelledSeatList.Items.Count - 1]);
                }
                return;
            }
        }

        private void SellButton_OnClick(object sender, RoutedEventArgs e)
        {
            var pay = (SellSeatsLocationList.Count * 34).ToString();
            if (MessageBox.Show("单价￥34,总价￥" + pay + "\n确认购买?", "提示", MessageBoxButton.YesNo , MessageBoxImage.Question)
                        == MessageBoxResult.Yes)
            {
                foreach (var b in SellSeatList)
                {
                    b.Background = Brushes.Red;
                }
                SellSeatsLocationList.Clear();
                SellSeatList.Clear();
                SelledSeatList.Items.Clear();
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var b in SellSeatList)
            {
                b.Background = Brushes.Green;
            }
            SellSeatList.Clear();
            SelledSeatList.Items.Clear();
            SellSeatsLocationList.Clear();
        }

    }
}
