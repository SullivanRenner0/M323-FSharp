module Records

type Adress = {Street: string; City: string; Zip: string}

type Person = {Name: string; Age: int; Adress: Adress}

type Student = {Name: string; MatNr: string; Grades: float*float*float*float*float}

let createPersonWithAdress (name: string) (age: int) (adress: Adress) = 
    {Name = name; Age = age; Adress = adress}

let printPersonWithAdress (person: Person) = 
    printfn "Name: %s" person.Name
    printfn "Age: %d" person.Age
    printfn "Street: %s" person.Adress.Street
    printfn "City: %s" person.Adress.City
    printfn "Zip: %s" person.Adress.Zip

let getGradesArray (student: Student) = 
    let g1, g2, g3, g4, g5 = student.Grades
    [|g1; g2; g3; g4; g5|]

let calcAvgGrade (student: Student) = 
    getGradesArray student
      |> Array.average

let calcMedianGrade (student: Student) = 
    let sortedGrades = getGradesArray student |> Array.sort

    let len = Array.length sortedGrades
    if len % 2 = 0 then
        (sortedGrades.[len/2] + sortedGrades.[len/2-1]) / 2.0
    else
        sortedGrades.[len/2]

let checkIfPassed (student: Student) = 
    let avgGrade = calcAvgGrade student

    if avgGrade < 4.0 then
        false
    else
    getGradesArray student 
      |> Array.filter (fun x -> x < 4.0)
      |> Array.sumBy (fun x -> 4.0 - x)
      |> fun x -> x <= 1.0