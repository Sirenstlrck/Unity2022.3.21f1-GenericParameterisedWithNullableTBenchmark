#!/usr/bin/env dotnet fsi

#load "RunCommand.fsx"

open System.IO
open RunCommand

let commonLibName = "GenericParameterisedWithNullableTBenchmark.Common"  
let configuration = "Release"
let commonLibDir = $"./%s{commonLibName}/"  
let buildDir = $"%s{commonLibDir}/bin/%s{configuration}/fsx_artifacts/"

let unityPluginsDir = "./UnityProject/Assets/Plugins/"

Directory.CreateDirectory(buildDir) |> ignore

printfn $"Building project %s{commonLibDir}..."
runCommand "dotnet" $"build \"%s{commonLibDir}\" -c \"%s{configuration}\" -o \"%s{buildDir}\"" |> printfn "%s"

let sourceDllPath = $"%s{buildDir}%s{commonLibName}.dll"
let targetDllPath = Path.Combine(unityPluginsDir, Path.GetFileName(sourceDllPath))
printfn $"Copying %s{sourceDllPath} to %s{targetDllPath}..."
File.Copy(sourceDllPath, targetDllPath, overwrite = true)