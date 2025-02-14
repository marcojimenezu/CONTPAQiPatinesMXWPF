using CONTPAQiPatinesMXWPF.DLLIntegration;
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

namespace CONTPAQiPatinesMXWPF.UI.Dialogos
{
    /// <summary>
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private readonly IDLLIntegration _sdkIntegration;

        public MenuPrincipal(IDLLIntegration sdkIntegration)
        {
            _sdkIntegration = sdkIntegration;
            InitializeComponent();
        }

        private void AbrirModulo_Click(object sender, RoutedEventArgs e)
        {
            // Ejemplo: Abrir un nuevo diálogo desde aquí
        }
    }
}
