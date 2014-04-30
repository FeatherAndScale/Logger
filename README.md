Logger
======

Ridiculously simple, highly opinionated Logging library for .NET.

Prerequisite
-------------
.NET Framework 4.5.

Usage
-----

Instantiate a new **LoggerRegistry** and assign to a static property, or inject into your classes using IoC.

```csharp
public static ILoggerRegistry LoggerRegistry = new LoggerRegistry();
```

Get an instance of **ILogger** by calling the **Logger()** method of **LoggerRegistry**. The **Logger()** method takes a key as string, which 
you should generate using the **MakeKey()** helper method provided. **MakeKey()** accepts a param array of Ids that will be concatenated
into a key; something like "aaa.bbb.ccc".

```csharp
private ILogger _log = LoggerRegistry.Logger(LoggerRegistry.MakeKey("MyProject", "MyClass", "SomeId"));
```

If an instance of **ILogger** with that key has been instantiated before (within the lifetime of the **LoggerRegistry**) it will be 
returned, otherwise a new instance will be created.

Now you can use the instance of **ILogger** to log messages in your code, e.g.

```csharp
foreach (var image in images)
{
    _log.Message("Importing image {0}", new object[] { image });
    // ... etc
}
```

There are three methods (plus overloads) that support three log levels:

* **Message()**
* **Info()**
* **Error()**

All accept a message string, which may be a format string. If you want to provide args for the format string, put them in an 
object array (param arrays are not supported by these methods).

**Error()** will also take just an **Exception**, or an **Exception** and a message. The exception's stack trace will be written to 
the log in full.

Each method also accepts arguments decorated with [Caller Member Attributes](http://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.callermembernameattribute.aspx)
These arguments will be set by the compiler, you do not need to set them explicitly.

Output
------

The log messages are formatted and written to the **System.Diagnostics.Trace.WriteLine()** method. You may configure where and 
how Trace information is logged by configuring **[TraceListener](http://msdn.microsoft.com/en-us/library/vstudio/system.diagnostics.tracelistener)**'s. Otherwise the default TraceListener will be used. This usually 
means you will see the log output in your Output window in Visual Studio, or in your Test runner output and/or logs.