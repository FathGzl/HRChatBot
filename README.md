CRUD İşlemleri için herhangi bir pattern kullanılmamış.(Repository Pattern veya CORS Pattern,Madiator Pattern) <br/>
Transaction için herhangi bir kontrol yok unitofwork kullanılabilirdi  <br/>
Solid aykırı durumlar metotlar ve propertyler ve validator işlemleri aynı classda örnek LoginViewModel solid aykırı  <br/>
Shared dosyasında extension metotlar için configurasyonlar var aynısı api içinde yapılabilirdi örnek ServiceCollectionExtension  <br/>
ViewModels klasöründe concrate ve interfasler aynı yerde viewmodelden çıkarılıp.concrate ve interfaces olarak ayrı klasörde tutardım.  <br/>
Entityler üzerinde insert update ve listeleme yapılmış onları dtolar üzerinde yapılması daha doğru solid aykırı bir durum .  <br/>
dtoları ve entityleri eşleştirmek için automapper kullanılabilirdi.  <br/>
HRChatBot.Components bu katmanda blazor kullanılmış yapıyı çok bilmediğim için burada herhani yorum yapmıyorum.
