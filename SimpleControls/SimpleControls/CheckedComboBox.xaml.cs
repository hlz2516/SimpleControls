using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace SimpleControls
{
    /// <summary>
    /// CheckedComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class CheckedComboBox : UserControl
    {
        public List<string> SelectedItems { private set; get; }
        public string Separator { get; set; } = "，";

        public CheckedComboBox()
        {
            InitializeComponent();
            SelectedItems = new List<string>();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var chk = (CheckBox)sender;
            //检查选择列表中是否包含当前选中的词，如果不包含，则追加
            if (chk.Content != null)
            {
                string text = chk.Content.ToString();
                if (!SelectedItems.Contains(text))
                {
                    SelectedItems.Add(text);
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
                if (SelectedItems.Contains(text))
                {
                    SelectedItems.Remove(text);
                }
                UpdateResult();
            }
        }

        private void UpdateResult()
        {
            tb.Content = string.Join(Separator, SelectedItems);
        }

        private void CheckBox_MouseMove(object sender, MouseEventArgs e)
        {
            var chk = (CheckBox)sender;
            var border = chk.Parent as Border;
            border.Background = (LinearGradientBrush)FindResource("ComboBox.MouseOver.Editable.Button.Background");
            border.BorderBrush = (SolidColorBrush)FindResource("ComboBox.MouseOver.Editable.Button.Border");
        }

        private void CheckBox_MouseLeave(object sender, MouseEventArgs e)
        {
            var chk = (CheckBox)sender;
            var border = chk.Parent as Border;
            border.BorderBrush = new SolidColorBrush(Colors.Transparent);
            border.Background = new SolidColorBrush(Colors.Transparent);
        }

        public IEnumerable ItemSource
        {
            get { return (IEnumerable)GetValue(ItemSourceProperty); }
            set
            {
                SetValue(ItemSourceProperty, value);
                items.ItemsSource = value;
            }
        }

        // Using a DependencyProperty as the backing store for ItemSourceProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(IEnumerable), typeof(CheckedComboBox), new PropertyMetadata(new PropertyChangedCallback(ItemSourceChanged)));

        private static void ItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cb = d as CheckedComboBox;
            cb.items.ItemsSource = (IEnumerable)e.NewValue;
        }
    }
}
