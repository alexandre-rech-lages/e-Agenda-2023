using e_Agenda.Dominio.ModuloCompromisso;

namespace e_Agenda.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Compromisso compromisso = new Compromisso();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new TelaPrincipalForm());
        }
    }
}