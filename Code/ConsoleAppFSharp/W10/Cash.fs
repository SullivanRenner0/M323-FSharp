module Cash

type ArticleName = string
type ArticleCode = string
type Price = int

type Register = (ArticleCode * (ArticleName * Price)) list

type Amount = int
type Item = Amount * ArticleCode
type Purchase = Item list

type Info = Amount * ArticleName * Price
type Infoseq = Info list
type Bill = {Items: Infoseq; Total: Price}

let rec createRegister articles : Register = 
  match articles with
  | [] -> []
  | (code, name, price) :: rest -> (code, (name, price)) :: createRegister rest  

let rec findArticle (article: ArticleCode) (register: Register) : ArticleCode * Price = 
  match register with
  | (a, name_price)::_ when article = a -> name_price
  | _::rest -> findArticle article rest
  | [] -> failwith "Article not found"

let rec makeBill (reg: Purchase) (register: Register) : Bill = 
  match reg with
  | [] -> {Items = []; Total = 0}
  | (amount, article)::rest -> 
    let (name, pricePerPiece) = findArticle article register
    let price = amount * pricePerPiece
    let newItem = (amount, name, price)
    let restBill= makeBill rest register
    {Items = newItem :: restBill.Items; Total = price + restBill.Total}







