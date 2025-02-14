using CONTPAQiPatinesMXWPF.DLLIntegration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CONTPAQiPatinesMXWPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        private IDLLIntegration _sdkIntegration; // Variable para almacenar la instancia de la DLL

        // Configuración de servicios
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDLLIntegration, SDKIntegration>(); // Registrar el servicio de integración
            services.AddSingleton<MainWindow>(); // Registrar la ventana principal
        }

        // Método de inicialización al iniciar la aplicación
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configurar los servicios
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Obtener la instancia de IDLLIntegration
            _sdkIntegration = ServiceProvider.GetRequiredService<IDLLIntegration>();

            // Crear e iniciar la ventana principal
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        // Método que se ejecuta al cerrar la aplicación
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            try
            {
                // Terminar la sesión de la DLL
                _sdkIntegration?.TerminaSDK();
                Console.WriteLine("Sesión del SDK terminada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al terminar la sesión del SDK: {ex.Message}");
            }
        }
    }

}
