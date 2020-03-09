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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListBoxItem kotio = new ListBoxItem();
            kotio.Content = "Котьо";
            peopleListBox.Items.Add(kotio);

            ListBoxItem gerogi = new ListBoxItem();
            kotio.Content = "Героги";
            peopleListBox.Items.Add(gerogi);

            peopleListBox.SelectedItem = kotio;
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (UIElement child in MainGrid.Children)
            {
                if (child is TextBox)
                {
                    builder.Append(((TextBox)child).Text).Append(Environment.NewLine);
                }
            }
            MessageBox.Show(builder.ToString());

            if (txtName.Text.Length <= 2)
            {
                MessageBox.Show("Уй е най-краткото име, поне два символа моля...");
                return;
            }
            MessageBox.Show("Дай ми бележкатаа, " + txtName.Text + "!!!");
        }

        private void TxtNPower_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            long n, y;
            if (long.TryParse(txtNPowerY_N.Text, out n) && long.TryParse(txtNPowerY_Y.Text, out y))
            {
                MessageBox.Show(string.Format("{0}^{1} = {2}", n, y, Math.Pow(n, y)));
                return;
            }
            if (txtNPowerY_N.Text.Length != 0 && txtNPowerY_Y.Text.Length != 0)
            {
                MessageBox.Show("ЕЙ, шопар, въведи правилни данни");
            }
        }

        private void TxtBoxNFactoriel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
            {
                return;
            }

            long fac = long.Parse(txtNFactoriel.Text);
            long result = 1;
            for (int i = 1; i <= fac; i++)
            {
                result *= i;
            }
            MessageBox.Show(fac + " factorial is = " + result);
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MessageBoxResult res = MessageBox.Show("Do you want to leave?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (res == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage myMessage = new MyMessage();
            myMessage.Show();
            //MessageBox.Show("This is Windows Presentation Foundation!");

            //txtBlockTest.Text = DateTime.Now.ToString();
        }

        private void BtnDisplayPerson_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }
    }
}
