module Cash

type ArticleName = string
type ArticleCode = string
type Price = int

type Register = (ArticleCode * (ArticleName * Price)) list

type Amount = int
type Item= Amount * ArticleCode
type Purchase = Item list

type Info = Amount * ArticleName * Price
type Infoseq = Info list
type Bill = Infoseq * Price

let register: Register = [
    ("a1", ("cheese", 25))
    ("a2", ("herring", 4))
    ("a3", ("soft drink", 5))
]

let pur : Purchase = [(3, "a2");(1,"a1")]


let rec findArticle article (register: Register) = 
  match register with
  | (a, name_price)::_ when article = a -> name_price
  | _::rest -> findArticle article rest
  | [] -> failwith "Article not found"

let rec makeBill (reg:Purchase) (register: Register) : Bill = 
  match reg with
  | [] -> ([],0)
  | (amount, article)::rest -> 
    let (name, pricePerPiece) = findArticle article register
    let price = amount * pricePerPiece
    let (restBill, total) = makeBill rest register
    ((amount, name, price)::restBill, price + total)






