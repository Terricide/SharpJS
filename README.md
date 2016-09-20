<img src="sharpjs.png" alt="SharpJS Logo" width="48" height="48" /> SharpJS
====

A set of frameworks for writing HTML5/JavaScript applications with C#.

[![Build Status](https://travis-ci.org/exaphaser/SharpJS.svg?branch=master)](https://travis-ci.org/exaphaser/SharpJS)

## **[Quick Start](https://exaphaser.github.io/SharpJS/#quickstart)** (recommended)

## About

SharpJS is open-source software licensed under the **Apache License 2.0**, which can be found in the [LICENSE.md](LICENSE.md) file.

The runtime is powered by JSIL, an application that translates compiled IL to JavaScript. The SharpJS frameworks are built on top of JSIL and provide classes for building web applications that run in the browser.

Since SharpJS compiles your applications directly to HTML5 and JavaScript, they can run offline in the browser, online served by a server, in a mobile app built with PhoneGap, in a desktop app built with Electron, or in any other technology that allows you to build applications with web technologies.

## Getting Started
- [Download the template extension](https://exaphaser.github.io/SharpJS/#see-license) (Highly recommended for a super-quick start)
- [Documentation](https://exaphaser.github.io/SharpJS/#documentation)
- **[Quick Start](https://exaphaser.github.io/SharpJS/#quickstart)** (recommended)
- The **[wiki of this project](https://github.com/exaphaser/SharpJS/wiki)** will contain information about this project, and on extending the project with your own APIs, and build instructions.

## How it works
- You write your C# source in any IDE, such Visual Studio
- Your source links to the `ExaPhaser.WebForms` and `SharpJS.Dom` libraries
- An MSBuild post-build event runs the JSIL compiler to translate your source into JS
- At runtime, the `ExaPhaser.WebForms` library constructs a layout based on your source and renders it using `SharpJS.Dom`, which bridges the translated C# source to native JavaScript DOM manipulation code. `ExaPhaser.WebForms` provides a simple, managed abstraction layer over `SharpJS.Dom`, which directly manipulates the DOM of the webpage.
- C# Bindings for a number of common libraries such as jQuery are included, allowing you to invoke jQuery methods directly from C#. They are later translated into native JavaScript calls at runtime.

## New/Coming Soon
- New: A beautiful, modern new loading UI!
- Coming soon: NeptuniumKit: A completely new, sleek UI with Material Design. Powered by [FezVrasta's awesome Bootstrap Material Design](https://fezvrasta.github.io/bootstrap-material-design/) library!

## Currently supported APIs and Frameworks:
- **IridiumIon.NeptuniumKit** - (**In Progress/Coming Soon**) A XAML-inspired UI framework based on Material Design. It will be a complete reimplementation of ExaPhaser.WebForms with a focus on extensibility, features, and modern UI.
- **ExaPhaser.WebForms** - A GUI framework for creating HTML5 applications styled with modern CSS frameworks.
- **ExaPhaser.WebForms.Extensions.WinFormsCompat** - (**Alpha!**) A new compatibility layer that can run Windows Forms designer-generated code by proxying calls to `ExaPhaser.WebForms`. Yes, it can actually [run recompiled WinForms apps in your browser](https://github.com/exaphaser/SharpJS/wiki/Running-Windows-Forms-in-browser-with-WinFormsCompat)!
- **SharpJS.Dom** - A set of extensions that provide JavaScript and jQuery bindings to C# for manipulating DOM from the .NET runtime.

## Acknowledgements

## Open Source

ExaPhaser.SharpJS depends upon or is based on the following open source projects:

 * JSIL.Hacks MIT/X11 (Markus Johnson)
 * JSIL: MIT/X11 (K. Gadd) - SharpJS would absolutely not be possible without this project!
 * Mono.Cecil: MIT/X11 (thanks to Jb Evain)
 * ICSharpCode.Decompiler: MIT/X11 (developed as part of ILSpy)
 * Mono.Options: MIT/X11 (Jonathan Pryor & Federico Di Gregorio)
 * printStackTrace: Public Domain (Eric Wendelin and others)
 * webgl-2d: MIT (Corban Brook, Bobby Richter, Charles J. Cliffe, and others)
 * S3TC DXT1 / DXT5 Texture Decompression Routines (Benjamin Dobell)

## Tools

![ReSharper logo](img/icon_ReSharper.png) SharpJS is developed with the help of ReSharper.
