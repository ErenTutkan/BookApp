BookApp</br>
Bu uygulamada bootcamp kısmında öğrendiklerimi geliştirip daha fazla yeni özellik kazandırmayı planlıyorum.</br>
Kullanılan Framework ve Kütüphaneler .Net Core, MediatR,AutoMapper,Dapper </br>
Sql Olarak ise PostgreSql Kullanılmıştır.</br>
1. Kitapların temel CRUD operasyonları yapılmış CQRS ile servis katmanı geliştirildi.
2. Kategorilerin temel CRUD operasyonları yapılmış CQRS ile servis katmanı geliştirildi.

<br>
-------------------------------------------------------------------------<br>
Kitaplar Yanlarında birden fazla kategorisi ile geliyor <br>
Kategori ekleme işi transaction bütünlüğünü sağlamak için BookInsertCommandHandlerda yapıldı her hangi bir hatada tüm işlemler rollback atıp veritabanında düzensizlik sağlanması önlendi.<br>
Kategori silme işlemi eklendi.<br>
----------------------------------------------------------<br>
Kitapları kategorilere göre listeleme eklendi.<br>
