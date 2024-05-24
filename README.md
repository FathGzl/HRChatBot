# HRChatBot Nedir, Ne işe Yarar?
İnsan Kaynakları profesyonelleri ile adaylar arasında bir ön mülakat yapılmasını sağlayarak işe alım sürecini daah etkin hale getirmeyi amaçlar.

# Kurulum Aşamaları
Veritabanı olarak PostgreSql kurulumu yapılmalıdır. Ardından migration yapılarak db tarafında tüm tablolar oluşturulmalıdır. 

## Veritabanı oluşturulması 
	Db linki WebAPI projesinde appsettings ConnectionString WebApiDatabase parametresi kullanılmalıdır. (Veritabanı oluşturulması ve migration yapılması gereklidir.)

## Migration 
dotnet ef migrations add <nameForYourMigration> --project HRChatBot.WebAPI --context HRChatBotContext
dotnet ef database update --project HRChatBot.WebAPI --context HRChatBotContext


## Proje nasıl çalıştırılır?
Client ve WEBAPI projeleri Solution üzerinde multiple Startup seçilerek Start edilebilmektedir.