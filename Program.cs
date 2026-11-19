namespace MonApp
{
    internal class Program
    {
        // Le texte à modifier à l'étape 9 du TP.
        private const string MessageAccueil = "Bonjour depuis le pipeline CI/CD !";

        private static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            WebApplication app = builder.Build();

            // APP_VERSION est gravée dans l'image au moment du build (voir Dockerfile) : elle permet
            // de vérifier que dev et staging font tourner exactement la même image.
            string version = Environment.GetEnvironmentVariable("APP_VERSION") ?? "locale";
            string machine = Environment.MachineName;

            app.MapGet("/", () => Results.Content($"""
                <!doctype html>
                <html lang="fr">
                <head><meta charset="utf-8"><title>MonApp</title></head>
                <body style="font-family: sans-serif; max-width: 40rem; margin: 3rem auto;">
                  <h1>{MessageAccueil}</h1>
                  <p>Version de l'image : <strong>{version}</strong></p>
                  <p>Conteneur : {machine}</p>
                </body>
                </html>
                """, "text/html; charset=utf-8"));

            // Réponse courte pour les vérifications en ligne de commande (curl).
            app.MapGet("/version", () => Results.Text(version + "\n"));
            app.MapGet("/health", () => Results.Text("ok\n"));

            app.Run();
        }
    }
}
