# Rerun

![continuous](https://github.com/RunnersRevival/Rerun-server/actions/workflows/ci.yml/badge.svg)

***RERUN IS STILL A HEAVY WORK IN PROGRESS. It is not yet able to get the game to the main menu, and there are many, MANY missing features.***

Rerun is a Sonic Runners server emulator powered by ASP.NET Core, based off of research done by fluofoxxo and FairPlay137. This project aims to reimplement [outrun](https://github.com/RunnersRevival/outrun) in C#. It will become the server software powering Sonic Runners Revival once it is deemed ready for production.

**RERUN IS NOT CURRENTLY FEASIBLE FOR SELF-HOSTING.** Rerun currently relies on all the necessary MySQL Outrun for Revival database entries being there. In the future, we'll handle the creation of MySQL tables just like what Outrun for Revival MySQL does.

For support, please visit the Rerun Element Space [here](https://matrix.to/#/!vqhayGnOJhcecomYZf:matrix.org).

There is also documentation in the works, which can be viewed in the Docs folder.

## What you need to get this server working
* [Visual Studio 2022 or newer](https://visualstudio.microsoft.com/vs/) (Community version will work), or JetBrains Rider.
* [.NET 6.0 or better SDK](https://dotnet.microsoft.com/download)
* ASP.NET Core build support
* A [MySQL](https://dev.mysql.com/downloads/) or [MariaDB](https://mariadb.org/download) instance
* [Git for Windows](https://git-scm.com/download/win)

## What still needs to be done?
* Account registration
* Story Mode
* Timed Mode
* Character/buddy switching
* Roulette (vastly improved over Outrun, to more closely mirror the official server)
* Events
* Campaigns
* Configuration (as compatible with Outrun as possible, but more expansive)
* Shop
* Analytics

## FAQ
**Q:** Will this work on Linux and macOS as well?
* **A:** If there is a .NET runtime available for your platform, it'll run on it. So yes, it'll more than likely work just fine on Linux and macOS.

**Q:** Why isn't the port configurable?
* **A:** Because I haven't figured out a way to make it configurable just yet. Expect this to be fixed soon!

**Q:** How do I set up a database for use with Rerun?
* **A:** At the moment, you need to use the MySQL branch of Outrun for Revival to initialize the database (and register a player) as there are no routines to init the database or to create a player ID in Rerun yet.

**Q:** Why rewrite Outrun?
* **A:** Because 1: all of Revival will be written using one programming language (C#), and 2: the Outrun for Revival codebase is starting to get a little bloated (with outdated research and lots of guesswork on fluofoxxo's part still being present), and is getting increasingly hard to maintain.

**Q:** Will debug endpoints be fulfilled?
* **A:** Maybe. If we do decide to implement them, we'll lock them behind a configuration option.

**Q:** Will I see differences when switching from Outrun for Revival?
* **A:** The behavior of some functions may change (such as the roulette), but the game itself won't change much. The configuration, on the other hand, will be quite different from Outrun for Revival, so some migration steps may be required.
