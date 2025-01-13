namespace HonkaiStarRailBD;

public class HonkaiStarRail
{
    //public List<Character> ListePersos { get; private set; }
    List<Character> ListePersos;

    public HonkaiStarRail()
    {
        ListePersos = new List<Character>();
    }

    public HonkaiStarRail(List<Character> characters)
    {
        ListePersos = characters;
    }

    public void Add(Character character)
    {
        ListePersos.Add(character);
    }

    public bool Contains(Character character)
    {
        bool b = false;
        string CharacterNameToLookUp = character.Name;
        foreach (Character c in ListePersos)
        {
            if (c.Name == CharacterNameToLookUp)
            {
                b = true;
            }
        }
        return b;
    }

    public bool Same(Character character)
    {
        bool b = false;
        foreach (Character c in ListePersos)
        {
            if (c.Name == character.Name && c.Rarity == character.Rarity && c.Path == character.Path && c.CombatType == character.CombatType)
            {
                b = true;
            }
        }
        return b;
    }

    public bool ISNull()
    {
        return ListePersos.Count == 0;
    }

    public void OverrideCharacter(Character character)
    {
        int index = ListePersos.FindIndex(c => c.Name == character.Name);
        ListePersos[index] = character;
        return;
    }

    public override string ToString()
    {
        if (ListePersos == null)
        {
            Console.WriteLine("La base de données des personnages de Honkai Star Rail est vide.");
            return "";
        }

        string output = "";
        foreach (Character character in ListePersos)
        {
            output += character.ToString() + "\n";
        }
        return output;
    }

    public Character GetByName(string name)
    {
        foreach (Character c in ListePersos)
        {
            if (c != null && c.Name.ToLower() == name.ToLower())
            {
                return c;
            }
        }
        return null;
    }

    public IEnumerable<Character> GetByRarity(string r)
    {
        foreach (Character c in ListePersos)
        {
            if (c != null && c.Rarity == r)
            {
                yield return c;
            }
        }
    }

    public IEnumerable<Character> GetByType(CombatType t)
    {
        foreach (Character c in ListePersos)
        {
            if (c != null && (c.CombatType & t) == t)
            {
                yield return c;
            }
        }
    }

    public IEnumerable<Character> GetByPath(Path p)
    {
        foreach (Character c in ListePersos)
        {
            if (c != null && (c.Path & p) == p)
            {
                yield return c;
            }
        }
    }

    public HonkaiStarRailDto ToDto()
    {
        Func<Character, CharacterDto> lambda = PARAM => PARAM.ToDto();
        return new HonkaiStarRailDto
        {
            // On converti tous les personnages en leur version DTO
            _ListePersos = ListePersos.Where(p => p != null).Select(lambda).ToList(),
        };
    }
}
