# APARTMAN YÖNETİM SİSTEMİ

# Genel Açıklama
- Projede Yönetici ve Kullanıcı olmak üzere iki adet varsayılan rol tanımlanmıştır.
- Proje ayağa kaldırıldığında Manager rolünde manager@manager.com ile User rolünde user@user.com email adresine sahip iki adet kullanıcı oluşmaktadır. Bunların şifreleri "Sifre%5" olarak belirlenmektedir. Bu kullanıcılarla sisteme giriş yapılabilir. 
    

## Tamamlanan Adımlar

- Yönetici, Yeni Kullanıcı oluşturmakta, var olan kullanıcıları güncelleyebilmektedir. 
- Yönetici, Blok ve Daire bilgilerini oluşturamakta ve var olanları güncelleyebilmektedir.
- Yönetici, Fatura oluşturabilmekte ve var olanları güncelleyebilmektedir.
- Yönetici, Faturaların ödenip ödenmediği bilgisini görüntüleyebilmetedir.
- Yönetci, Yıllık ve Aylık olarak fatura türüne göre Ödeme Dökümü alabilmektedir. 

## Eksik Kalan Adımlar
- Ödeme işlemi için api tamamlanamadı.
- Mesajlaşma modülü tamamlanamadı.
 

# Login İşlemi

-Login işlemi kayıtlı Email ve Şifre ile yapılmaktadır. Validasyonlar kontrol amaçlı kullanılmaktır. 

<img width="840" alt="01 Login" src="https://user-images.githubusercontent.com/71590181/164468270-3f8445d3-27d2-4d48-ab74-aa735209f2e8.PNG">

<img width="897" alt="01 login 2" src="https://user-images.githubusercontent.com/71590181/164468654-596b14a6-930c-42bb-bb34-bad8dbf1e984.PNG">

# Anasayfa

- Projede sol tarafta açılıp kapanabilen menü alanı bulunmaktadır.

 <img width="903" alt="02 Ana Sayfa" src="https://user-images.githubusercontent.com/71590181/164469150-99e4899d-fb18-42d9-8225-d344ce1922d5.PNG">
 
 <img width="806" alt="02 Ana Sayfa 2" src="https://user-images.githubusercontent.com/71590181/164469190-a34f5eba-7a1f-4b62-b91a-fc5363c8cd9b.PNG">

# Kullanıcı İşlemleri

- Kullanıcı ekleme, güncelleme, silme işlemleri Manager yetkisi olanlar tarafından "Kimlik - Rol" sayfasında yapılmaktadır.
- Listeleme işlemi için Datatable kullanılmış olup; sayfalama ve arama işlemi yapılabilmektedir. Ekleme-Güncelleme-Silme işmleri AJAX sorguları ile yapılmakta olup; sayfa yenilenmeden kullanıcıya gösterilmektedir. 
 
<img width="946" alt="03" src="https://user-images.githubusercontent.com/71590181/164470499-62bb6bd3-f0f9-41f0-8b0c-0973369a7085.PNG">

<img width="955" alt="03 1" src="https://user-images.githubusercontent.com/71590181/164470524-20753e5d-121d-46d4-be0e-0f00d1272b35.PNG">

- Kullanıcı araç ekleme işlemleri "Araç" sayfasında yapılmaktadır. Bir kullanının birden fazla aracı sisteme kaydedilecek şekilde tasarım yapılmıştır. Yine buradaki işlemler de sayfa yenilenmeden AJAX metodları ile yapılmaktadır. Yine kullanıcı arama yapabilmekte, sayfalama yapabilmektedir. 

<img width="956" alt="03 3" src="https://user-images.githubusercontent.com/71590181/164471313-b6b653a1-e07b-408d-9073-01c21108c679.PNG">




# Konut/Daire İşlemleri

- Blok (Apartman) işlemleri "Blok" sayfasında yapılmaktadır. Bu sayfada listeleme, sayfalama, arama, ekleme, çıkarma, silme işlemleri yapılabilmektedir. Ekleme, silme, güncelleme işlemleri Ajax ile yapılmakta olup sayfa yenilenmemektedir. 

<img width="956" alt="04 2" src="https://user-images.githubusercontent.com/71590181/164472412-493cdaf3-f061-40ff-a408-a3f71dcba4b1.PNG">

- Daire işlemleri "Daire" sayfasında yapılmaktadır. Tıpkı yurakıda oludğu gibi listeleme, sayfalama, arama, ekleme, çıkarma, silme işlemleri yapılabilmektedir tüm bu işlemler Jquery ve Ajax yardımıyla sayfa yenilemeden gerçekleştirilebilmektedir. 

<img width="951" alt="05 " src="https://user-images.githubusercontent.com/71590181/164473090-7319e653-f774-4fbe-8d9e-3c26eb1d1e86.PNG">

<img width="934" alt="05 2" src="https://user-images.githubusercontent.com/71590181/164473468-582c9abe-d537-4e97-8200-85d0f68f7750.PNG">




# Fatura İşlemleri

- Fatura Ekleme, güncelleme, silme işlemleri ile oluşturulan faturaların dairelere yansıtılması işlemi "Fatura Ekle-Dağıt" sayfasında yapılmaktadır. Burada önce faturalar yıl, ay ve fatura tipi bazında oluşturulmakta, ardından oluşturulan faturaların dairelere yansıtılması için "Dairelere Dağıt" tuşu ile birsonraki adıma geçilmektedir. 
 
<img width="960" alt="06 1" src="https://user-images.githubusercontent.com/71590181/164474949-693fec4a-f347-43e2-96c4-4049303e54e2.PNG">

<img width="948" alt="06 2" src="https://user-images.githubusercontent.com/71590181/164474970-4515c566-5748-443a-9832-98cc02762322.PNG">

- Oluşturulan bu faturalar aşağıda olduğu gibi dairelere tek tek yansıtılmakta, güncellenmekte, silinmekte yada topluca seçili tüm dairelere tanımlanılabilmektedir. 

<img width="956" alt="06 3" src="https://user-images.githubusercontent.com/71590181/164474997-ded03b67-e87d-4fc1-8a93-46d4e75efbaa.PNG">

<img width="955" alt="06 4" src="https://user-images.githubusercontent.com/71590181/164475008-b681fc1a-cb86-4fd2-a396-72a2b15b8f95.PNG">


- Hangi kullanıcının ödeme yapıp yapmadığı seçilen filtre alanlarına göre "Genel Fatura Durumu" sayfasında yer gösterilmektedir. 

<img width="943" alt="07 1" src="https://user-images.githubusercontent.com/71590181/164478552-ffeb7a90-77e3-4713-b16f-69f97cadea98.PNG">

- "Borç Alacak Durumu" sayfasında ise filtre alanları doğrulsunuda genel durum gösterilmektedir. 

<img width="949" alt="07 2" src="https://user-images.githubusercontent.com/71590181/164478617-b06d9661-d43f-4801-bcaf-9b544bd4fe15.PNG">


# Hesabım Alanı

-Bu alan role bakılmaksızın tüm kayıtlı kullanıcıların kullanabileceği alandır. Kullanıcılar burada kendilerine tanımlanan faturalı görebilmekte, ödeme işlemi yapabilmekte ve yaptıkları ödemeleri listeleyebilmektedirler. 

<img width="950" alt="8 1 " src="https://user-images.githubusercontent.com/71590181/164479624-9d54c7df-ee4c-4e65-874b-f00022c5a1ec.PNG">

<img width="956" alt="8-2" src="https://user-images.githubusercontent.com/71590181/164479692-9667a431-5861-4396-a96d-1867db182f9b.PNG">

- "Şifre Güncelle" sayfasında kullanıcılar şifrelerini güncelleyebilmektedirler. 

<img width="939" alt="9" src="https://user-images.githubusercontent.com/71590181/164479796-a249006f-0f1b-4da3-9686-c50de3dac9d6.PNG">

- Güvenli çıkış işlemi menünün alt kısmında bulunan buton yardımıyla yapılabilmektedir. 



