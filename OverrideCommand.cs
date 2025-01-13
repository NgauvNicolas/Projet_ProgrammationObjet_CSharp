namespace HonkaiStarRailBD;

using System.Globalization;

public class OverrideCommand : Command
{
    public OverrideCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length != 4)
        {
            NbArgsOK = false;
        }
    }

    public override void Execute()
    {
        if (!NbArgsOK)
        {
            Console.Error.WriteLine(
                "Il n'y a pas le bon nombre d'arguments pour modifier (réécrire) un Personnage (nom, rareté, voie, type et attention : le séparateur doit être une tabulation et non un espace)..."
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
        if (!ListePersos.Contains(character))
        {
            Console.Error.WriteLine(
                $"{character.Name} n'existe pas encore dans la base de données HonkaiStarRail, donc la commande `add` est exécutée à la place de `override`."
            );
            ListePersos.Add(character);
            return;
        }
        else if (ListePersos.Contains(character) && ListePersos.Same(character))
        {
            Console.Error.WriteLine(
                $"{character.Name} existe déjà dans la base de données HonkaiStarRail, et son ancienne entrée est identique à la nouvelle, donc on ne fait rien."
            );
            return;
        }
        ListePersos.OverrideCharacter(character);
        Console.WriteLine(
            $"Personnage {persoName} modifié (réécrit) dans la base de données HonkaiStarRail !"
        );
    }
}
