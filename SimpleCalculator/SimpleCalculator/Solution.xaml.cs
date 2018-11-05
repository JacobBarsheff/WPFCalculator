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
    /// Interaction logic for Solution.xaml
    /// </summary>
    public partial class Solution : Window
    {
        SolutionFormInfo _solutionFormInfo;

        public Solution(SolutionFormInfo solutionFormInfo)
        {
            _solutionFormInfo = solutionFormInfo;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            lbl_Max.Content = _solutionFormInfo.MaxBench.ToString() + _solutionFormInfo.Unit;
        }
    }
}
