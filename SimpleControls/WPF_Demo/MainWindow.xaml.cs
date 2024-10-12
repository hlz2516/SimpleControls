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

namespace WPF_Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> selectedResult = new List<string>();
        private char Separator = ',';
        public MainWindow()
        {
            InitializeComponent();
            var fruits = new List<string>
            {
                "苹果","橘子","香蕉"
            };
            items.ItemsSource = fruits;
        }

        private void tb_Checked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("tb_Checked");
        }

        private void tb_Unchecked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("tb_Unchecked");
        }

        private void tb_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var chk = (CheckBox)sender;
            //检查选择列表中是否包含当前选中的词，如果不包含，则追加
            if (chk.Content != null)
            {
                string text = chk.Content.ToString();
                if (!selectedResult.Contains(text))
                {
                    selectedResult.Add(text);
                }
                UpdateResult();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var chk = (CheckBox)sender;
            //检查选择列表中是否包含当前选中的词，如果包含，则删除
            if (chk.Content != null)
            {
                string text = chk.Content.ToString();
                if (selectedResult.Contains(text))
                {
                    selectedResult.Remove(text);
                }
                UpdateResult();
            }
        }

        private void UpdateResult()
        {
            tb.Content = string.Join(Separator, selectedResult);
        }
    }
}
