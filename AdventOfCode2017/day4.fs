module Day4

open System
open System.IO

let input = File.ReadAllLines(sprintf "%s\data\day4.txt" __SOURCE_DIRECTORY__)

let part1 = 
    let isValidPassPhrase words = 
        let distinctWords = words |> Array.distinct
        words.Length = distinctWords.Length
    input 
    |> Seq.map(fun line -> line.Split([|" "|],StringSplitOptions.RemoveEmptyEntries))
    |> Seq.filter isValidPassPhrase
    |> Seq.length
        
let part2 = 
    let isValidPassPhrase words = 
        let distinctWords = words |> Array.map(fun (word:string) -> word.ToCharArray() |> Array.sort |> String) |> Array.distinct
        words.Length = distinctWords.Length
    input 
    |> Seq.map(fun line -> line.Split([|" "|],StringSplitOptions.RemoveEmptyEntries))
    |> Seq.filter isValidPassPhrase
    |> Seq.length

