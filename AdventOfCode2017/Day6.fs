module Day6

open System
open System.IO

let input = File.ReadAllText(sprintf "%s\data\day6.txt" __SOURCE_DIRECTORY__)

let data = input.Split([|' '; '\t'|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Int32.Parse

let roundDistance x y max = 
    match y - x with
    | d when d < 0 -> d + max
    | d -> d

let iteration (data : int []) = 
    let (idx, max) = data |> Array.indexed |> Array.maxBy (fun (_, value) -> value)
    let sup = max / data.Length
    let sup1 = max % data.Length
    data |> Array.mapi(fun i v -> 
        match i with 
        | i when i = idx -> sup
        | i when roundDistance idx i data.Length <= sup1 -> v + sup + 1
        | _ -> v + sup
    )

let findRepeatedState initialState =
    let rec nextState states cnt =
        let next = states |> List.head |> iteration
        match states |> List.tryFindIndex (fun state -> state = next) with
        | Some i -> cnt, i + 1
        | None -> nextState (next :: states) (cnt + 1)
    nextState [initialState] 1
    
let res = data |> findRepeatedState