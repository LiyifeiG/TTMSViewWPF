using System.Windows;
using TTMSViewWPF.View.Pages;

namespace TTMSViewWPF
{
    /// <summary>
    /// StartWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            __Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void __Init()
        {
            StartWindowFrame.Content = new LoginPage(this);
        }
    }
}