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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RebarQuantityApplication
{
    /// <summary>
    /// Interaction logic for UCButtonWImageNText.xaml
    /// </summary>
    public partial class UCButtonWImageNText : UserControl
    {
        public UCButtonWImageNText()
        {
            InitializeComponent();
        }

        #region "General Properties"

        #endregion

        #region "Dependency Properties"

        public static readonly DependencyProperty SourcePrimaryImageProperty = DependencyProperty.Register(nameof(SourcePrimaryImage), typeof(ImageSource), typeof(UCButtonWImageNText), new PropertyMetadata(null, new PropertyChangedCallback(SourPrimaryImageChanged)));

        public static void SourPrimaryImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            if (ido != null)
            {
                ido.SourcePrimaryImage = e.NewValue as ImageSource;
            }
        }

        public ImageSource SourcePrimaryImage
        {
            get { return GetValue(SourcePrimaryImageProperty) as ImageSource; }
            set { SetValue(SourcePrimaryImageProperty, value); }
        }

        public object UserCommandParameter
        {
            get { return (object)GetValue(UserCommandParameterProperty); }
            set { SetValue(UserCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserCommandParameterProperty =
            DependencyProperty.Register("UserCommandParameter", typeof(object), typeof(UCButtonWImageNText), new PropertyMetadata(0));

        public static readonly DependencyProperty UserCommandProperty = DependencyProperty.Register(nameof(UserCommand), typeof(ICommand), typeof(UCButtonWImageNText), new PropertyMetadata(null));

        public ICommand UserCommand
        {
            get { return GetValue(UserCommandProperty) as ICommand; } // In C#, 'as' is used for trycast.
            set { SetValue(UserCommandProperty, value); }
        }

        public SolidColorBrush BackGroundSolidColor
        {
            get { return (SolidColorBrush)GetValue(BackGroundSolidColorProperty); }
            set { SetValue(BackGroundSolidColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackGroundSolidColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackGroundSolidColorProperty =
            DependencyProperty.Register("BackGroundSolidColor", typeof(SolidColorBrush), typeof(UCButtonWImageNText), new PropertyMetadata(null, BackGroundSolidColorChanged));

        private static void BackGroundSolidColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            if (ido != null)
            {
                ido.BackGroundSolidColor = (SolidColorBrush)e.NewValue;
            }
        }

        public string TextContent
        {
            get { return (string)GetValue(TextContentProperty); }
            set { SetValue(TextContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register("TextContent", typeof(string), typeof(UCButtonWImageNText), new PropertyMetadata("SPB", TextContentChanged));

        private static void TextContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            if (ido != null)
            {
                ido.TextContent = (string)e.NewValue;
            }
        }

        public bool ImageVisible
        {
            get { return (bool)GetValue(ImageVisibleProperty); }
            set { SetValue(ImageVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageVisibleProperty =
            DependencyProperty.Register("ImageVisible", typeof(bool), typeof(UCButtonWImageNText), new PropertyMetadata(true, ImageVisibleChanged));

        private static void ImageVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            ido?.SetValue(ImageVisibleProperty, (bool)e.NewValue);
        }


        public HorizontalAlignment HAlignment
        {
            get { return (HorizontalAlignment)GetValue(HAlignmentProperty); }
            set { SetValue(HAlignmentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HAlignmentProperty =
            DependencyProperty.Register("HAlignment", typeof(HorizontalAlignment), typeof(UCButtonWImageNText), new PropertyMetadata(HorizontalAlignment.Left, HAlignmentChanged));
        private static void HAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            ido?.SetValue(HAlignmentProperty, (HorizontalAlignment)e.NewValue);
        }



        public SolidColorBrush ContentColor
        {
            get { return (SolidColorBrush)GetValue(ContentColorProperty); }
            set { SetValue(ContentColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ContentColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentColorProperty =
            DependencyProperty.Register("ContentColor", typeof(SolidColorBrush), typeof(UCButtonWImageNText), new PropertyMetadata(null, ContentColorChanged));
        private static void ContentColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImageNText ido = d as UCButtonWImageNText;
            ido?.SetValue(ContentColorProperty, (SolidColorBrush)e.NewValue);
        }

        #endregion

        public event RoutedEventHandler Click;

        private void SPCustomButton_Click(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
