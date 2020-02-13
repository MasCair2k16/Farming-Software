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

namespace Caird_Farming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> listperson;
        private Person_Table pt = new Person_Table();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Contacts Tab: 
        // submit button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listperson = new List<Person>();

            string name = Name_Input_Copy.Text;
            string address = Address_Input.Text;
            string phone = Phone_Input.Text;
            string role = Role_Combo.Text;

            if (name.Length == 0 || address.Length == 0 || phone.Length == 0 || role.Length == 0)
            {
                MessageBox.Show("Error 401: Person needs a name, email address, phone, and role", "Error", MessageBoxButton.OK, MessageBoxImage.Error);  
            } else
            {
                listperson.Add(new Person(name, address, phone, role));
            }

            DataGridInput();
        }

        // Adding people to the data grid
        private void DataGridInput()
        {

            foreach (Person i in listperson)
            {
                pt.name = i.name;
                pt.address = i.address;
                pt.phone = i.phone;
                pt.role = i.role;

                Person_Table.Items.Add(pt);
            }

            // https://www.codeproject.com/Questions/155935/how-to-add-rows-to-WPF-datagrids
           /* for (int i = 0; i < listperson.Count; i++)
            {
                pt.name = listperson[i].name;
                pt.address = listperson[i].address;
                pt.phone = listperson[i].phone;
                pt.role = listperson[i].role;

                // Add to the table
                Person_Table.Items.Add(pt);
            } */

        }

        // The search box is being used to search through out the contact list
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Person_Table.Items.Clear();

            try
            {
                // https://stackoverflow.com/questions/9923158/c-sharp-contains-part-of-string

                foreach (Person i in listperson)
                {
                 
                    if (Search_Box.Text.ToUpper().Contains(i.name.ToUpper()))
                    {
                        pt.name = i.name;
                        pt.address = i.address;
                        pt.phone = i.phone;
                        pt.role = i.role;

                        Person_Table.Items.Add(pt);
                    } else
                    {
                        Person_Table.Items.Clear();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error 402: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //Search_Box.Text = "";
            }
            
        }
    }
}
