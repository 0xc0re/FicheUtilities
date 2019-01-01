using McMaster.Extensions.CommandLineUtils;

namespace FicheUtilities.CLI
{
    [Command(Name ="lfutil", Description = "A collection of utilities useful for monitoring Laserfiche")]
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineApplication.ExecuteAsync<LFUtil>(args);
        }
    }
}
