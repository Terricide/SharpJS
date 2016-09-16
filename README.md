# SharpJS
A set of frameworks for writing HTML5/JavaScript applications with C#.

# About SharpJS

SharpJS is open-source software licensed under the GPLv3, which can be found in the [LICENSE.md](LICENSE.md) file.
If you feel restricted by the license, please purchase a commercial license from [the marketplace]( http://exaphaser.binpress.com/product/sharpjs/3760#pricing). (You could do this if you wanted to use the software, for example, for some kind of proprietary use. The pricing is very affordable and there are multiple tiers.)

The runtime is powered by JSIL, an application that translates compiled IL to JavaScript. The SharpJS frameworks are built on top of JSIL and provide classes for building web applications that run in the browser.

Since SharpJS compiles your applications directly to HTML5 and JavaScript, they can run offline in the browser, online served by a server, in a mobile app built with PhoneGap, in a desktop app built with Electron, or in any other technology that allows you to build applications with web technologies.

# Getting Started
- [Samples and code demos for getting started with SharpJS](https://github.com/ZetaPhase/SharpJS-Demos).
- The **[wiki of this project](https://github.com/exaphaser/SharpJS/wiki)** will contain information about this project, and on extending the project with your own APIs, and build instructions.

# How it works
- You write your C# source in any IDE, such Visual Studio
- Your source links to the `ExaPhaser.WebForms` and `SharpJS.Dom` libraries
- An MSBuild post-build event runs the JSIL compiler to translate your source into JS
- At runtime, the `ExaPhaser.WebForms` library constructs a layout based on your source and renders it using `SharpJS.Dom`, which bridges the translated C# source to native JavaScript DOM manipulation code. `ExaPhaser.WebForms` provides a simple, managed abstraction layer over `SharpJS.Dom`, which directly manipulates the DOM of the webpage.
- C# Bindings for a number of common libraries such as jQuery are included, allowing you to invoke jQuery methods directly from C#. They are later translated into native JavaScript calls at runtime.


# Currently supported APIs and Frameworks:
- **ExaPhaser.WebForms** - A GUI framework for creating HTML5 applications styled with modern CSS frameworks.
- **ExaPhaser.WebForms.Extensions.WinFormsCompat** - A new compatibility layer that can run Windows Forms designer-generated code by proxying calls to `ExaPhaser.WebForms`.
- **SharpJS.Dom** - A set of extensions that provide JavaScript and jQuery bindings to C# for manipulating DOM from the .NET runtime.

Open-Source project Acknowledgements

ExaPhaser.SharpJS depends upon or is based on the following open source projects:

 * JSIL.Hacks MIT/X11 (Markus Johnson)
 * JSIL: MIT/X11 (K. Gadd) - SharpJS would absolutely not be possible without this project!
 * Mono.Cecil: MIT/X11 (thanks to Jb Evain)
 * ICSharpCode.Decompiler: MIT/X11 (developed as part of ILSpy)
 * Mono.Options: MIT/X11 (Jonathan Pryor & Federico Di Gregorio)
 * printStackTrace: Public Domain (Eric Wendelin and others)
 * XAPParse: Microsoft Public License/Ms-PL (Andy Patrick)
 * webgl-2d: MIT (Corban Brook, Bobby Richter, Charles J. Cliffe, and others)
 * S3TC DXT1 / DXT5 Texture Decompression Routines (Benjamin Dobell)
