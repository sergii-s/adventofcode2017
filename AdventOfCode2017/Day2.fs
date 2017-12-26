module Day2

open System
open System.IO

let input = File.ReadAllLines(sprintf "%s\data\day2.txt" __SOURCE_DIRECTORY__)

let getDiffMinMax (line : int array) = 
    let (min, max) = line |> Array.fold (fun (min, max) item -> (Math.Min(min, item), Math.Max(max, item))) (line.[0], line.[0])
    max - min

let getDividable (line : int seq) = 
    let line = line |> Seq.sort
    let dividableBy x1 x2 = x2 % x1 = 0
    line 
    |> Seq.mapi (fun i x1 -> line |> Seq.skip (i+1) |> Seq.tryFind (dividableBy x1) |> Option.map (fun x2 -> x2/x1)) 
    |> Seq.find Option.isSome 
    |> Option.get

let part1 = 
    input 
    |> Array.map(fun line -> line.Split('\t') |> Array.map Int32.Parse)
    |> Array.map getDiffMinMax 
    |> Array.sum

let part2 = 
    input 
    |> Array.map(fun line -> line.Split('\t') |> Array.map Int32.Parse)
    |> Array.map getDividable
    |> Array.sum