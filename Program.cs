namespace HonkaiStarRailBD;

public class Program
{
    public static void Main(string[] args)
    {
        HonkaiStarRail hsr = new HonkaiStarRail();
        bool b = true;
        while (b)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(
                '\t',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
            );
            Console.WriteLine(string.Join(" ", commandArgs));

            if (
                !line.Contains('\t')
                && commandArgs[0].ToLower() != "exit"
                && commandArgs[0].ToLower() != "help"
            )
            {
                Console.Error.WriteLine(
                    "Vous avez peut-être oublié que le séparateur doit être la tabulation (Tab) ?"
                );
                continue;
            }
            if (
                line.Trim().Contains(' ')
                && commandArgs[0].ToLower() != "add"
                && commandArgs[0].ToLower() != "load"
            )
            {
                Console.Error.WriteLine(
                    "Vous avez peut-être oublié que le séparateur doit être la tabulation (Tab) ?"
                );
                continue;
            }

            CommandInterpreter interpreter = new CommandInterpreter(hsr);
            Command cmd = interpreter.Interpret(commandArgs);
            if (cmd != null)
            {
                cmd.Execute();
            }
            // Console.WriteLine(hsr);
            Console.WriteLine();
        }
    }
}
