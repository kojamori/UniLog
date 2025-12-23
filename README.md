# UniLog

UniLog is a lightweight, extensible logging framework for SFS modding.

The main thing that it does is prefix log messages with a source identifier, making it easier to trace logs back to their origin.

## Features

- Simple logging interface (`ILogger`)
- Unity-compatible logger (`UnityDebugLogger`), using `Debug.Log` and `Debug.LogError`, etc.
- Easily extensible with custom loggers

## Installation

1. Either clone the repository and build the `UniLog` project into a DLL, or download a pre-built DLL from the [releases page](https://github.com/kojamori/UniLog/releases/).
2. Add `unilog` as a dependency in your mod's `Dependencies` property.
3. Place the `UniLog.dll` file into a folder in Mods (`Mods/UniLog/`).
4. Add `UniLog.dll` as a reference in your mod project.
5. Use UniLog in your mod!

## Usage

### 1. Get a Logger

```csharp
Logger logger = new UniLog.Logger(new UniLog.Loggers.UnityDebugLogger(), "MySource");
```

Optionally store the logger as a static internal field in your mod's main class for safe and easy access.
You can also replace `UnityDebugLogger` with any custom logger that implements `ILogger`.

There is also the `boolean prefix` parameter in the `Logger` constructor that controls whether to prefix log messages with the type of log (e.g. `[LOG]`, `[WARNING]`, `[ERROR]`). By default, this is `false`.

### 2. Log Messages

```csharp
logger.Info("This is an info message");
logger.Warn("This is a warning");
logger.Error("This is an error");

// output (SFS console)
// [LOG]: [MySource] This is an info message
// [WARNING]: [MySource] This is a warning
// [ERROR]: [MySource] This is an error
```

### 3. Custom Loggers

Implement `ILogger` and use it whenever instantiating a new `Logger`.

```csharp
public class MyCustomLogger : UniLog.ILogger
{
	public void Info(string source, string message)
	{
		// Custom info logging implementation
	}
	public void Warn(string source, string message)
	{
		// Custom warning logging implementation
	}
	public void Error(string source, string message)
	{
		// Custom error logging implementation
	}
}
```

```csharp
Logger customLogger = new UniLog.Logger(new MyCustomLogger(), "MySource");
```

## Example Mod

```csharp
using ModLoader;
using UniLog;
using UniLog.Loggers;
using System.Collections.Generic;

namespace MyMod
{
		public class Main : Mod
		{
				public static Main Instance { get; private set; }
				public Main()
				{
						Instance = this;
				}

				public override string ModNameID => "mymod";
				public override string DisplayName => "My Mod";
				public override string Author => "Your Name Here";
				public override string Description => "Your mod description here.";
				public override string ModVersion => "1.0.0";
				public override string MinimumGameVersionNecessary => "1.6.00.0";
				public override Dictionary<string, string> Dependencies => new Dictionary<string, string>
				{
						{ "unilog", "" }
				};

				public override void Early_Load()
				{
						this.logger = new Logger(new UnityDebugLogger(), ModNameID);
				}

				public override void Load()
				{
						logger.Info("My mod has loaded!");
				}

				internal static Logger logger;
		}
}
```

![alt text](ex.png)

## License

GNU General Public License. See LICENSE file for details
