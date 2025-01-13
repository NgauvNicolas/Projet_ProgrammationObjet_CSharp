namespace HonkaiStarRailBD;

public abstract class Command
{
    protected HonkaiStarRail ListePersos;
    protected bool NbArgsOK = true;
    protected string[] Arguments;

    public Command(HonkaiStarRail honkai, string[] commandArguments)
    {
        ListePersos = honkai;
        Arguments = commandArguments;
    }

    public abstract void Execute();
}
