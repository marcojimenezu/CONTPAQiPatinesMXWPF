using CONTPAQiPatinesMXWPF.DLLIntegration;
using CONTPAQiPatinesMXWPF.UI.Dialogos;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CONTPAQiPatinesMXWPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDLLIntegration _sdkIntegration;

        public MainWindow(IDLLIntegration sdkIntegration)
        {
            _sdkIntegration = sdkIntegration;
            InitializeComponent();
        }


        private void BtnValidar_Click(object sender, RoutedEventArgs e)
        {



            try
            {
                // Validar el acceso y la ruta de la DLL
                _sdkIntegration.ObtenerRutaDll();

                string usuario = txtUsuario.Text;
                string contrasenia = txtContrasena.Password;

                // Llamada al método de la interfaz para iniciar sesión
                bool resultado = _sdkIntegration.InicioSesion(usuario, contrasenia);

                MessageBox.Show("Validación exitosa. Cargando menú principal...", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                // Abrir el MenuPrincipal
                var menuPrincipal = new MenuPrincipal(_sdkIntegration);
                menuPrincipal.Show();

                // Cerrar el diálogo de login
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la validación: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}