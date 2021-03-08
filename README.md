# Blog
### Desing Patterns
##### Factory
Proje içerisinde nesnelerin nasıl yaratılacağını kalıtım yoluyla alt sınıflara bırakıp nesne yaratımı için tek ara yüz kullanarak, ara yüzle nesne oluşturma işlemlerini birbirlerinden ayırabilmek için kullanılmaktadır.
 
##### Builder
Projede bulunan karmaşık yapıdaki nesnelerin oluşturulmasında, sadece belirtilen nesne tipini göre üretimi gerçekleştirebilmesini sağlamak için kullanılmaktadır.
 
##### Prototype
Projeye dahil etmiş olduğumuz sınıfların tekrardan new keyword' ü kullanılarak oluşturmasını engelleyerek oluşturulan ilk instance üzerinden işlemleri yapılabilmektedir.

##### Dependency Injection
Projenin çalışacağı ve bağımlı olduğu akışları dışarıdan enjekte ederek uygulama akışını dinamik olarak değiştirilebilmesi için uygulanmaktadır. Uygulamamızın genişletilebilmesi ve yeni geliştirmelerde uygulamanın en az şekilde etkilenmesini sağlayabilmektedir.
 
##### Model View Controller
Projenin birbirine bağlı üç parçaya ayrılmasını gerçekleştirmektedir. WebApi projesi içerisinde view katmanı bulunmadığı için model ve controller katmanları kullanılmaktadır. Controller katmanında crud işlemleri veya mantıksal işlemler gerçekleştirilirken model katmanını   ise veritabanı yapısı ve kullanıcı biriminden gelen verinin yapısına oluşturmaktadır.

### Kullanılan Teknoloji ve Yöntemler
- Asp .Net Core Web Api
- Entity Framework Code First
- MSSQL
- Json Web Token

WebApi için yapılacak olan requestlerde token alınabilmesi için aşağıdaki bilgiler kullanılabilir.
Kullanıcı Adı: ahmetdogan
Şifre: password1!

Teşekkürler.
