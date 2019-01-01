﻿using System.ComponentModel.DataAnnotations;
using FicheUtilities.Storage;
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

        public ValidationResult OnValidate()
        {
            if(WarningThreshold > CriticalThreshold)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Warning Threshold value must be greater than the Critical Threshold value.");
            }
        }

        public void OnExecute()
        {
            var checker = StatusCheckerFactory.Create();
            var options = new StatusOptions(PathToStorage, WarningThreshold, CriticalThreshold, Verbose);
            var status = checker.GetStatus(options);

            foreach (var line in status)
            {
                ConsoleWriter.WriteLine(line.MessageType, line.Message);
            }
        }
    }
}
