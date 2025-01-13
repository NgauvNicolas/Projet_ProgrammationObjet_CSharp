namespace HonkaiStarRailBD;

public class LoadTxtCommand : Command
{
    public LoadTxtCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length < 1)
        {
            NbArgsOK = false;
        }
    }

    public override void Execute()
    {
        if (!NbArgsOK)
        {
            Console.Error.WriteLine("Vous n'avez pas fourni en argument le fichier txt à charger.");
            return;
        }

        string path = Arguments[0];
        if (!File.Exists(path))
        {
            throw new Exception(
                "Le fichier txt à charger n'existe pas ou est introuvable : vérifiez qu'il existe bien, et vérifiez également son chemin."
            );
        }
        StreamReader reader = new StreamReader(path);
        List<string> lines = new List<string>();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                lines.Add(line);
            }
        }

        foreach (string line in lines)
        {
            string[] elements = line.Split(
                ',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            );
            if (elements.Length < 4)
            {
                Console.WriteLine(
                    $"Cette ligne n'est pas valable (il faut 4 éléments séparés par des virgules) : {line}"
                );
                continue;
            }
            string PersoName = elements[0];
            string PersoRarity = elements[1];
            if (!Path.TryParse(elements[2], ignoreCase: true, out Path PersoPath))
            {
                throw new Exception("Le 3e élément de la ligne n'est pas une voie disponible.");
            }
            if (!CombatType.TryParse(elements[3], ignoreCase: true, out CombatType PersoType))
            {
                throw new Exception(
                    "Le 4 élément de la ligne n'est pas un type de combat disponible."
                );
            }
            Character character = new Character(PersoName, PersoRarity, PersoPath, PersoType);
            if (ListePersos.Contains(character))
            {
                Console.WriteLine(
                    $"{character.Name} existe déjà dans la base de données HonkaiStarRail. Il ne sera donc pas chargé depuis le fichier txt. Si vous voulez modifier (réécrire) ce personnage, vous pouvez utiliser la commander `override`."
                );
                Console.WriteLine();
                continue;
            }
            else
            {
                ListePersos.Add(character);
                Console.WriteLine($"Les informations sur {character.Name} ont bien été chargé !");
            }
        }
    }
}
