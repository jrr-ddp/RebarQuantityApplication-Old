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
    /// Interaction logic for UCLabel.xaml
    /// </summary>
    public partial class UCLabel : UserControl
    {
        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.Register("ContentText", typeof(string), typeof(UCLabel), new PropertyMetadata(null, ContentTextChanged));

        private static void ContentTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCLabel ido = d as UCLabel;
            ido?.SetValue(ContentTextProperty, (string)e.NewValue);
        }
        public UCLabel()
        {
            InitializeComponent();
        }
    }
}
