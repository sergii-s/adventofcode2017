module Day2

open System
open System.IO

let input = File.ReadAllLines(sprintf "%s\data\day2.txt" __SOURCE_DIRECTORY__)

let getDiffMinMax (line : int array) = 
    let (min, max) = line |> Array.fold (fun (min, max) item -> (Math.Min(min, item), Math.Max(max, item))) (line.[0], line.[0])
    max - min

let result = 
    input 
    |> Array.map(fun line -> line.Split('\t') |> Array.map Int32.Parse)
    |> Array.map getDiffMinMax 
    |> Array.sum