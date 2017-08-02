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

namespace JeuDeDes
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dé dé;
        private decimal[] résultat = new decimal[2];
                
        public MainWindow()
        {
            InitializeComponent();
            dé = Factory.ObtenirInstance("SixCotés");
        }

        private void Dé_Click(object sender, RoutedEventArgs e)
        {
            dé = Factory.ObtenirInstance(((RadioButton)sender).Name);
        }

        private void DéactiverBoutonCrédit(bool premierClique)
        {
            if (premierClique)
                this.txbCrédit.IsEnabled = false;
        }

        private void Jouer_Click(object sender, RoutedEventArgs e)
        {

            string[] champsAValider = new string[3];
            champsAValider[GlobalVariables.CHOIX] = this.txbChoix.Text.Trim();
            champsAValider[GlobalVariables.CREDIT] = this.txbCrédit.Text.Trim();
            champsAValider[GlobalVariables.MISE] = this.txbMise.Text.Trim();         

            string erreurMessage = champsAValider.ErreursDe(dé);

            if (erreurMessage == null)
            {
                DéactiverBoutonCrédit(true);

                int valeurJeu = dé.LancerDé();
                résultat = dé.Calculer(valeurJeu - int.Parse(this.txbChoix.Text)
                                      , decimal.Parse(this.txbCrédit.Text)
                                      , decimal.Parse(this.txbMise.Text));

                this.txbValeur.Text = valeurJeu.ToString();
                this.txbGainPerte.Text = résultat[GlobalVariables.GAIN_PERTE].ToString();
                this.txbCrédit.Text = résultat[GlobalVariables.CREDIT].ToString();

                if (résultat[GlobalVariables.CREDIT] < 0)
                {
                    this.Jouer.IsEnabled = false;
                    MessageBox.Show("Le jeu est terminé!");
                }                   
            }
            else
            {
                MessageBox.Show(erreurMessage);
            }
        }
    }
}
