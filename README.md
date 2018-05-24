# Installation

The library is available via [NuGet](https://www.nuget.org/packages?q=LightBus.Core) packages:

## Package Manager

```powershell
Install-Package LightBus.Core
Install-Package LightBus.Microsoft.DependencyInjection
```

## .NET CLI

```powershell
dotnet add package LightBus.Core
dotnet add package LightBus.Microsoft.DependencyInjection
```

## Getting Starter

### Asp.Net Core

If you are using Asp.Net core, just install [LightBus.Microsoft.DependencyInjection](https://www.nuget.org/packages/LightBus.Microsoft.DependencyInjection/)
, this package enables you to automatically register the message handler,
just using the sintax below.

```Csharp
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.UseLightBus();
    ...
}
```

## Creating Message and Handlers

### Message

To create a message is very simple, you just need a class and implement ```IMessage``` Interface like below

```CSharp
public class SampleMessage : IMessage
{
        public string Value { get; set; }
}
```

### MessageHandler

Like a Message, you just need a class and implement: ```IMessageHandler<TMessage> where TMessage: IMessage``` Interface like below

```CSharp
public class SampleMessageHandler : IMessageHandler<SampleMessage>
{
    public Task HandleAsync(SampleMessage message)
    {
        Debug.WriteLine(message.Value);
        return Task.CompletedTask;
    }
}
```

### Sending Message

to trigger a message you will need to inject the ```ILightBus``` Interface and use ```SendAsync<TMessage>(TMessage)``` to dispatch a message like below

```CSharp
[Route("")]
public class ValuesController : Controller
{
    private readonly ILightBus _lightBus;

    public ValuesController(ILightBus lightBus)
    {
        _lightBus = lightBus;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        await _lightBus.SendAsync(
            new SampleMessage { Value = "Hello LightBus" });

        return "Ok";
    }
}
```