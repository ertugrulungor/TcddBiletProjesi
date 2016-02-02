TCDD BİLET SATIŞ OTOMASYONU
===================
Geliştirilen uygulama yazılımı Microsoft Windows işletim sistemine yazılmış olup, uygulamaya ait bilgiler aşağıda açıklanmıştır.

**Projenin Amacı:** Türkiye Cumhuriyeti Devlet Demiryolları trenlerine bilet satışı için yapılmış bir programdır. Programın amaçları arasında hızlı, kolay ve hatasız olması bulunmaktadır. Ayrıca bu sistem sayesinde yolculara aldıkları biletin fiyatına göre puan verme özelliği getirilmiştir. Yolcular dilediklerinde puanlarını kullanabilmelidir.

**Proje Geliştirme Araçları:** Yazılım geliştirme faaliyetleri sırasında aşağıda gösterilen yazılım geliştirme araçları kullanılmıştır.

| Araç                     | İşlevi      |
| ------------------------ | ---------------- |
| Visual Studio (C#.net)   | Uygulama geliştirmede programlama aracı olarak Visual Studio içerisinde yer alan C# programlama dili kullanılmıştır. |
| Photoshop CS5   | Ekran ve banner’ların tasarımına görsellik kazandırmak amacıyla mevcut araca ek olarak bu yazılım aracından istifade edilmiştir. |


Kullanılan sınıfların açıklamaları: 
-------------
UML diyagramında kullanılan sınıfların detaylı açıklamaları ve işlevleri şunlardır:

 **- Hat Sınıfı:** Bu sınıfın görevi önceden tanımlanmış seferleri ve fiyatlarını tutmaktadır. Şu anda sistemimiz sadece Turgutlu / Manisa şubesinde kullanılacağı için seferler kısıtlanmıştır. aşağıda gösterilen seferler tanımlanmıştır.

| Kalkış Noktası | Varış Noktası | Fiyat |
| ------------------------ | ---------------- | ----------- |
| Turgutlu   | Uşak | 10 TL |
| Turgutlu   | Manisa | 6 TL |
| Turgutlu   | İzmir | 8 TL |

**- BiletBas Sınıfı:** Bu sınıfın görevi geçici bir liste olmaktır. Oluşturduğu liste BiletGoruntuleme formuna giderek o an bilet alan yolcuların biletini yazdıracaktır.

**- Yolcu Sınıfı:** Bu sınıf yolcuların ad, soyad, TC numarası, puanı gibi bazı bilgilerini tutar.

**- YolcuVerileri Sınıfı:** Bu sınıf sisteme TC’si yazılan müşterinin daha önce kaydı olup olmadığına bakar. Eğer kaydı varsa puanını forma gönderir.

**- Odeme Sınıfı:** Bu yolcu ve abstract Ode methodunu barındıran abtract üst sınıftır.

**- Puan Sınıfı:**  Odeme sınıfından türeyen bu sınıf, müşteri puanını kullanmak isteğinde biriken puana göre indirim yapmaktadır.

**- Nakit Sınıfı:** Odeme sınıfından türeyen bu sınıf, müşteri nakit olarak ödeme yapmak istediğinde kullanılır.

**- KrediKarti Sınıfı:** Odeme sınıfından türeyen bu sınıf, müşteri kredi kartı ile ödeme yapmak istediğinde kullanılır.

**- Bilet Sınıfı:** İçerisinde yolcu, koltuk numarası, bilet numarası, bilet tarihi gibi bilgileri, ayrıca BiletNoCek ve abstract IndirimYap adlı methodu barından abstract üst bir sınıftır.

**- Tam Sınıfı:** Bilet sınıfından türeyen bu sınıf, müşteri tam bilet istediğinde kullanılır.

**- Öğrenci Sınıfı:** Bilet sınıfından türeyen bu sınıf, müşteri öğrenci bileti istediğinde kullanılır. Öğrenciye %30 indirim uygulanmaktadır.

**- Öğretmen Sınıfı:** Bilet sınıfından türeyen bu sınıf, müşteri öğretmen bileti istediğinde kullanılır. Öğretmene %20 indirim uygulanmaktadır.

**- Seyahat Sınıfı:** İçerisinde hatlardan oluşan bir liste, bilet gibi bilgileri barındıran bu sınıf, seyahatin tutarını hesaplar. Ayrıca hatlar bu sınıf içerisinde atanır.

**- Tren Sınıfı:** Bu sınıf tarih, koltuk sayısı ve biletler listesi tutmaktadır. Trenler programın açıldığı gün dahil olmak üzere ilerideki 5 güne tanımlanmıştır ve bu 5 güne bilet satılmaktadır.

**- TCDD Sınıfı:** Bu sınıf Trenlerin listesini tutmaktadı. Ayrıca trenlerin ataması bu sınıf içerinde yapılmıştır.

**Ekran Görüntüleri:**  Yazılımın ekran görüntüleri aşağıdaki resimlerde gösterilmiştir.

![Yolcu Bilet Satış Ekranı](http://ertugrulungor.com/wp-content/uploads/2016/02/a1.png)

<center>Yolcu Bilet Satış Ekranı</center>

![Yolcu bilet silme ve güncelleme ekranı](http://ertugrulungor.com/wp-content/uploads/2016/02/a2.png)
<center>Yolcu bilet silme ve güncelleme ekranı</center>

![Bilet Örneği - 1](http://ertugrulungor.com/wp-content/uploads/2016/02/a3.png)
<center>Bilet Örneği - 1</center>

![Bilet Örneği - 2](http://ertugrulungor.com/wp-content/uploads/2016/02/a4.png)

<center>Bilet Örneği - 2</center>
