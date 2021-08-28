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
    /// Interaction logic for UCButtonWImage.xaml
    /// </summary>
    public partial class UCButtonWImage : UserControl
    {
        public UCButtonWImage()
        {
            InitializeComponent();
        }

        #region "Properties"

        public static readonly DependencyProperty SourcePrimaryImageProperty = DependencyProperty.Register(nameof(SourcePrimaryImage), typeof(ImageSource), typeof(UCButtonWImage), new PropertyMetadata(null, new PropertyChangedCallback(SourPrimaryImageChanged)));

        public static void SourPrimaryImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImage ido = d as UCButtonWImage;
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

        public static readonly DependencyProperty SourceSecondaryImageProperty = DependencyProperty.Register(nameof(SourceSecondaryImage), typeof(ImageSource), typeof(UCButtonWImage), new PropertyMetadata(null, new PropertyChangedCallback(SourceSecondayrImageChanged)));

        public static void SourceSecondayrImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCButtonWImage ido = d as UCButtonWImage;
            if (ido != null)
            {
                ido.SourceSecondaryImage = e.NewValue as ImageSource;
            }
        }

        public ImageSource SourceSecondaryImage
        {
            get { return GetValue(SourceSecondaryImageProperty) as ImageSource; }
            set { SetValue(SourceSecondaryImageProperty, value); }
        }

        public object UserCommandParameter
        {
            get { return (object)GetValue(UserCommandParameterProperty); }
            set { SetValue(UserCommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserCommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserCommandParameterProperty =
            DependencyProperty.Register("UserCommandParameter", typeof(object), typeof(UCButtonWImage), new PropertyMetadata(0));

        public static readonly DependencyProperty UserCommandProperty = DependencyProperty.Register(nameof(UserCommand), typeof(ICommand), typeof(UCButtonWImage), new PropertyMetadata(null));

        public ICommand UserCommand
        {
            get { return GetValue(UserCommandProperty) as ICommand; } // In C#, 'as' is used for trycast.
            set { SetValue(UserCommandProperty, value); }
        }

        #endregion
        public event RoutedEventHandler Click;

        private void SPCustomButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                Click(this, e);
            }
        }
    }
}
