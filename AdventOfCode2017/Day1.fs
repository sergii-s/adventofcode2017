module Day1

open System
open System.IO

let input = File.ReadAllText(sprintf "%s\data\day1.txt" __SOURCE_DIRECTORY__)

let result = 
    let getSum step (arr:int array) =
        arr |> Array.mapi(fun i x -> (x, arr.[(i+step)%arr.Length])) |> Array.sumBy (fun (one, two) -> if one = two then one else 0)
        
    let digits = 
        input.ToCharArray() 
        |> Array.map (Char.GetNumericValue >> int) 
    
    let step1 = digits |> getSum 1
    let step2 = digits |> getSum (digits.Length/2)
    (step1, step2)
    