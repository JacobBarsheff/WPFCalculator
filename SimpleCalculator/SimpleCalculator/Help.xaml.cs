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
using System.Windows.Shapes;

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
        }
 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbl_Directions.Content =
                "1) Choose either lbs or kilograms using the radio button." + Environment.NewLine +
                "2) Input a the current weight of the bench." + Environment.NewLine +
                "3) Input the number of reps, max being 12." + Environment.NewLine +
                "4) Click cacluate to get one rep max."
                ;
        }
    }
}
