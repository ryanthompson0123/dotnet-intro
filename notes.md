## Visual Studio Code IDE

- Folder based, but can also create workspaces
- Handy built in terminal
- Huge extension library
- Awesome debugger
- Git integration

## .NET core console apps,

```sh
dotnet new console --output Demo.ConsoleApp
```

## NuGet package manager

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

Standing on the shoulders of giants. Prebuilt docker containers make it easy.

docker build -t codecamp-reactapp .
docker run -it --rm -p 5000:80 --name codecamp-demo codecamp-reactapp

## New features in C# 7 and 8
