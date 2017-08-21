using System.Windows;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows.Controls;


namespace StrategyPattern
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, AbstractStructureStrategy> instances = new Dictionary<string, AbstractStructureStrategy>() {
            {"arrayRd", new ArrayStrategy() },
            {"stackRd", new StackStrategy() },
            {"queueRd", new QueueStrategy() },
            {"hashRd", new DictionaryStrategy()}
        };
        AbstractStructureStrategy strategy;

        public MainWindow()
        {
            InitializeComponent();
            strategy = instances["arrayRd"];
            changeButtonStatus(true);
        }
    /// <summary>
    /// Active or disactive the buttons
    /// </summary>
    /// <param name="isEmpty">flag indicating whether the structure is empty or not</param>
    private void changeButtonStatus(bool isEmpty)
        {
            if (isEmpty)
            {
                this.searchByNameBtn.IsEnabled = false;
                this.searchByEmailBtn.IsEnabled = false;
                this.sortBtn.IsEnabled = false;
                this.showBtn.IsEnabled = false;
            }
            else
            {
                this.searchByNameBtn.IsEnabled = true;
                this.searchByEmailBtn.IsEnabled = true;
                this.sortBtn.IsEnabled = true;
                this.showBtn.IsEnabled = true;
            }
        }
             
        private void ajouterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.nameTB.Text.Trim() == "" || this.emailTB.Text.Trim() == "") {
                MessageBox.Show("The name or e-mail is empty!");
                return;
            }
   

            if (strategy.Contains(this.nameTB.Text.Trim(),this.emailTB.Text.Trim()))
            {
                MessageBox.Show("The name or e-mail already exists!");
                return;
            }
            if (!Regex.IsMatch(this.emailTB.Text.Trim(), @"^([a-zA-z]+)\w*@(\w+)\.([a-zA-z]+)"))
            {
                MessageBox.Show("The format of the E-mail is incorrect!");
                return;
            }

                     
            strategy.Add(this.nameTB.Text.Trim(), this.emailTB.Text.Trim());
            changeButtonStatus(false);
        }

        private void searchByNameBtn_Click(object sender, RoutedEventArgs e)
        {
           this.showTB.Text = strategy.SearchByName(this.nameTB.Text.Trim());
        }

        private void showBtn_Click(object sender, RoutedEventArgs e)
        {
            this.showTB.Text = strategy.ShowAll();
        }

        private void sortBtn_Click(object sender, RoutedEventArgs e)
        {
            this.showTB.Text = strategy.Sort();
        }

        private void searchByEmailBtn_Click(object sender, RoutedEventArgs e)
        {
            this.showTB.Text = strategy.SearchByEmail(this.emailTB.Text.Trim());
        }

        private void radioButton_Click(object sender, RoutedEventArgs e)
        {
            strategy = instances[((RadioButton)sender).Name];
        }
    }
}
