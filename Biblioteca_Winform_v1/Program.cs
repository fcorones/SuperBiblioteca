namespace Biblioteca_Winform_v1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static string UserToken { get; set; }


        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var authContext = new AuthContext();

            // Mostrar el formulario de login primero
            var loginForm = new Login(authContext);
            Application.Run(loginForm);

            // Si el login fue exitoso y hay un token, abrir Form1
            if (!string.IsNullOrEmpty(authContext.UserToken))
            {
                Application.Run(new Form1());
            }
        }
    }
}