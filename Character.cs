namespace HonkaiStarRailBD;

using System.Globalization;
//using System.Text.Json.Serialization;

public class Character
{
    public string Name { get; private set; }
    public string Rarity { get; private set; }
    public Path Path { get; private set; }
    public CombatType CombatType { get; private set; }
    private string Sep = "\n";

    // Constructeur sans paramètres requis pour la désérialisation
    public Character() { }

    //[JsonConstructor]
    public Character(string name, string rarity, Path path, CombatType combat_type)
    {
        TextInfo textInfo1 = new CultureInfo("fr", false).TextInfo;
        Name = textInfo1.ToTitleCase(name.ToLower());
        //Name = name;
        Rarity = rarity;
        //TextInfo textInfo2 = new CultureInfo("fr", false).TextInfo;
        //Path = textInfo2.ToTitleCase(path.ToLower());
        Path = path;
        //TextInfo textInfo3 = new CultureInfo("fr", false).TextInfo;
        //CombatType = textInfo3.ToTitleCase(combat_type.ToLower());
        CombatType = combat_type;
    }

    public override string ToString()
    {
        //string JoinCompetences = string.Join(", ", Competences);
        return $"Nom : {Name}{Sep}Rareté (étoiles) : {Rarity}{Sep}Voie : {Path}{Sep}Type : {CombatType}";
    }

    public CharacterDto ToDto()
    {
        CharacterDto dto = new CharacterDto()
        {
            _name = Name,
            _rarity = Rarity,
            _path = Path,
            _combatType = CombatType,
        };

        return dto;
    }
}
