using System.Windows;
using System.Windows.Controls;

namespace TTMSViewWPF.View.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Page
    {
        internal readonly StartWindow MWindow;
        public LoginPage(StartWindow startWindow)
        {
            MWindow = startWindow;
            InitializeComponent();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancer_OnClick(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            MWindow.Close();
        }   
    }
}
