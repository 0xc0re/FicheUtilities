using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FicheUtilities.DiskStatus.Core;
using McMaster.Extensions.CommandLineUtils;

namespace FicheUtilities.CLI
{
    [Command(Description = "Gathers statistics on physical disk usage and returns either a simple status or detailed usage.")]
    public class Storage
    {
        [Required]
        [Option("-p|--path", Description = "Path to the disk to be checked. This can either be a UNC path or a drive letter.")]
        [DirectoryExists]
        public string PathToStorage { get; set; }

        [Required]
        [Option("-w|--warning-threshold", Description = "Threshold, in gigabytes, at which a warning result should be returned.")]
        public double WarningThreshold { get; set; }

        [Required]
        [Option("-c|--critical-threshold", Description = "Threshold, in gigabytes, at which a critical result should be returned.")]
        public double CriticalThreshold { get; set; }

        [Option("-v|--verbose", Description = "Display full disk statistics.")]
        public bool Verbose { get; set; }

        public void OnExecute()
        {
            var factory = new StatusCheckerFactory();
            var checker = factory.Create();
            var options = new StatusOptions(PathToStorage, WarningThreshold, CriticalThreshold, Verbose);
            var status = checker.GetStatus(options);

            foreach (var line in status)
            {
                ConsoleWriter.WriteLine(line.MessageType, line.Message);
            }
        }
    }
}
