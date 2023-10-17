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
