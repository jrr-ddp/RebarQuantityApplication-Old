using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace RebarQuantityApplication
{
    /// <summary>
    /// Interaction logic for UCValueBox.xaml
    /// </summary>
    public partial class UCValueBox : UserControl
    {
        public UCValueBox()
        {
            InitializeComponent();
        }

        private const double InitialWidth = 25;
        private const double InitialHeight = 15;

        public string CustomContent
        {
            get { return (string)GetValue(CustomContentProperty); }
            set { SetValue(CustomContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomContentProperty =
            DependencyProperty.Register(nameof(CustomContent), typeof(string), typeof(UCValueBox), new PropertyMetadata(null, CustomContentPropertyChanged));

        private static void CustomContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueBox ido = d as UCValueBox;
            if (ido != null)
            {
                ido.CustomContent = (string)e.NewValue;
            }
        }

        public bool HiglightActive
        {
            get { return (bool)GetValue(HiglightActiveProperty); }
            set { SetValue(HiglightActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HiglightActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HiglightActiveProperty =
            DependencyProperty.Register(nameof(HiglightActive), typeof(bool), typeof(UCValueBox), new PropertyMetadata(false, HiglightActivePropertyChanged));

        private static void HiglightActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueBox ido = d as UCValueBox;

            if (ido != null)
            {
                ido.HiglightActive = (bool)e.NewValue;
            }
        }

        public SolidColorBrush CustomBackground
        {
            get { return (SolidColorBrush)GetValue(CustomBackgroundProperty); }
            set { SetValue(CustomBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomBackgroundProperty =
            DependencyProperty.Register(nameof(CustomBackground), typeof(SolidColorBrush), typeof(UCValueBox), new PropertyMetadata(null, CustomBackgroundPropertyChanged));

        private static void CustomBackgroundPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueBox ido = d as UCValueBox;

            if (ido != null)
            {
                ido.CustomBackground = (SolidColorBrush)e.NewValue;
            }
        }

        public double ControlWidth
        {
            get { return (double)GetValue(ControlWidthProperty); }
            set { SetValue(ControlWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlWidthProperty =
            DependencyProperty.Register(nameof(ControlWidth), typeof(double), typeof(UCValueBox), new PropertyMetadata(InitialWidth, ControlWidthPropertyChanged));

        private static void ControlWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueBox ido = d as UCValueBox;

            if (ido != null)
            {
                ido.ControlWidth = (double)e.NewValue;
            }
        }

        public double ControlHeight
        {
            get { return (double)GetValue(ControlHeightProperty); }
            set { SetValue(ControlHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlHeightProperty =
            DependencyProperty.Register(nameof(ControlHeight), typeof(double), typeof(UCValueBox), new PropertyMetadata(InitialHeight, ControlHeightPropertyChanged));

        private static void ControlHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueBox ido = d as UCValueBox;

            if (ido != null)
            {
                ido.ControlHeight = (double)e.NewValue;
            }
        }
    }

    public class BoolToVisConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool input = (bool)value;
            switch (input)
            {
                case true:
                    return Visibility.Visible;
                case false:
                default:
                    return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

