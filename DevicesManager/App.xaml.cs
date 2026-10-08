namespace DevicesManager
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            var window = new Window(new AppShell());

            // 2. Definimos o título que você deseja exibir na barra do Windows
            window.Title = "Gerenciador de Dispositivos";

            // 3. Retornamos a janela configurada
            return window;
        }
    }
}