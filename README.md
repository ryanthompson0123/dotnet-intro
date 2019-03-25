# Intro to .NET Core

### Boise Code Camp 2019

## Ecosystem Overview

### About .NET Core

- Cross-platform
- Consistent across architectures
- Command-line tools
- Flexible deployment (Docker!!)
- Compatible
- Open source
- Supported by Microsoft
- Free!(as in beer)

### Roslyn Complier

- C#, F#, Visual Basic
- Public API => Powerful Tooling

### Kestrel Web Server

- 2x faster than nginx, 3x Java’s servlet, 4x IIS, 8x node.js cluster [(source)](https://www.techempower.com/benchmarks/#section=test&runid=8ca46892-e46c-4088-9443-05722ad6f7fb&hw=ph&test=plaintext)
- Flexible middleware architecture

### Visual Studio Code IDE

- Folder based, but can also create workspaces
- Handy built in terminal
- Huge extension library
- Awesome debugger
- Git integration

### Common NuGet packages

| Function                             | Package                                                                                                                            |
| ------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------- |
| JSON serialization / deserialization | [Json.NET](https://www.newtonsoft.com/json)                                                                                        |
| Unit Testing                         | [NUnit](https://github.com/nunit/nunit)                                                                                            |
| Logging                              | [Serilog](https://github.com/serilog/serilog), [log4net](http://logging.apache.org/log4net/), [NLog](https://github.com/NLog/NLog) |
| HTTP Client                          | System.Net.Http, [RestSharp](https://github.com/restsharp/RestSharp)                                                               |
| Mocking Framework                    | [Moq](https://github.com/moq/moq4)                                                                                                 |
| IoC Container                        | [Autofac](https://github.com/autofac/Autofac)                                                                                      |
| Swagger API                          | [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)                                                |
| Fault tolerance                      | [Polly](https://github.com/App-vNext/Polly)                                                                                        |
| Fakes                                | [Bogus](https://github.com/bchavez/Bogus)                                                                                          |
| Date/Time Handling                   | [NodaTime](https://nodatime.org)                                                                                                   |
| Text Formatting / Localization       | [Humanizer](https://github.com/Humanizr/Humanizer)                                                                                 |
| Crypto                               | System.Security.Cryptography, [PCLCrypto](https://github.com/aarnott/pclcrypto/)                                                   |

## Stuff you should know about C

#### Value Types vs. Reference Types

```C#
int number = null;        // Compiler error
Product myProduct = null; // No problem
```

#### Accessors are a language construct

```C#
public class Product
{
	public string Name { get; set; }
	public string Category { get; set; } = "General";
}
```

#### Functions are first-class citizens

```C#
Func<int, int> addOne = (n) => n + 1;
```

#### LINQ is your ticket to fluent / functional programming

```C#
List<int> evenSquares = Enumerable.Range(0, 10)
	.Where(i => i % 2 == 0)
	.Select(i => i * i)
	.ToList();
```

#### Type inference is awesome

```C#
var dontCareCauseIHaveAnIde = GetProducts()
	.Where(p => p.Category == "Modern")
	.Select(p => p.Name);
```

#### We have a real generic system

```C#
List<string> strings = new List<string>();
List<int> ints = new List<int>();

// This evaulates to false at runtime, as it should.
// It would evaluate to true in Java.
bool result = strings.GetType() == ints.GetType();
```

## .NET core console apps,

```sh
dotnet new console --output Demo.ConsoleApp
```

## Introduction to ASP.NET Core

### Razor Pages

```sh
dotnet new webapp -o Demo.RazorApp
```

PageModel classes define page handlers for requests sent to the page and the data used to render the page. This separation allows you to manage page dependencies through dependency injection and to unit test the pages.

Tag Helpers are cool little widgets that automagically take care of plumbing code you would normally have to write. In Index.cshtml there's an Anchor tag helper that sends the id of the Customer you clicked to the Edit page. The tag at the top of the edit page automagically validates the input.

### SPA WebApps

```sh
dotnet new reactredux -o Demo.ReactApp
```

Startup.cs is like your application control panel. In some ways like web.config used to be.

ASP.NET core treats dependency injection as a first class citizen. Pretty cool for testing / maintainability.

## Deploy apps with Docker

Docker images let you stand on the shoulders of giants and make Docker deployment easy. See the Dockerfile in CodeCamp.ReactApp for an example. Note that we setup a special container to build the app, but use a more lightweight container for the actual deployment.

```sh
docker build -t codecamp-reactapp .
docker run -it --rm -p 5000:80 --name codecamp-demo codecamp-reactapp
```

## New features in C# 7 and 8

[C# 7 New Features](https://devblogs.microsoft.com/dotnet/new-features-in-c-7-0/)

[C# 8 New Features](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8)

#### Safe type casting with the 'is' operator

Old way

```C#
public static void HandleAircraft(Vehicle anObject)
{
	var aircraft = anObject as Aircraft;
	if (aircraft != null)
	{
		Console.WriteLine(aircraft.EngineCount);
	}
}
```

New way

```C#
public static void HandleAircraft(Vehicle anObject)
{
	if (anObject is Aircraft aircraft)
	{
		Console.WriteLine(aircraft.EngineCount);
	}
}
```

Old inverse

```C#
public static void HandleOnlyAircraft(Vehicle anObject)
{
	var aircraft = anObject as Aircraft;
	if (aircraft == null) return;
	Console.WriteLine(aircraft.EngineCount);
}
```

New inverse

```C#
public static void HandleOnlyAircraft(Vehicle anObject)
{
	if (!(anObject is Aircraft aircraft)) return;
	Console.WriteLine(aircraft.EngineType);
}
```

#### Pattern matching

old way

```C#
public static Certification GetRequiredCertification(Vehicle vehicle)
{
	var aircraft = vehicle as Aircraft;
	if (aircraft != null) {
		if (aircraft.EngineType == AircraftEngineType.Turbojet &&
				aircraft.EngineCount == 4) {
			return Certification.JumboJets;
		}
		return Certification.GeneralAircraft;
	}
	var watercraft = vehicle as Watercraft;
	if (watercraft != null) {
		return watercraft.Tonnage > 10000 ?
			Certification.Ships : Certification.Boats;
	}
	etc.......
```

new way

```C#

public static Certification GetRequiredCertification(Vehicle vehicle)
{
	switch (vehicle) {
		case Aircraft a when a.EngineType == AircraftEngineType.Turbojet && a.EngineCount == 4:
			return Certification.JumboJets;
		case Aircraft a:
			return Certification.GeneralAircraft;
		case Watercraft w when w.Tonnage > 10000:
			return Certification.Ships;
		case Watercraft w:
			return Certification.Boats;
		case GroundVehicle g when g.WheelCount > 6 || g.GrossVehicleWeightRating > 10000:
			return Certification.OversizeVehicles;
		default:
			return Certification.None;
	}
}

```

#### Expression bodies

property accessors

```C#
private string _name;
public string Name
{
	get => _name;
	set => SetProperty(ref _name, value);
}
```

methods

```C#
public bool IsSquare(Rectangle rect) => rect.Height == rect.Width;
```

constructors

```C#
public Vehicle(string name) => Name = name;
```

switch statements

```C#
public static int CertificationCostNew(Certification certification) =>
	certification switch
	{
		Certification.JumboJets 		=> 100000,
		Certification.GeneralAircraft 	    	=> 25000,
		Certification.Ships 			=> 20000,
		Certification.Boats 			=> 5000,
		Certification.OversizeVehicles 	    	=> 5000,
		Certification.None 			=> 0,
		_ => throw new ArgumentException(message: "invalid enum value")
	};
```

#### Tuples

```C#
public List<(string Category, decimal Price)> AvgPriceByCategory3(List<Product> products)
```

```C#
foreach (var pair in prices)
{
	Console.WriteLine($"Category: {pair.Category}, Price: {pair.Price}");
}
```

deconstruction

```C#
foreach (var pair in prices)
{
	(string Category, decimal Price) = pair;
	Console.WriteLine($"Category: {Category}, Price: {Price}");
}
```

discards

```C#
foreach (var pair in prices)
{
	(string Category, _) = pair;
	Console.WriteLine($"Category: {Category}");
}
```

pattern match

```C#
public string RockPaperScissors(string first, string second)
	=> (first, second) switch
	{
		("rock", "paper") => "rock is covered by paper. Paper wins.",
		("rock", "scissors") => "rock breaks scissors. Rock wins.",
		("paper", "rock") => "paper covers rock. Paper wins.",
		("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
		("scissors", "rock") => "scissors is broken by rock. Rock wins.",
		("scissors", "paper") => "scissors cuts paper. Scissors wins.",
		(_, _) => "tie"
	};
```
