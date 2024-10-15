using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWindow()
        {
            InitializeComponent();
            var fruits = new ObservableCollection<string>
            {
                "苹果","橘子","香蕉"
            };
            //cb.ItemSource = fruits;
            //cb2.ItemsSource = fruits;
            var vm = new ViewModel();
            vm.Fruits = fruits;
            this.DataContext = vm;
        }
    }

    public class ViewModel
    {
        public ObservableCollection<string> Fruits { get; set; }
    }
}
