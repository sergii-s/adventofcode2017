module Day3

type Level = {
    level : int
    side : int
    min : int
    max : int
}

let levelInfo = Seq.initInfinite (fun i -> 1 + 2 * i)  |> Seq.mapi (fun i x -> {level=i; side=x; min=(x-2)*(x-2) + 1; max=x*x})
let getLevelInfo n = levelInfo |> Seq.find (fun lvl -> lvl.max >= n)
let getCoordinates n =
    let lvl = getLevelInfo n
    let c1, c2, c3, c4 = lvl.min, lvl.min+lvl.side - 1, lvl.min+(lvl.side-1)*2 , lvl.min+(lvl.side-1)*3 
    match n with 
    | n when n >= c1 && n < c2 -> (lvl.level, lvl.level - 1 - (n - lvl.min))
    | n when n >= c2 && n < c3 -> (lvl.level - 1 - (n - c2), -lvl.level)
    | n when n >= c3 && n < c4 -> (-lvl.level, -lvl.level + 1 + (n - c3))
    | n when n >= c4 -> (-lvl.level+ 1 + (n - c4), lvl.level)
    | _ -> (0,0)
let getPositon (x:int, y:int) =
    let lvlIdx = max (abs x) (abs y) 
    let lvl = levelInfo |> Seq.item lvlIdx
    let inc =
        match (x, y) with 
        | (x, y) when y = lvl.level -> (lvl.side - 1)*3 + (x + lvl.side/2)
        | (x, y) when x = lvl.level -> lvl.side/2 - y
        | (x, y) when y = -lvl.level -> lvl.side - 1 + (lvl.side/2 - x)
        | (x, y) when x = -lvl.level -> (lvl.side - 1)*2 + (y + lvl.side/2)
        | _ -> 0
    lvl.min - 1 + inc

let getDistance (x:int, y:int) =
    abs x + abs y
 
let part1 = getCoordinates 277678 |> getDistance

let sumNeighbors (calculated : System.Collections.Generic.List<int>) n = 
    if n = 1 then 
        1
    else
        let (x,y) = n |> getCoordinates
        [(x+1, y); (x-1, y); (x, y+1); (x, y-1);(x+1, y+1);(x+1, y-1);(x-1, y+1);(x-1, y-1)] 
        |> Seq.map getPositon 
        |> Seq.filter (fun p -> p < n) 
        |> Seq.sumBy (fun p -> calculated.Item(p-1))
    
let part2Numbers = 
    let calculated = System.Collections.Generic.List<int>()
    let calcNext i = 
        let sum = (i + 1) |> sumNeighbors calculated
        calculated.Add(sum)
        sum
    Seq.initInfinite calcNext
    
let part2 = part2Numbers |> Seq.find (fun x-> x> 277678)