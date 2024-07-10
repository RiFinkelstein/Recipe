using CPUFramework;

namespace RecipeWinForms
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
            //SQLUtility.ConnectionString = "Server=tcp:rfinkelstein.database.windows.net,1433;Initial Catalog=HeartyHealthDB;Persist Security Info=False;User ID=Rfinkelstein;Password=#Perlman6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";
            SQLUtility.ConnectionString = "Server=.\\SQLExpress;Database=HeartyHealthDB;Trusted_Connection=True;TrustServerCertificate=True";
            Application.Run(new frmSearch());
        }
    }
}