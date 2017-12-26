module Day5

open System
open System.IO

let input = File.ReadAllLines(sprintf "%s\data\day5.txt" __SOURCE_DIRECTORY__)

let modifyP1 offset = 
    offset + 1

let modifyP2 offset =
    if offset >= 3 then
        offset - 1
    else
        offset + 1

let getStepsCount modify (data:int array) =
    let rec getResult idx cnt =
        let offset = data.[idx] 
        data.[idx] <- modify offset
        match idx + offset with
        | n when n >= data.Length || n < 0 -> cnt + 1
        | n -> getResult n (cnt + 1)
    getResult 0 0
    
let part1 = 
    input 
    |> Array.map Int32.Parse 
    |> getStepsCount modifyP1

let part2 = 
    input 
    |> Array.map Int32.Parse 
    |> getStepsCount modifyP2