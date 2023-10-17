# ContactDirectoryApp
.Net Core 7 sürümü ve microservis mimarisi ile oluşturulmuş Kişi rehber api uygulamasıdır.

Api end pointleri ile;
  -  Kişi oluşturulabilir,
  -  Kişilere iletişim bilgileri (Konum, Telefon ve mail) tanımlanabilir.
  -  Kişiler silinebilir
  -  Veriler MongoDB'de tutulur
  -  Filtrelenen bir konuma göre basit bir rapor oluşturulabilir.
  -  Rapor gönderilen konum parametresinde kaç kişinin olduğunu ve bu kişilere ait kaç telefon numarası olduğu bilgisi döner.
  -  Rapor alma mekanizması kuyruklama sistemi ile RabbitMQ tarafından yönetilir.
 
Xunit ile endpointlere çeşitli istekler atan test uygulaması entegre edilmiştir.
    
Uygulamada kullanılan teknolojiler;
 - .Net Core
 - MongoDB
 - RabbitMQ
 - Ortam sağlayıcı olarak Docker kullanılmıştır.
 - İhtiyaç olan kurulumlar için proje içinde docker-notes text dosyasında cmd kodları paylaşılmıştır.

Örnek kullanım senaryosu:
- Person API ile post methodu kullanılarak kişi eklenir (eklenen kişilere lokasyon bilgisi aynı olacak birden fazla kayıt girilmesi raporu zenginelştirecektir.)
- Person API ile eklenen kayıtlar get methodu ile listelenerek kontrol edilebilir.
- Report API ile ilk olarak post methodu kullanılarak hangi lokasyon için veri çekilmek isteniyorsa bir rapor isteğinde bulunulur.
- Report API get methodu kullanılarak var olan raporların listesi çekilebilir. (Durumu tamamlanan veya rabbitmq kuyruğunda işlemi devam eden raporlar listenelecektir)
