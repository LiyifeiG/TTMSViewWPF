using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TTMSViewWPF.View.Pages;

namespace TTMSViewWPF.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Page> pages;
        public MainWindow()
        {
            InitializeComponent();
            __Init();
        }

        private void __Init()
        {
            //初始化页数组
            pages = new List<Page> {
                new UserManagementPage(this) ,                  //用户管理
                new AuditoriumManagementPage(this) ,            //影厅管理
                new RepertoireManagementPage(this) ,            //剧目管理
                new SalesInfoManagementPage(this) ,             //销售信息 
                new SellsManagementPage(this)};                 //售票
            ManagementPanel.Content = pages[4];
        }

        private void UserInfo_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.github.com/KsGin");
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignOut_OnClick(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Close();
        }

        private void UserName_OnClick(object sender, RoutedEventArgs e)
        {
            if (UserName.ContextMenu != null) UserName.ContextMenu.IsOpen = true;
        }


        //对用户按钮进行操作
        private void UserName_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Brushes.Red;
        }

        private void UserName_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Foreground = Brushes.Black;
        }

        /// <summary>
        /// 用户管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserManagementButton_OnClick(object sender, RoutedEventArgs e)
        {
            ManagementPanel.Content = pages[0];
        }

        /// <summary>
        /// 影厅管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuditorumManagementButton_OnClick(object sender, RoutedEventArgs e)
        {
            ManagementPanel.Content = pages[1];
        }

        /// <summary>
        /// 剧目管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RepertoireManagementButton_OnClick(object sender, RoutedEventArgs e)
        {
            ManagementPanel.Content = pages[2];
        }

        /// <summary>
        /// 销售信息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesInfoManagementButton_OnClick(object sender, RoutedEventArgs e)
        {
            ManagementPanel.Content = pages[3];
        }

        /// <summary>
        /// 销售按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SellsManagementButton_OnClick(object sender, RoutedEventArgs e)
        {
            ManagementPanel.Content = pages[4];
        }
    }
}
