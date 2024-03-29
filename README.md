# Rerun

⚠️ **NOTE: Rerun development is on a temporary hiatus as we are focusing our efforts on developing [spikewall](https://github.com/Ramen2X/spikewall), which is simpler and as such can be developed quicker.**

![continuous](https://github.com/RunnersRevival/Rerun-server/actions/workflows/ci.yml/badge.svg)

***RERUN IS STILL A HEAVY WORK IN PROGRESS. It is not yet able to get the game to the main menu, and there are many, MANY missing features.***

Rerun is an advanced Sonic Runners server emulator powered by ASP.NET Core, based off of research done by fluofoxxo and FairPlay137. This project aims to reimplement [outrun](https://github.com/RunnersRevival/outrun) in C#.

**RERUN IS NOT CURRENTLY FEASIBLE FOR SELF-HOSTING.** The database system is still very much a work-in-progress, and as such it cannot be relied on at this early stage of development.

For support, please visit the Rerun Element Space [here](https://matrix.to/#/!vqhayGnOJhcecomYZf:matrix.org).

There is also documentation in the works, which can be viewed in the Docs folder.

## What you need to get this server working
* [Visual Studio 2022 or newer](https://visualstudio.microsoft.com/vs/) (Community version will work), or JetBrains Rider.
* [.NET 7.0 or newer SDK](https://dotnet.microsoft.com/download)
* ASP.NET Core build support
* A [MySQL](https://dev.mysql.com/downloads/) or [MariaDB](https://mariadb.org/download) instance
* [Git for Windows](https://git-scm.com/download/win)

## Projects in this repository
* Rerun - The main server.
* Rerun-Editor - The (Work-In-Progress) Windows-only Rerun Data Table (RDT) editor. This program will be the primary way to configure Rerun.

## What still needs to be done?
* Account registration
* Story Mode
* Timed Mode
* Character/buddy switching
* Roulette (vastly improved over Outrun, to more closely mirror the official server)
* Events
* Campaigns
* Configuration
* Shop
* Analytics
* Session ID purging

## FAQ
**Q:** Will this work on Linux and macOS as well?
* **A:** If there is a .NET runtime available for your platform, it'll run on it. So yes, it'll more than likely work just fine on Linux and macOS.

**Q:** Why isn't the port configurable?
* **A:** This functionality is coming soon, with the config data.

**Q:** How do I set up a database for use with Rerun?
* **A:** At the moment, you need to use the MySQL branch of Outrun for Revival to initialize the database (and register a player) as there are no routines to init the database or to create a player ID in Rerun yet. This will change in the near future though.

**Q:** Why rewrite Outrun?
* **A:** Because 1: all of Revival will be written using one programming language (C#), and 2: the Outrun for Revival codebase is starting to get a little bloated (with outdated research and lots of guesswork on fluofoxxo's part still being present), and is getting increasingly hard to maintain.

**Q:** Will debug endpoints be fulfilled?
* **A:** Maybe. If we do decide to implement them, we'll lock them behind a configuration option.

**Q:** Will I see differences when switching from Outrun for Revival?
* **A:** The behavior of some functions may change (such as the roulette), but the game itself won't change much. The configuration, on the other hand, will be quite different from Outrun for Revival, so some migration steps may be required.

**Q:** I've seen this project referred to as OutrunSharp in the past. What's the deal with that?
* **A:** After OutrunSharp started becoming its own thing, we decided to rename it to Rerun. Keep in mind Rerun is still focusing on bringing a solid codebase to the Runners server space.

**Q:** Isn't there another rewrite going on? What's with the fragmentation?
* **A:** Simply put, the development team is getting familiar with Runners server framework through having their own takes at rewrites, with one server, spikewall, being written in C# just like Rerun is. However, spikewall is much further along than Rerun, due to its simplicity.
