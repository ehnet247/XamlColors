using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace XamlColors
{
    /// <summary>
    /// Interaction logic for UserColorControl.xaml
    /// </summary>
    public partial class UserColorControl : UserControl
    {
        public static readonly DependencyProperty ColorNameProperty =
            DependencyProperty.Register(nameof(ColorName), typeof(string), typeof(UserColorControl),
                new PropertyMetadata(ColorNameChangedCallback));
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(nameof(Color), typeof(string), typeof(UserColorControl),
                new PropertyMetadata(ColorChangedCallback));
        public Brush ColorBrush
        {
            get =>(Brush)GetValue(ColorProperty);
            set
            {
                SetValue(ColorProperty, value);
                border.Background = value;
            }
        }
        public string Color
        {
            get => (string)GetValue(ColorProperty);
            set
            {
                string color = value;
                SetValue(ColorProperty, color);
                tbColor.Text = value;
                BrushConverter brushConverter = new BrushConverter();
                if (color != null)
                    try
                    {
                        var brush = (Brush?)brushConverter.ConvertFromString(color);
                        if (brush != null)
                            border.Background = brush;
                    }
                    catch { }
            }
        }
        public string ColorName
        {
            get => (string)GetValue(ColorNameProperty);
            set
            {
                SetValue(ColorNameProperty, value);
                tbName.Text = value;
            }
        }
        public UserColorControl()
        {
            InitializeComponent();
        }

        private void tbColor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbColor.Text))
                Color = tbColor.Text;
        }

        protected virtual void OnColorNameChanged(DependencyPropertyChangedEventArgs e)
        {
            ColorName = (string)e.NewValue;
        }

        protected virtual void OnColorChanged(DependencyPropertyChangedEventArgs e)
        {
            Color = (string)e.NewValue;
        }

        private static void ColorNameChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var userColorControl = sender as UserColorControl;
            if (userColorControl != null)
            {
                userColorControl.OnColorNameChanged(e);
            }
        }

        private static void ColorChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var userColorControl = sender as UserColorControl;
            if (userColorControl != null)
            {
                userColorControl.OnColorChanged(e);
            }
        }
    }
}
