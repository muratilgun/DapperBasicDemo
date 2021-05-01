# DapperBasicDemo
### **.NET Core 5 Dapper** 

 1. Dapper nasıl implemente edilir?
 2. Dapper ile temel CRUD işlemleri nasıl yapılır?
 3. Repository Design Pattern ile Dapper Kullanımı nasıl olur ?

Sorularına cevap bulmak adına yaptığım projem aynı zamanda Dapper Micro ORM kullanımına pratik yapmamda da yardımcı oldu.
Bu soruları cevaplandırırken aynı zamanda dapperın direk nesne tanıyıp üzerinde işlem yaptığını da anlamış oldum örneğin =>

    public Company Add(Company company)
    {  var sql = "INSERT INTO Companies (Name, Address, City, State, PostalCode) 
    VALUES(@Name, @Address, @City, @State, @PostalCode);" + "SELECT CAST(SCOPE_IDENTITY() as int)";
        //var id = db.Query<int>(sql, new 
        //                    { @Name=company.Name, 
        //                      @Address=company.Address, 
        //                      @City=company.City, 
        //                      @State = company.State, 
        //                      @PostalCode = company.PostalCode}).Single();
    var id = db.Query<int>(sql, company).Single();
    company.CompanyId = id;
    return company;  }

İlk önce sql sorgusunu anlamak gerekirse, yazılı olan değerlerin hepsini id üzerinde alıyorum. Yorum satırına aldığım yerleride güncelliyorum.
Ama kısaca Dapper parametre olarak gönderdiğim nesne üzerinden de işlem yapıyor. Hız konusunda Dapper'ın mucizelerini zaten kendi sitelerinde açıklık getirmişler.. [SİTEYE GİTMEK İÇİN BURAYA TIKLA](https://dapper-tutorial.net/)
