namespace HonkaiStarRailBD;

using System.Globalization;

public class AddCommand : Command
{
    public AddCommand(HonkaiStarRail hsr, string[] arguments)
        : base(hsr, arguments)
    {
        if (arguments.Length < 4)
        {
            NbArgsOK = false;
        }
    }

    public override void Execute()
    {
        if (!NbArgsOK)
        {
            Console.Error.WriteLine(
                "Il n'y a pas le bon nombre d'arguments pour ajouter un Personnage (nom, rareté, voie, type et attention : le séparateur doit être une tabulation et non un espace)..."
            );
            return;
        }

        TextInfo textInfo = new CultureInfo("fr", false).TextInfo;
        string persoName = textInfo.ToTitleCase(Arguments[0].ToLower());
        string persoRarity = Arguments[1];
        string persoPath = textInfo.ToTitleCase(Arguments[2].ToLower());
        if (!Path.TryParse(persoPath, out Path charaPath))
        {
            Console.Error.WriteLine($"{persoPath} n'est pas une voie qui existe.");
            return;
        }
        string persoType = textInfo.ToTitleCase(Arguments[3].ToLower());
        if (!CombatType.TryParse(persoType, out CombatType charaType))
        {
            Console.Error.WriteLine($"{persoType} n'est pas un type qui existe.");
            return;
        }

        Character character = new Character(persoName, persoRarity, charaPath, charaType);
        if (ListePersos.Contains(character) && !ListePersos.Same(character))
        {
            Console.Error.WriteLine(
                $"{character.Name} existe déjà dans la base de données HonkaiStarRail, donc la commande `override` est exécutée à la place de `add`."
            );
            ListePersos.OverrideCharacter(character);
            return;
        }
        else if (ListePersos.Contains(character) && ListePersos.Same(character))
        {
            Console.Error.WriteLine(
                $"{character.Name} existe déjà dans la base de données HonkaiStarRail, et son ancienne entrée est identique à la nouvelle, donc on ne fait rien."
            );
            return;
        }
        ListePersos.Add(character);
        Console.WriteLine($"Personnage {persoName} ajouté à la base de données HonkaiStarRail !");
    }
}
