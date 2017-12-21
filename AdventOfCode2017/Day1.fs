module Day1

open System
open System.IO

let input = File.ReadAllText(sprintf "%s\data\day1.txt" __SOURCE_DIRECTORY__)

let digits = 
    input.ToCharArray() 
    |> Array.map (Char.GetNumericValue >> int) 
    |> Array.rev

let result = 
    let (_, sum) = digits |> Array.fold (fun (prev, sum) item -> (item, if prev=item then sum + item else sum)) (digits |> Array.last, 0)
    sum
    