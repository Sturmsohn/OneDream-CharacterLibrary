using CharacterLibrary.Data;
using CharacterLibrary.Forms;

namespace CharacterLibrary
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Ensure the SQLite DB exists on first run. For a personal app this is
            // simpler than managing migrations; if you later want schema evolution,
            // switch to `dotnet ef migrations add` + db.Database.Migrate().
            using (var db = new CharacterDbContext())
            {
                db.Database.EnsureCreated();
            }

            // Ensure the Images folder exists next to the exe.
            Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, "Images"));

            Application.Run(new MainForm());
        }
    }
}
