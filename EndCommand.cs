namespace HonkaiStarRailBD;

public class EndCommand : Command
{
    public EndCommand(HonkaiStarRail honkai, string[] arguments)
        : base(honkai, arguments) { }

    public override void Execute()
    {
        Console.WriteLine(
            "Le programme va maintenant se terminer. Merci d'avoir consulté la base de données des personnages de Honkai Star Rail (à noter que le jeu continue d'avoir des mises à jour et donc que les derniers personnages ajoutés ne sont possiblement pas dans la base de données T.T) !"
        );
        Environment.Exit(0);
        return;
    }
}
