# FNA-VSCode-Template

Template and build tasks for developing a cross-platform multi-target .NET Framework, Mono, and .NET 6 FNA project in VSCode.

The generated solution file will also work in regular Visual Studio.

## Features

- Includes project boilerplate code
- Build tasks for both .NET Framework, Mono, and .NET 6 side by side
- VSCode debugger integration

## Requirements

- [Git](https://git-scm.com/) or [Git for Windows](https://gitforwindows.org/) on Windows
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [.NET Framework 4.6.1 Developer Pack](https://dotnet.microsoft.com/download/dotnet-framework/net461) on Windows
- [Build Tools for Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) on Windows
- [Mono](https://www.mono-project.com/) on OSX or Linux
- [Visual Studio Code](https://code.visualstudio.com/)
- [VSCode C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
- [VSCode Mono Debug Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.mono-debug) if debugging using Mono

## Installation

- Make sure you have Git Bash from Git for Windows if you are on Windows
- Download this repository
- Run `install.sh`
- Move the newly created project directory wherever you want
- On Windows, add `C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin` to your system environment PATH variable after installing Build Tools for VS 2019

## Usage

- Open the project directory in VSCode
- Press Ctrl-Shift-B to open the build tasks menu
- `Framework` tasks use .NET Framework to build and run (Windows only)
- `Mono` tasks use Mono to build and run
- `.NET 6` tasks use .NET 6 to build and run
- Press F5 to build and debug

## Acknowledgments

Thanks to Andrew Russell and Caleb Cornett's FNA templates for a starting point for this template.
