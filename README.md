# UniLog

UniLog is a lightweight, extensible logging framework for SFS modding.

The main thing that it does is prefix log messages with a source identifier, making it easier to trace logs back to their origin.

## Features

- Simple logging interface (`ILogger`)
- Unity-compatible logger (`UnityDebugLogger`), using `Debug.Log` and `Debug.LogError`, etc.
- Easily extensible with custom loggers

## Usage

### 1. Get a Logger

```csharp
Logger logger = new UniLog.Logger(new UniLog.Loggers.UnityDebugLogger(), "MySource");
```

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

---
