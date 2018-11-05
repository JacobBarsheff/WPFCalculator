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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int MAX_WEIGHT_KG = 545;
        const int MAX_WEIGHT_LBS = 1200;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void txt_weight_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_weight.Text = "";

        }

        private void txt_weight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_weight.Text == "")
            {
                txt_weight.Text = "Enter Weight (Lbs)";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight = 0;
            double value;
            double maxWeight;
            int maxBench;
            int reps = 0;
            string validationFeedback;
            string userMessage = null;
            string unit = "lbs";

            //
            // assign max weight values based on selected button
            //
            if (ctrl_Lbs.IsChecked == true)
            {
                maxWeight = MAX_WEIGHT_LBS;
            }
            else
            {
                maxWeight = MAX_WEIGHT_KG;
                unit = "Kg";
            }

            //
            // validate user input weight and build out the feedback message
            //
            if (!ValidateUserInput(txt_weight.Text, maxWeight, out value, out validationFeedback))
            {
                userMessage += "The Weight" + validationFeedback + Environment.NewLine;
                txt_weight.Text = $"Enter Weight({unit})";
            }
            else
            {
                weight = value;
                reps = (int)ctrl_rangeslider.Value;

            }


            if (userMessage != null)
            {

                MessageBox.Show(userMessage);
            }
            //
            // open the SolutionForm
            //
            else
            {
                maxBench = MaxBench(weight, reps);
                Solution solution = new Solution(new SolutionFormInfo(maxBench, unit));
                solution.ShowDialog();

            }

            }

        private void SfRangeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbl_NumReps != null)
            {
                lbl_NumReps.Content = $"Select Number Of Reps ({ctrl_rangeslider.Value})";
            }
            
            
        }

        private void SplitButtonAdv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DropDownMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

        private void DropDownMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// validate user input in text boxes, return value or user feedback
        /// </summary>
        /// <param name="userInput">text box content</param>
        /// <param name="maxValue">maximum value</param>
        /// <param name="value">returned value</param>
        /// <param name="userFeedback">returned feedback</param>
        /// <returns>validated input status</returns>
        private bool ValidateUserInput(string userInput, double maxValue, out double value, out string userFeedback)
        {
            userFeedback = "";

            if (double.TryParse(userInput, out value))
            {
                if (value > 0 && value <= maxValue)
                {
                    return true;
                }
                else
                {
                    userFeedback = $" must be a number between 0 and {maxValue}.";
                    return false;
                }
            }
            else
            {
                userFeedback = $" must be a number.";
                return false;
            }
        }
        /// <summary>
        /// calculate the number of people who fit
        /// </summary>
        /// <param name="weight">weight</param>
        /// <param name="reps">number of reps</param>
        /// <returns>max bench</returns>
        private int MaxBench(double weight, int reps)
        {

            double[] maxBenchArray = { 1, .95, .93, .90, .87, .85, .83, .80, .77, .75, .73, .70 };

            return (int)(weight / maxBenchArray[reps - 1]);
        }

        private void ctrl_kgs_Checked(object sender, RoutedEventArgs e)
        {
            txt_weight.Text = "Enter Weight(Kgs)";
        }

        private void ctrl_Lbs_Checked(object sender, RoutedEventArgs e)
        {
            txt_weight.Text = "Enter Weight(Lbs)";
        }

        private void DropDownMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ctrl_rangeslider.Value = 1;
            txt_weight.Text = "Enter Weight(Lbs)";
            ctrl_kgs.IsChecked = false;
            ctrl_Lbs.IsChecked = true;
        }
    }
}
