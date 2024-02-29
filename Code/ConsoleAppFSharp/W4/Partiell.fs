module Partiell

let mul a b : float = 
  a * b

let verdopple = 
  mul 2.0


let erstelleGruss name = 
  sprintf "Hallo %s!" name

let gruessLuca = 
  erstelleGruss "Luca"


let berechneDifferenz a b = 
  a - b

let subtrahiereVon10 = 
  berechneDifferenz 10


let erstelleEmail domain username = 
  sprintf "%s@%s" username domain

let erstelleFirmenEmail = 
  erstelleEmail "firma.com"


let berechneZinsen jahre kapital zinssatz = 
  kapital * zinssatz * jahre / 100.0

let berechneTageszinsen = 
  let j = 1.0 / 360.0 // 1 Tag als Jahr
  berechneZinsen j

let berechneMonatszinsen = 
  let j = 1.0 / 12.0 // 1 Monat als Jahr
  berechneZinsen j

let berechneJahreszinsen =
  berechneZinsen 1.0