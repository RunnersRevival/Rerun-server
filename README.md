# OutrunSharp

![nightly build](https://github.com/FairPlay137/OutrunSharp/actions/workflows/ci.yml/badge.svg)

A WIP C# rewrite of [outrun](https://github.com/Mtbcooler/outrun), the server software powering Sonic Runners Revival.

OutrunSharp is a Sonic Runners custom server powered by ASP.NET, based off of research done by fluofoxxo and FairPlay137.

This server is not yet ready for general use just yet, as it currently relies on all the necessary Outrun database entries being there.

## What you need to get this server working
* Visual Studio 2019 or better (Community version will work)
* .NET 5.0 or better SDK
* ASP.NET build support
* A MySQL instance

## What still needs to be done?
* Account registration
* Story Mode
* Timed Mode
* Character switching
* Roulette
* Events
* Configuration (compatible with Outrun)
* Campaigns
* pretty much everything else lmao

## FAQ
**Q:** Will this work on Linux and macOS as well?
**A:** If there is a .NET 5 runtime available for your platform, it'll run on it. So yes, it'll more than likely work just fine on Linux and macOS.

**Q:** Why isn't the port configurable yet?
**A:** Because I haven't figured out a way to make it configurable just yet.

**Q:** How do I set up a database for use with OutrunSharp?
**A:** At the moment, you need to use the MySQL branch of Outrun for Revival to initialize the database as there are no routines to init the database in OutrunSharp yet.

**Q:** Why rewrite Outrun?
**A:** Because 1: all of Revival will be written using one programming language, and 2: the Outrun for Revival codebase is starting to get a little bloated, and is getting increasingly hard to maintain.
