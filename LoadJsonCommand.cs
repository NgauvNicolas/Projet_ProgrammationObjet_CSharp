namespace HonkaiStarRailBD;

using System.Text.Json;

public class LoadJsonCommand : Command
{
    public LoadJsonCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length != 1)
        {
            NbArgsOK = false;
        }
    }

    public override void Execute()
    {
        string jsonContent;

        if (!NbArgsOK)
        {
            Console.Error.WriteLine(
                "Vous n'avez pas fourni en argument le fichier JSON à charger."
            );
            return;
        }

        string JsonFilePath = Arguments[0];
        if (!File.Exists(JsonFilePath))
        {
            Console.WriteLine(
                "Le fichier JSON à charger n'existe pas ou est introuvable : vérifiez qu'il existe bien, et vérifiez également son chemin."
            );
            return;
        }

        try
        {
            jsonContent = File.ReadAllText(JsonFilePath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(
                $"Erreur rencontrée lors de la lecture du fichier JSON : {ex.Message}"
            );
            return;
        }

        try
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true };
            List<Character> ListePersosLus = JsonSerializer.Deserialize<List<Character>>(
                jsonContent,
                options
            );
            if (ListePersosLus == null)
            {
                Console.Error.WriteLine(
                    "Le contenu du fichier JSON est vide ou ne peut pas être désérialisé en une liste de personnages..."
                );
                return;
            }

            bool b = false;
            if (JsonFilePath == "Data/hsr_character-data.json")
            {
                b = true;
            }

            if (b)
            {
                foreach (Character character in ListePersosLus)
                {
                    if (ListePersos.Contains(character) && !ListePersos.Same(character))
                    {
                        ListePersos.OverrideCharacter(character);
                        Console.WriteLine(
                            $"{character.Name} existe déjà dans la base de données HonkaiStarRail, donc la commande `override` est exécutée à la place de `add`."
                        );
                    }
                    else if (ListePersos.Contains(character) && ListePersos.Same(character))
                    {
                        Console.WriteLine(
                            $"{character.Name} existe déjà dans la base de données HonkaiStarRail, et son ancienne entrée est identique à la nouvelle, donc on ne fait rien."
                        );
                        continue;
                    }
                    else
                    {
                        ListePersos.Add(character);
                    }
                }
            }
            else
            {
                foreach (Character character in ListePersosLus)
                {
                    if (ListePersos.Contains(character))
                    {
                        Console.WriteLine(
                            $"{character.Name} existe déjà dans la base de données HonkaiStarRail. Il ne sera donc pas chargé depuis le fichier JSON. Si vous voulez modifier (réécrire) ce personnage, vous pouvez utiliser la commander `override`."
                        );
                        Console.WriteLine();
                        continue;
                    }
                    else
                    {
                        ListePersos.Add(character);
                    }
                }
                return;
            }
        }
        catch (JsonException ex)
        {
            Console.Error.WriteLine($"Erreur de format JSON : {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
        }
    }
}
