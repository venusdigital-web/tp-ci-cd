# MonApp — projet de départ du TP CI/CD

Petite application web ASP.NET Core (.NET 9) qui sert de « projet à déployer » dans le TP.
Elle affiche un message d'accueil et la **version de l'image** qui la fait tourner.

| Adresse | Réponse |
|---|---|
| `/` | page d'accueil (message + version de l'image) |
| `/version` | la version seule, pratique avec `curl` |
| `/health` | `ok` |

## Mise en place

1. Crée un dépôt GitHub vide (privé ou public) sur ton compte.
2. Décompresse cette archive, puis à la racine du dossier :

   ```bash
   git init -b main
   git add -A
   git commit -m "Projet de départ"
   git remote add origin https://github.com/<toi>/<ton-depot>.git
   git push -u origin main
   ```

## Essayer en local (facultatif)

```bash
docker build --build-arg APP_VERSION=essai -t monapp .
docker run --rm -p 8080:8080 monapp
# puis http://localhost:8080
```

Le message à modifier à l'étape 9 est la constante `MessageAccueil` dans `Program.cs`.
