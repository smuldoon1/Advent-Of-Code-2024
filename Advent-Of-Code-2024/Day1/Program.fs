open System.IO

let readAllText filePath =
    File.ReadAllText(filePath)

// Usage
let filePath = "Day1.txt"
let content = readAllText filePath
printfn "%s" content