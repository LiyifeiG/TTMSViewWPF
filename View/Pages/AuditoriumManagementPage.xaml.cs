using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TTMSViewWPF.View.Pages
{

    public class Auditorium
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int RowCount { get; set; }
        public int ColCount { get; set; }
        public Panel SeatPanel { get; set; }
        public Panel MapPanel { get; set; }
        public string MapSite { get; set; }
    }
    /// <summary>
    /// AuditoriumManagementPage.xaml 的交互逻辑
    /// </summary>
    public partial class AuditoriumManagementPage : Page
    {
        public List<Auditorium> AuditoriaesList;
        public List<string> AuditoriaesNameList;
        public AuditoriumManagementPage(MainWindow mainWindow)
        {
            InitializeComponent();
            __Init();
        }

        private void __Init()
        {
            AuditoriaesList = new List<Auditorium>()
            {
                new Auditorium()
                {
                    ID = 1 , 
                    Name = "西邮一号放映厅",
                    Address = "西安市西安邮电大学长安校区东区",
                    RowCount = 8 ,
                    ColCount = 15,
                    SeatPanel = null,
                    MapPanel = null,
                    MapSite = "https://gaode.com/place/B001D09R73" 
                },
                new Auditorium()
                {
                    ID = 2 ,
                    Name = "西邮二号放映厅",
                    Address = "西安市西安邮电大学长安校区西区",
                    RowCount = 6 ,
                    ColCount = 14,
                    SeatPanel = null,
                    MapPanel = null,
                    MapSite = "https://gaode.com/place/B001D04S4N"
                },
                new Auditorium()
                {
                    ID = 3 ,
                    Name = "师范放映厅",
                    Address = "西安市陕西师范大学长安校区",
                    RowCount = 9,
                    ColCount = 16,
                    SeatPanel = null,
                    MapPanel = null,
                    MapSite = "https://gaode.com/place/B0FFF2UNLL"
                },
                new Auditorium()
                {
                    ID = 4 ,
                    Name = "政法放映厅",
                    Address = "西安市西北政法大学长安校区",
                    RowCount = 8 ,
                    ColCount = 15,
                    SeatPanel = null,
                    MapPanel = null,
                    MapSite = "https://gaode.com/place/B001D09T6S"
                },
            };
            AuditoriaesNameList = new List<string>();
            foreach (var n in AuditoriaesList)
            {
                AuditoriaesNameList.Add(n.Name);
                AuditoriumComboBox.Items.Add(new ComboBoxItem()
                {
                    Content = n.Name

                });
                n.MapPanel = new StackPanel();
                var wbrowser = new WebBrowser { Source = new Uri(n.MapSite), Height = 620 };

                n.MapPanel.Children.Add(wbrowser);
            }
            AuditoriumComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 显示座位图
        /// </summary>
        /// <param name="au"></param>
        public void _ShowSeats(Auditorium au)
        {
            if (au.SeatPanel != null)
            {
                SeatsPanel.Children.Add(au.SeatPanel);
                return;
            }
            au.SeatPanel = new StackPanel();
            for (int i = 1; i <= au.RowCount; i++)
            {
                var sp = new StackPanel()
                {
                    Margin = new Thickness(0, 10, 0, 10),
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                for (int j = 1; j < au.ColCount; j++)
                {
                    var b = new Button
                    {
                        Name = "第" + i + "排" + j + "列",
                        Background = Brushes.Green,
                        Width = 15,
                        Height = 15,
                        Margin = new Thickness(10, 0, 10, 0),
                        ToolTip = "第" + i + "排" + j + "列"
                    };
                    b.Click += (sender, args) => 
                    MessageBox.Show(((Button)sender).Name, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    b.MouseRightButtonDown += (sender, args) =>
                    {
                        if (Equals(b.Background, Brushes.Green))
                        {
                            if (MessageBox.Show("报告此座位需要维修?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question)
                                == MessageBoxResult.Yes)
                            {
                                b.Background = Brushes.Black;
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("报告此座位已修好?", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question)
                                == MessageBoxResult.Yes)
                            {
                                b.Background = Brushes.Green;
                            }
                        }
                    };
                    sp.Children.Add(b);
                }
                au.SeatPanel.Children.Add(sp);
            }
            SeatsPanel.Children.Add(au.SeatPanel);
        }

        private void AuditoriumComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var com = (ComboBox) sender;
            SeatsPanel.Children.Clear();
            if (com.SelectedIndex < 0)
            {
                MapPanel.Children.Clear();
                SeatsPanel.Children.Clear();
                SeatPanelTop.Visibility = Visibility.Hidden;
                return;
            }
            SeatPanelTop.Visibility = Visibility.Visible;
            foreach (var au in AuditoriaesList)
            {
                if (au.Name == ((ComboBoxItem)com.SelectedItem).Content.ToString())
                {
                    _ShowSeats(au);
                    _ShowMap(au);
                }
            }
        }

        private void _ShowMap(Auditorium au)
        {
            MapPanel.Children.Clear();
            if (au.MapPanel != null)
            {
                
                MapPanel.Children.Add(au.MapPanel);
                return;
            }
            au.MapPanel = new StackPanel();
            var wbrowser = new WebBrowser {Source = new Uri(au.MapSite) , Height = 620};
            
            au.MapPanel.Children.Add(wbrowser);
            MapPanel.Children.Add(au.MapPanel);
        }

        /// <summary>
        /// 查看具体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuditoriumInformation_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var au in AuditoriaesList)
            {
                if (au.Name == ((ComboBoxItem)AuditoriumComboBox.SelectedItem).Content.ToString())
                {
                    MessageBox.Show("影厅名称 : " + au.Name
                                    + "\n影厅编号 : " + au.ID
                                    + "\n影厅地址 : " + au.Address
                                    + "\n影厅座位数 : " + au.ColCount * au.RowCount, "影厅信息", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }

        /// <summary>
        /// 删除影厅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuditoriumDelCur_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var au in AuditoriaesList)
            {
                if (au.Name == ((ComboBoxItem)AuditoriumComboBox.SelectedItem).Content.ToString())
                {
                    if (MessageBox.Show("确认删除?", "待确认", MessageBoxButton.YesNo, MessageBoxImage.Warning) ==
                        MessageBoxResult.Yes)
                    {
                        AuditoriumComboBox.Items.Remove((ComboBoxItem)AuditoriumComboBox.SelectedItem);
                        AuditoriaesList.Remove(au);
                        AuditoriumComboBox.SelectedIndex = AuditoriumComboBox.Items.Count > 0 ? 0 : -1;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 修改影厅信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuditoriumModCur_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var au in AuditoriaesList)
            {
                if (au.Name == ((ComboBoxItem)AuditoriumComboBox.SelectedItem).Content.ToString())
                {
                    MessageBox.Show("影厅名称 : " + au.Name
                                    + "\n影厅编号 : " + au.ID
                                    + "\n影厅地址 : " + au.Address
                                    + "\n影厅座位数 : " + au.ColCount * au.RowCount, "影厅信息", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
        }
    }
}
