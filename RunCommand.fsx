open System

let runCommand command args =
    let startInfo = Diagnostics.ProcessStartInfo()
    startInfo.FileName <- command
    startInfo.Arguments <- args
    startInfo.RedirectStandardOutput <- true
    startInfo.RedirectStandardError <- true
    startInfo.UseShellExecute <- false
    startInfo.CreateNoWindow <- true

    use proc = new Diagnostics.Process()
    proc.StartInfo <- startInfo
    proc.Start() |> ignore

    let output = proc.StandardOutput.ReadToEnd()
    let error = proc.StandardError.ReadToEnd()
    proc.WaitForExit()
    
    if proc.ExitCode <> 0 then
        failwithf $"Command failed with exit code %d{proc.ExitCode}\nError: %s{error}"
    output
