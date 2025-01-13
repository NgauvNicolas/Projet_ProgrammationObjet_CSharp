namespace HonkaiStarRailBD;

public class CharacterDto
{
    public string _name { private get; set; }
    public string _rarity { private get; set; }
    public Path _path { private get; set; }
    public CombatType _combatType { private get; set; }

    private string Sep = ",";

    public string WritingForm
    {
        get { return $"{_name}{Sep}{_rarity}{Sep}{_path}{Sep}{_combatType}"; }
    }
}
