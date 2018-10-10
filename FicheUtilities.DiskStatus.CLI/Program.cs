using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicheUtilities.DiskStatus.Core;
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
