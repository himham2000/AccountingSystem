using QuestPDF.Infrastructure;
namespace AccountingSystem {
    static class Program {
        [STAThread]
        static void Main() {
            QuestPDF.Settings.License = LicenseType.Community;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}