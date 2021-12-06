let lines = System.IO.File.ReadAllLines("src/Day02.txt")

type Move =
    | Forward of int
    | Up of int
    | Down of int

let parseMove (s:string) =
    let split = s.Split([|' '|], 2) |> List.ofArray
    match split with
    | ["forward"; amount] -> Forward (int amount)
    | ["down"; amount] -> Down (int amount)
    | ["up"; amount] -> Up (int amount)
    | _ -> failwith "Invalid direction"

let moves = lines |> Array.map parseMove


let folder1 (horizontal, depth) move = 
    match move with
    | Forward amount -> (horizontal + amount, depth)
    | Up amount -> (horizontal, depth - amount)
    | Down amount -> (horizontal, depth + amount)

let horizontal, depth = Array.fold folder1 (0,0) moves 

let partOne = horizontal * depth

let folder2 (horizontal, depth, aim) move = 
    match move with
    | Forward amount -> (horizontal + amount, depth + (aim*amount), aim)
    | Up amount -> (horizontal, depth, aim - amount)
    | Down amount -> (horizontal, depth, aim + amount)

let horizontal2, depth2, _ = Array.fold folder2 (0,0,0) moves 

let partTwo = horizontal2 * depth2