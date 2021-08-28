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
    /// Interaction logic for UCValueEntry.xaml
    /// </summary>
    public partial class UCValueEntry : UserControl
    {
        public UCValueEntry()
        {
            InitializeComponent();
        }

        private void tbxMain_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool result = !(IsValid(((TextBox)sender).Text + e.Text));
            e.Handled = result; //if handled is true, then this value won't go any further. It will be stopped here.
        }

        private bool IsValid(string input)
        {
            const char StopChar = '.'; //To check if result has two "."
            int i;
            bool result = true;
            if (input.Count(p => p == StopChar) > 1) return result = false; //False means it's not accepted. When it is returned to caller, it will be True "!", thus handled.
            foreach (char c in input.ToCharArray())
            {
                //if (c == StopChar) { result = true; continue; }//Ignore "." while checking for numbers.
                result = int.TryParse(c.ToString(), out i); //Check if it is an integer
                if (c == StopChar) { result = true; }
            }
            return result; //Check if each character can convert into integer
        }

        public bool IsApproved
        {
            get { return (bool)GetValue(IsApprovedProperty); }
            set { SetValue(IsApprovedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsApproved.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsApprovedProperty =
            DependencyProperty.Register("IsApproved", typeof(bool), typeof(UCValueEntry), new PropertyMetadata(false, IsApprovedPropertyChanged));
        private static void IsApprovedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueEntry ido = d as UCValueEntry;
            if (ido != null)
            {
                ido.IsApproved = (bool)e.NewValue;
            }
        }

        public bool IsSubmitted
        {
            get { return (bool)GetValue(IsSubmittedProperty); }
            set { SetValue(IsSubmittedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for IsSubmitted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSubmittedProperty =
            DependencyProperty.Register("IsSubmitted", typeof(bool), typeof(UCValueEntry), new PropertyMetadata(false, IsSubmittedPropertyChanged));
        private static void IsSubmittedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCValueEntry ido = d as UCValueEntry;
            if (ido != null)
            {
                ido.IsSubmitted = (bool)e.NewValue;
            }
        }

        //public bool IsAdded
        //{
        //    get { return (bool)GetValue(IsAddedProperty); }
        //    set { SetValue(IsAddedProperty, value); }
        //}

        //public static readonly DependencyProperty IsAddedProperty =
        //    DependencyProperty.Register("IsAdded", typeof(bool), typeof(UCValueEntry), new PropertyMetadata(false, IsAddedPropertyChanged));
        //private static void IsAddedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    UCValueEntry ido = d as UCValueEntry;
        //    if(ido !=null)
        //    {
        //        ido.IsAdded = (bool)e.NewValue;
        //    }
        //}
    }
}
