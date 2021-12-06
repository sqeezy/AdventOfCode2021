open System.IO

let lines = File.ReadAllLines("src/Day01.txt")
let depths = lines 
                |> Array.map (fun s -> int s)

let partOne = depths 
                |> Array.windowed 2
                |> Array.map (fun t -> (t[1] - t[0]) > 0)
                |> Array.filter (fun b -> b)
                |> Array.length

let partTwo = depths 
                |> Array.windowed 3
                |> Array.map Array.sum
                |> Array.windowed 2
                |> Array.map (fun t -> (t[1] - t[0]) > 0)
                |> Array.filter (fun b -> b)
                |> Array.length