using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FicheUtilities.DiskStatus.Core;
using McMaster.Extensions.CommandLineUtils;

namespace FicheUtilities.CLI
{
    [Command(Name = "lfutil", Description = "A collection of utilities useful for monitoring Laserfiche")]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand("storage", typeof(Storage))]
    public class LFUtil
    {
        private static string GetVersion() => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

        public virtual int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();

            return 0;
        }
    }
}
