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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Constant values that never change

        const double ANNUAL_RATE = .0639; // The annual interest rate
        const double MONTHLY_RATE = ANNUAL_RATE / 12; // The monthly interest rate

        double balance = 0; // How much is still owed
        double payment = 0; // How much this month's payment will be
        double interestPaid = 0; // How much of the payment will go towards interest
        double principle = 0; // How much of the payment will go towards the principle

        public void calculatePayment()
        { // Method to do the math to get interest and principle paid
            interestPaid = balance * MONTHLY_RATE;
            principle = payment - interestPaid;
            balance -= principle;
        }

        public void updateLabels()
        { // Method to update the GUI labels (Text Boxes)
            balanceTextBlockValue.Text = balance.ToString();
            paymentTextBlockValue.Text = payment.ToString();
            interestPaidTextBlockValue.Text = interestPaid.ToString();
            principleTextBlockValue.Text = principle.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();
            // Since these labels never change I'm only updating them on initialization
            annualRateTextBlockValue.Text = (ANNUAL_RATE * 100).ToString() + "%";
            monthlyRateTextBlockValue.Text = (MONTHLY_RATE * 100).ToString() + "%";
        }

        private void updateValuesButton_Click(object sender, RoutedEventArgs e)
        {
            // When this button is clicked it uses the values entered in the respective boxes to update the variables below
            balance = Double.Parse(balanceTextBox.Text);
            payment = Double.Parse(paymentTextBox.Text);
            updateLabels();
        }

        private void makePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            balanceTextBox.Visibility = Visibility.Hidden; // Hide the balance textBox to prevent changing the balance after making the first payment.
            calculatePayment(); // Call the method to get interest paid and principle
            updateLabels(); // Update the labels with the new information
        }
    }
}
