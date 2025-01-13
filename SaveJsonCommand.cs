namespace HonkaiStarRailBD;

public class SaveJsonCommand : Command
{
    public SaveJsonCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length != 1)
        {
            NbArgsOK = false;
        }
    }

    private string AddExtension(string path)
    {
        if (!path.Contains(".json"))
        {
            path = "Outputs/" + path + ".json";
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
        HonkaiStarRailDto ListePersosDto = ListePersos.ToDto();
        ListePersosDto.SaveJson(CheminOutput);
    }
}
