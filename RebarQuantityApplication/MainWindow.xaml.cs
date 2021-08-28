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
using MySql.Data.MySqlClient;

namespace RebarQuantityApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            // Show overlay if we lose focus
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            // Hide overlay if we are focused
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Refresh()
        {
            
        }

        private void FloorDetails_Initialized(object sender, EventArgs e)
        {
            BindFloorComboBox();
        }

        public void BindFloorComboBox()
        {
            string conn = "server=localhost;user id=JDB;password=Robot@123;persistsecurityinfo=True;database=rbqapplication;";
            string query = "Select floors FROM floordetails";
            MySqlConnection condb = new MySqlConnection(conn);
            MySqlCommand comdb = new MySqlCommand(query, condb);
            MySqlDataReader myreader;
            try
            {
                condb.Open();
                myreader = comdb.ExecuteReader();
                while (myreader.Read())
                {
                    string sFloors = myreader.GetString("Floors");
                    FloorDetails.Items.Add(sFloors);
                }
                comdb.ExecuteNonQuery();
                condb.Clone();
            }
            catch (Exception ex)
            {

            }
        }

        private void ProjectName_Initialized(object sender, EventArgs e)
        {
            BindProjectNameComboBox();
        }

        public void BindProjectNameComboBox()
        {
            string conn = "server=localhost;user id=JDB;password=Robot@123;persistsecurityinfo=True;database=rbqapplication;";
            string query = "Select name FROM projects";
            MySqlConnection condb = new MySqlConnection(conn);
            MySqlCommand comdb = new MySqlCommand(query, condb);
            MySqlDataReader myreader;
            try
            {
                condb.Open();
                myreader = comdb.ExecuteReader();
                while (myreader.Read())
                {
                    string sName = myreader.GetString("Name");
                    ProjectName.Items.Add(sName);
                }
                comdb.ExecuteNonQuery();
                condb.Clone();
            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionstring = "server=localhost;user id=JDB;password=Robot@123;persistsecurityinfo=True;database=rbqapplication;";
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into projects(name)values('" + this.txt_PjtName.Text + "');";/*,'" + this.txt_PjtName.Text + "','" + this.txt_new_pwd.Text + "','" + this.txt_cfm_pwd.Text + "');";*/
                    cmd.Parameters.Add(new MySqlParameter("name", txt_PjtName.Text));
                    //cmd.Parameters.Add(new MySqlParameter("oldpassword", txt_PjtName.Text));
                    //cmd.Parameters.Add(new MySqlParameter("newpassword", txt_new_pwd.Text));
                    //cmd.Parameters.Add(new MySqlParameter("confrompassword", txt_cfm_pwd.Text));
                    //cmd.Parameters.Add(new MySqlParameter("confrompassword", txt_cfm_pwd.Text));

                    MySqlDataReader datareader;
                    datareader = cmd.ExecuteReader();
                    MessageBox.Show("Project Added");
                    txt_PjtName.Clear();

                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionstring = "server=localhost;user id=JDB;password=Robot@123;persistsecurityinfo=True;database=rbqapplication;";
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                con.Open();
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"insert into floordetails(floors)values('" + this.txt_flrs.Text + "');";
                    cmd.Parameters.Add(new MySqlParameter("floors", txt_flrs.Text));
                    MySqlDataReader datareader;
                    datareader = cmd.ExecuteReader();
                    MessageBox.Show("Floor Saved");
                    txt_flrs.Clear();

                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //AppInfo AppInfo = new AppInfo();
            //NavigationService.GetNavigationService(this).Navigate(AppInfo);
            
        }
    }
}
