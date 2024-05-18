module MapColoring

type Country = string
type Map = (Country * Country) list // zwei Länder, die aneinander grenzen -> Liste

type Color = Country list // Liste von Ländern, die die gleiche Farbe haben
type Coloring = Color list

let rec isMember list element =
  match list with
  | [] -> false
  | x::tail -> x = element || isMember tail element

let areNeighbours map country1 country2 = 
  isMember map (country1, country2) || isMember map (country2, country1)

let rec canExtendColorGroup map colorGroup country = 
  match colorGroup with
  | [] -> true
  | c :: tail -> 
    not(areNeighbours map c country) && canExtendColorGroup map tail country

let addUniqueElement element list = 
  if isMember list element then
    list
  else
    element :: list

let rec extendColoring map coloring country = 
  match coloring with
  | [] -> [[country]]
  | colorGroup :: tail -> 
    if canExtendColorGroup map colorGroup country then
      (addUniqueElement country colorGroup) :: tail
    else
      colorGroup :: extendColoring map tail country


//let extractCountries map = 
//  map |> List.collect (fun (c1, c2) -> [c1; c2]) |> List.distinct
//  // collect: SelectMany in C#
let rec extractCountries map = 
  match map with
  | [] -> []
  | (country1, country2) :: tail ->
    let rest = extractCountries tail
    addUniqueElement country1 (addUniqueElement country2 rest)

let rec colorCountries countryList map = 
  match countryList with
  | [] -> []
  | country :: tail ->
    extendColoring map (colorCountries tail map) country

let colorMap map = 
  let countries = extractCountries map
  colorCountries countries map