using System.Text.RegularExpressions;

namespace HonkaiStarRailBD;

public class CommandInterpreter
{
    public HonkaiStarRail ListePersos { get; private set; }

    //public CommandInterpreter(HonkaiStarRail honkai)
    //{
    //ListePersos = Honkai;
    //}

    public CommandInterpreter(HonkaiStarRail honkai)
    {
        ListePersos = honkai;
    }

    public Command Interpret(string[] args)
    {
        if (args.Length < 0)
        {
            throw new ArgumentException("Pas assez d'arguments.");
        }

        string CommandName = args[0].ToLower();
        //commandName = localizationService.GetText(commandName);
        string[] commandArguments = args.Skip(1).ToArray();

        switch (CommandName)
        {
            case "help":
                DocCommand cmdDoc = new DocCommand(ListePersos, commandArguments);
                return cmdDoc;            
            case "add":
                AddCommand cmdAdd = new AddCommand(ListePersos, commandArguments);
                return cmdAdd;
            case "override":
                OverrideCommand cmdOverride = new OverrideCommand(ListePersos, commandArguments);
                return cmdOverride;
            case "search":
                SearchCommand cmdSearch = new SearchCommand(ListePersos, commandArguments);
                return cmdSearch;
            case "savejson":
                SaveJsonCommand cmdSaveJson = new SaveJsonCommand(ListePersos, commandArguments);
                return cmdSaveJson;
            case "loadjson":
                LoadJsonCommand cmdLoadJson = new LoadJsonCommand(ListePersos, commandArguments);
                return cmdLoadJson;
            case "savetxt":
                SaveTxtCommand cmdSaveTxt = new SaveTxtCommand(ListePersos, commandArguments);
                return cmdSaveTxt;
            case "loadtxt":
                LoadTxtCommand cmdLoadTxt = new LoadTxtCommand(ListePersos, commandArguments);
                return cmdLoadTxt;
            case "exit":
                EndCommand cmdEnd = new EndCommand(ListePersos, commandArguments);
                return cmdEnd;
            default:
                Console.Error.WriteLine($"Commande Invalide ! La commande {CommandName} n'existe pas.");
                return null;
            //throw new CommandNotFoundException($"La commande {CommandName} n'existe pas.");
        }
    }
}
