using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace TTMSViewWPF.View.Pages
{
    internal class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public DateTime PreSignInTime { get; set; }
    }

    /// <summary>
    ///     UserManagementPage.xaml 的交互逻辑
    /// </summary>
    public partial class UserManagementPage : Page
    {
        private List<User> _users;

        public UserManagementPage(MainWindow mainWindow)
        {
            InitializeComponent();
            __Init();
        }

        private void __Init()
        {
            _users = new List<User>();
            _users.AddRange(new[]
            {
                new User
                {
                    ID = 001,
                    Name = "杨帆",
                    Account = "yangfan",
                    Password = "ubuntu",
                    Level = "系统管理员",
                    PreSignInTime = DateTime.Today
                },
                new User
                {
                    ID = 002,
                    Name = "李一斐",
                    Account = "liyifei",
                    Password = "ubuntu",
                    Level = "售票经理",
                    PreSignInTime = DateTime.Today
                },
                new User
                {
                    ID = 003,
                    Name = "余帆",
                    Account = "yufan",
                    Password = "ubuntu",
                    Level = "售票经理",
                    PreSignInTime = DateTime.Today
                },
                new User
                {
                    ID = 004,
                    Name = "扈衍",
                    Account = "huyan",
                    Password = "ubuntu",
                    Level = "售票员",
                    PreSignInTime = DateTime.Today
                },
                new User
                {
                    ID = 005,
                    Name = "南继东",
                    Account = "nanjidong",
                    Password = "ubuntu",
                    Level = "售票员",
                    PreSignInTime = DateTime.Today
                }
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "ID",
                Binding = new Binding("ID")
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "姓名",
                Binding = new Binding("Name")
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "账号",
                Binding = new Binding("Account")
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "密码",
                Binding = new Binding("Password")
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "用户等级",
                Binding = new Binding("Level")
            });
            UserDataGrid.Columns.Add(new DataGridTextColumn
            {
                Header = "上次登录时间",
                Binding = new Binding("PreSignInTime")
            });

            foreach (var v in _users)
                UserDataGrid.Items.Add(new DataGridRow
                {
                    Item = v
                });
        }

        /// <summary>
        ///     增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_OnClick(object sender, RoutedEventArgs e)
        {
            ModButton.Content = "修改";
            NameTextBox.IsReadOnly = true;
            PasswordTextBox.IsReadOnly = true;
            LevelComboBox.IsEnabled = false;
            AddPanel.Visibility = Visibility.Visible;
            IDAddTextBox.Text = (_users[_users.Count - 1].ID + 1).ToString();
        }

        /// <summary>
        ///     修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (ModButton.Content.ToString() == "修改")
            {
                if (IDTextBox.Text == "") return;
                NameTextBox.IsReadOnly = false;
                PasswordTextBox.IsReadOnly = false;
                LevelComboBox.IsEnabled = true;
                NameTextBox.Focus();
                ModButton.Content = "完成";
            }
            else
            {
                if (IDTextBox.Text == "") { ModButton.Content = "修改"; return;}
                NameTextBox.IsReadOnly = true;
                PasswordTextBox.IsReadOnly = true;
                LevelComboBox.IsEnabled = false;
                _users[int.Parse(IDTextBox.Text) - 1].Name = NameTextBox.Text;
                _users[int.Parse(IDTextBox.Text) - 1].Password = PasswordTextBox.Text;
                _users[int.Parse(IDTextBox.Text) - 1].Level = LevelComboBox.Text;
                UpdateGrid(_users[int.Parse(IDTextBox.Text) - 1]);
                ModButton.Content = "修改";
            }
            
        }

        /// <summary>
        /// 更新表格
        /// </summary>
        /// <param name="user"></param>
        private void UpdateGrid(User user)
        {
            UserDataGrid.Items.Clear();
            foreach (var v in _users)
                UserDataGrid.Items.Add(new DataGridRow
                {
                    Item = v
                });
        }

        /// <summary>
        ///     删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelItem_OnClick(object sender, RoutedEventArgs e)
        {
            ModButton.Content = "修改";
            NameTextBox.IsReadOnly = true;
            PasswordTextBox.IsReadOnly = true;
            LevelComboBox.IsEnabled = false;
            if (IDTextBox.Text == "")
            {
                return;
            }
            if (IDTextBox.Text == "1")
            {
                MessageBox.Show("无法删除最高级系统管理员!", "错误");
                return;
            }
            if (MessageBox.Show("确定要删除吗?", "警告", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
            var i = 0;
            for (i = 0; i < _users.Count; i++)
            {
                if (_users[i].ID == int.Parse(IDTextBox.Text))
                {
                    break;
                }
            }
            _users.Remove(_users[i]);
            UserDataGrid.Items.Clear();
            foreach (var v in _users)
                UserDataGrid.Items.Add(new DataGridRow
                {
                    Item = v
                });
            IDTextBox.Text = "";
            NameTextBox.Text = "";
            PasswordTextBox.Text = "";
            LevelComboBox.SelectedIndex = -1;
        }

        /// <summary>
        ///     刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FluItem_OnClick(object sender, RoutedEventArgs e)
        {
            ModButton.Content = "修改";
            NameTextBox.IsReadOnly = true;
            PasswordTextBox.IsReadOnly = true;
            LevelComboBox.IsEnabled = false;
            UserDataGrid.Items.Clear();
            foreach (var v in _users)
                UserDataGrid.Items.Add(new DataGridRow
                {
                    Item = v
                });
        }

        /// <summary>
        ///     双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (UserDataGrid.SelectedIndex == -1) return;
            var row = (DataGridRow) UserDataGrid.ItemContainerGenerator.ContainerFromIndex(UserDataGrid.SelectedIndex);
            var us = (User)row.Item;
            IDTextBox.Text = us.ID.ToString();
            NameTextBox.Text = us.Name;
            PasswordTextBox.Text = us.Password;
            if (us.Level == "系统管理员")
            {
                LevelComboBox.SelectedIndex = 0;
            }
            else
            {
                LevelComboBox.SelectedIndex = us.Level == "售票经理" ? 1 : 2;
            }
        }

        private void AddConButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IDAddTextBox.Text == "" || NameAddTextBox.Text == "" 
                || AccountAddTextBox.Text == "" || PasswordAddTextBox.Text == ""
                || LevelAddComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("所有信息不能为空!", "错误");
                return;
            }
            _users.Add(new User()
            {
                ID = int.Parse(IDAddTextBox.Text) , 
                Name = NameAddTextBox.Text , 
                Account = AccountAddTextBox.Text,
                Password = PasswordAddTextBox.Text,
                Level = LevelAddComboBox.Text,
                PreSignInTime = DateTime.Today
            });
            IDAddTextBox.Text = "";
            NameAddTextBox.Text = "";
            AccountAddTextBox.Text = "";
            PasswordAddTextBox.Text = "";
            LevelAddComboBox.SelectedIndex = -1;
            AddPanel.Visibility = Visibility.Hidden;
            UserDataGrid.Items.Clear();
            foreach (var v in _users)
                UserDataGrid.Items.Add(new DataGridRow
                {
                    Item = v
                });
        }

        private void AddCanButton_OnClick(object sender, RoutedEventArgs e)
        {
            IDAddTextBox.Text = "";
            NameAddTextBox.Text = "";
            AccountAddTextBox.Text = "";
            PasswordAddTextBox.Text = "";
            LevelAddComboBox.SelectedIndex = -1;
            AddPanel.Visibility = Visibility.Hidden;
        }
    }
}
