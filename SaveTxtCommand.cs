namespace HonkaiStarRailBD;

public class SaveTxtCommand : Command
{
    public SaveTxtCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length != 1)
        {
            NbArgsOK = false;
        }
    }

    private string AddExtension(string path)
    {
        if (!path.Contains(".txt"))
        {
            path = "Outputs/" + path + ".txt";
        }
        else
        {
            path = "Outputs/" + path;
        }
        return path;
    }

    public override void Execute()
    {
        if (!NbArgsOK)
        {
            Console.Error.WriteLine(
                "Nombre d'arguments incorrect : Il faut fournir le chemin pour sauvegarder la base de données HonkaiStarRail."
            );
            return;
        }

        string CheminOutput = AddExtension(Arguments[0]);

        try
        {
            using (StreamWriter writer = new StreamWriter(CheminOutput))
            {
                HonkaiStarRailDto hsrDto = ListePersos.ToDto();
                hsrDto.SaveTxt(writer);
                Console.WriteLine($"La base de données a bien été sauvegardée sous le nom que vous avez fourni : allez voir le dossier Outputs !");
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Erreur : Le chemin spécifié est introuvable.");
            return;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Erreur inattendue : {ex.Message}");
            return;
        }
    }
}
