namespace HonkaiStarRailBD;

using System.Globalization;

public class SearchCommand : Command
{
    public SearchCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments)
    {
        if (arguments.Length < 2)
        {
            NbArgsOK = false;
        }
    }

    Character[] GetByRarity(string rarity)
    {
        if ((rarity != "4") && (rarity != "5"))
        {
            Console.Error.WriteLine(
                "Le Rareté du personnage que vous cherchez n'existe pas. Pour rappel, il y a 2 sortes de rareté (en étoiles) : (4|5) <string>."
            );
            return null;
        }
        var CharactersDeTelleRarity = ListePersos.GetByRarity(rarity);
        Character[] charactersArray = CharactersDeTelleRarity.ToArray();
        return charactersArray;
    }

    Character[] GetByPath(string path)
    {
        if (!Path.TryParse(path, ignoreCase: true, out Path p))
        {
            Console.Error.WriteLine("La Voie que vous cherchez n'existe pas.");
            return null;
        }
        var CharactersDeTellePath = ListePersos.GetByPath(p);
        Character[] charactersArray = CharactersDeTellePath.ToArray();
        return charactersArray;
    }

    Character[] GetByType(string type)
    {
        if (!CombatType.TryParse(type, ignoreCase: true, out CombatType t))
        {
            Console.Error.WriteLine("Le type de combat que vous cherchez n'existe pas.");
            return null;
        }
        var CharactersDeTelleType = ListePersos.GetByType(t);
        Character[] charactersArray = CharactersDeTelleType.ToArray();
        return charactersArray;
    }

    public override void Execute()
    {
        if (!NbArgsOK)
        {
            Console.Error.WriteLine(
                "Il n'y a pas assez d'arguments pour effectuer une recherche de personnage.\nCommande valide : (name|rarity|path|type) <string>."
            );
            return;
        }

        string TypeDeSearch = Arguments[0].ToLower();
        switch (TypeDeSearch)
        {
            case "name":
                TextInfo textInfo1 = new CultureInfo("fr", false).TextInfo;
                string motifName = textInfo1.ToTitleCase(Arguments[1].ToLower());
                Character characterTrouve = ListePersos.GetByName(motifName);
                if (characterTrouve != null)
                {
                    Console.WriteLine(characterTrouve);
                }
                else
                {
                    Console.WriteLine("Le personnage n'est pas présent dans la base de données HonkaiStarRail.");
                }
                return;
            case "rarity":
                Character[] charactersByRarity = GetByRarity(Arguments[1]);
                if (charactersByRarity != null)
                {
                    foreach (Character c in charactersByRarity)
                    {
                        Console.WriteLine(c);
                        Console.WriteLine();
                    }
                }
                return;
            case "path":
                TextInfo textInfo2 = new CultureInfo("fr", false).TextInfo;
                string motifPath = textInfo2.ToTitleCase(Arguments[1].ToLower());
                Character[] charactersByPath = GetByPath(motifPath);
                if (charactersByPath != null)
                {
                    foreach (Character c in charactersByPath)
                    {
                        Console.WriteLine(c);
                        Console.WriteLine();
                    }
                }
                return;
            case "type":
                TextInfo textInfo3 = new CultureInfo("fr", false).TextInfo;
                string motifType = textInfo3.ToTitleCase(Arguments[1].ToLower());
                Character[] charactersByType = GetByType(motifType);
                if (charactersByType != null)
                {
                    foreach (Character c in charactersByType)
                    {
                        Console.WriteLine(c);
                        Console.WriteLine();
                    }
                }
                return;
            default:
                Console.Error.WriteLine(
                    "Le Type de recherche est invalide. Il faut choisir entre (name|rarity|path|type)"
                );
                return;
        }
    }
}
