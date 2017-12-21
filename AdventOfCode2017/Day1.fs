module Day1

open System
open System.IO

let input = File.ReadAllText(sprintf "%s\data\day1.txt" __SOURCE_DIRECTORY__)

let digits = input.ToCharArray() |> Array.map (Char.GetNumericValue >> int)
let result = 
    digits 
    |> Array.mapi (fun i x -> (x, digits.[(i+1)%digits.Length]))
    |> Array.filter (fun (x1, x2) -> x1 = x2)
    |> Array.sumBy (fun (x1, _) -> x1)
    