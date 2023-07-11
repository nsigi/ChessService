using ChessService.HelpForms;

namespace ChessService
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new ChangePawnForm(1, new Point(100, 100)));
            Application.Run(new FieldUI());
        }
    }
}