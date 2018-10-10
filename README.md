# FicheUtilities
A collection of utilities to make administering Laserfiche easier

Currently the core cli tools supports only the `storage` verb, but over time other functionality will be added.

## CLI
```
lfutil [options] [command]

Options:
  --version     Show version information
  -?|-h|--help  Show help information

Commands:
  storage       Gathers statistics on physical disk usage and returns either a simple status or detailed usage.
```
## Storage Verb

Checking disk usage statistics is easy using a number of methods. This command came out of a need to allow our monitoring software to have a thumbs up/thumbs down look into our storage usage. Due to our particular combination of SAN, server config, and monitoring software. Given a threshold at which to throw a warning, and one for critical, this tool will return a simple reply of OK, WARNING, or CRITICAL. Our monitoring system then reads the string and reports the status.

```
Usage: lfutil storage [options]

Options:
  -p|--path                Path to the disk to be checked. This can either be a UNC path or a drive letter.
  -w|--warning-threshold   Threshold, in gigabytes, at which a warning result should be returned.
  -c|--critical-threshold  Threshold, in gigabytes, at which a critical result should be returned.
  -v|--verbose             Display full disk statistics.
  -?|-h|--help             Show help information
```
