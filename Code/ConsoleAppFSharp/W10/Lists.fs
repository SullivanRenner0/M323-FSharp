module ListsW10

open System.Text.RegularExpressions;

let validateEmailTwo (email: string) = 
  Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9]{2}\.[a-zA-Z0-9]{2}@[a-zA-Z0-9]{2}\.(com|ch)$")

let validateEmail (email: string) = 
  Regex.IsMatch(email.Trim(), @"^[a-zA-Z0-9]+\.[a-zA-Z0-9]+@[a-zA-Z0-9]+\.(com|ch)$")

let filterValidEmails (emails: string list) = 
  List.filter validateEmail emails


let validPhone (phone: string) = 
  Regex.IsMatch(phone.Trim(), @"^\+\d{2} \d{2} \d{3} \d{2} \d{2}$")


let filterForInvalidPhoneTuple (list: (string*string*string) list) =
  let isInvalid (contact: string*string*string) = 
    let (_, _, phone) = contact
    validPhone phone |> not

  List.filter isInvalid list


type Contact = { Name: string; Email: string; Phone: string; }

let filterForInvalidPhone (list: Contact list) =
  List.filter (fun contact -> validPhone contact.Phone |> not) list
    


