using Microsoft.Build.Framework;
using System;

namespace ExaPhaser.SharpJS.Build.Tasks
{
    /// <summary>
    /// Defines a MSBuild task to compile an assembly with JSIL to HTML5/JS
    /// </summary>
    public class JsilCompileAssemblyTask : Microsoft.Build.Utilities.Task
    {
        //The output path of the JSIL compilation
        [Required]
        public string OutputPath { get; set; }

        /// <summary>
        /// The assembly to be compiled
        /// </summary>
        [Required]
        public string InputAssemblyPath { get; set; }

        public override bool Execute()
        {
            Log.LogCommandLine($"Running JSIL Compile on assembly {InputAssemblyPath}...");
            Log.LogCommandLine($"Output Path: {OutputPath}");
            //Hijack stdout and stderr for JSIL execution
            var originalStdout = Console.Out;
            var originalStderr = Console.Error;
            //Console.SetOut(new ConsoleToMSBuildLogger(Log, TaskLoggerType.Log));
            //Console.SetError(new ConsoleToMSBuildLogger(Log, TaskLoggerType.Error));
            var jsilRunArgs = new[] { $"-o={OutputPath}", $"{InputAssemblyPath}" };
            Log.LogCommandLine($"JSILc parameters: {string.Join(" ", jsilRunArgs)}");
            JSIL.Compiler.Program.Main(jsilRunArgs);
            Log.LogCommandLine($"JSILc exit code: {Environment.ExitCode}");
            Console.SetOut(originalStdout);
            Console.SetError(originalStderr);
            //TODO actually check JSILc's status afterward?
            return true; //If it got this far, it should have succeeded?
        }
    }
}