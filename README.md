# SampleReportingService
Sample Reporting Service Backend
Mesajlaşma Servisi: RabbitMQ
Veri Tabanı :Postgresql
Migration: Appsettings.Json dosyasında, "ConnectionStrings:DirectoryDbContext" dizininde bulunan Connectionstring'te bulunan "Database" ve "Password" bilgileri önemlidir.
"Database" adı => ReportingServiceDb olarak belirlenmiştir.

**** "Password" => localinizde kurulu olan postgresql databasine bağlandığınız şifredir. Her kişide farklılık gösterdiğinden boş bırakıyorum.Lütfen kendi şifrenizi giriniz.

bu işlemden sonra "Update-Database" komutu ile tablolarınızı oluşturabilirsiniz.


1.  ReportinService Mikroservisinin görevi Rapor talepleri üretmek ve talem doğrulutusunda oluşturulan raporları veri tabanına kaydetmektir.
2.  RaportCreate ve ReportCapture isminde 2 adet endpoindi bulunmaktadır.
3.  ReportCreate'in görevi RabbitMQ kullanarak DirectoryWorkerService'ye bir rapor talebi oluşturmaktır. Report tablosuna ilk kaydı oluşturur ve talep edilen raporun, Id,Date ve Status durumlarını tutar. Status durumu talep edilen Rapor kendisine ulaşmadığı sürece veri tabanında "Hazırlanıyor" olarak saklanır.
4.  ReportCapture'nin görevi ise DirectoryWorkerService tarafından hazırlanan Rapora ait bilgileri karşılamak ve Status durumunu "Tamamlandı" ya çekerek, RaportDetail bilgilerinide kaydetmektir.

