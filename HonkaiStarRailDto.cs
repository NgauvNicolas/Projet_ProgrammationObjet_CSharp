namespace HonkaiStarRailBD;

public class HonkaiStarRailDto
{
    public List<CharacterDto> _ListePersos {get; set;}

    public void SaveTxt(StreamWriter file)
    {
        if (_ListePersos == null)
        {
            Console.Error.WriteLine("La base de données des personnages de Honkai Star Rail est vide.");
            return;
        }
        foreach (CharacterDto characterDto in _ListePersos)
        {
            if (characterDto != null)
            {
                file.WriteLine(characterDto.WritingForm);
            }
        }
    }


    public void SaveJson(string CheminOutput = "ResultatsListePersos.json")
    {
        if (_ListePersos == null)
        {
            Console.Error.WriteLine("La base de données des personnages de Honkai Star Rail est vide.");
            return;
        }
        string jsonOutput = System.Text.Json.JsonSerializer.Serialize(_ListePersos, new System.Text.Json.JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
        File.WriteAllText(CheminOutput, jsonOutput);
        if (CheminOutput == "ResultatsListePersos.json")
        {
            Console.WriteLine("Les personnages sont sauvegardés dans le fichier Outputs/ResultsListePersos.json");
        }
        else
        {
            Console.WriteLine($"Les personnages sont sauvegardés dans le fichier {CheminOutput}");
        }
    }
}
