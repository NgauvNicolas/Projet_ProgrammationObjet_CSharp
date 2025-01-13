namespace HonkaiStarRailBD;

public class DocCommand : Command
{
    public DocCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments) { }

    public override void Execute()
    {
        StreamReader reader = new StreamReader("README.md");
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                Console.WriteLine(line);
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("PETIT RAPPEL");
        Console.WriteLine("Liste de personnages existants :");
        StreamReader NameListReader = new StreamReader("Data/character_name.txt");
        while (!NameListReader.EndOfStream)
        {
            string line = NameListReader.ReadLine();
            if (line != null)
            {
                Console.WriteLine($"\t{line}");
            }
        }
        Console.WriteLine(
            "Liste des voies existantes pour les personnages (toutes les voies ne sont pas accessibles aux personnages, certaines voies ne sont accessibles qu'aux ennemis):"
        );
        StreamReader PathListReader = new StreamReader("Data/path_name.txt");
        while (!PathListReader.EndOfStream)
        {
            string line = PathListReader.ReadLine();
            if (line != null)
            {
                Console.WriteLine($"\t{line}");
            }
        }
        Console.WriteLine("Liste des types existants :");
        StreamReader TypeListReader = new StreamReader("Data/combat_type_name.txt");
        while (!TypeListReader.EndOfStream)
        {
            string line = TypeListReader.ReadLine();
            if (line != null)
            {
                Console.WriteLine($"\t{line}");
            }
        }
        Console.WriteLine("Liste de rareté des Personnages existants (en étoiles):");
        StreamReader RarityListReader = new StreamReader("Data/character_rarity.txt");
        while (!RarityListReader.EndOfStream)
        {
            string line = RarityListReader.ReadLine();
            if (line != null)
            {
                Console.WriteLine($"\t{line}");
            }
        }
        return;
    }
}
