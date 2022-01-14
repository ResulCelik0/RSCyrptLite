# RSCyrptLite
#### Basit 2 Faktörlü Şifreleme Uygulaması
------------
### Çalışma Adımları

------------


##### Adım1: 
Girilen veriler byte dizisine dönüşür.
##### Adım2:
byte dizisinin uzunluğunun çarpanlarını alınır ve çarpanlardan birbirlerine en yakın çift seçilir.
##### Adım3:
Seçilen çiften küçük olan parça sayısı büyük olan parça uzunluğu olarak değişkenlere atanır.
##### Adım4:
byte dizisi parça sayısı ve parça uzunluğuna göre 2 boyutlu byte dizisine çevirilir.
##### Adım5:
2 boyutlu byte dizisinin 1. boyutunun simetiriği alınır.
##### Adım6:
2 boyutlu byte dizisinin 0. boyutuna son baş seçme algoritması uygulanır.
##### Adım7:
2 boyutlu byte dizisi tek boyutlu byte dizisine çevirilir.
##### Adım8:
byte dizisine AES şifrelenmesi uygulanır.
##### Adım9:
şifrelenmiş byte dizisi girişteki veri türüne çevirilir ve şifrelenmiş veri çıktı olarak verilir.

------------

### ÖRNEK

------------
- Girilen veri tipimiz string ve değeri **resulcelik** olsun
-  **resulcelik** verisi byte dizisine çevirilsin
-  **resulcelik** byte dizisinin uzunluğu 10
- 10 nun çarpanları 1 2 5 10 biribirine en yakın 2, 5,
-  2 parça sayısı 5 parça uzunluğu


- **resul  celik** => parca uznluğu 5
- parca1  parca2
- byte dizisi 2 boyutlu byte dizesine çevirilir.
##### 2 boyutlu dizinin görünümü(*değerler anlaşılabilir olsun diye char veri tipine çevirilmiştir*):
- byte[0,0]='r' , byte[0,1]='e' , byte[0,2]='s' , byte[0,3]='u' , byte[0,4]='l'
- byte[1,0]='c', byte[1,1]='e' , byte[1,2]='l'  , byte[1,3]='i'  , byte[1,4]='k'

- 2 boyutlu dizinin 1. boyutunun simetriği alınır
1.  resulcelik
2.  luserkilec

- 2 boyutlu dizinin 0. boyutuna son baş seçme algoritrması uygulanır
3.  kilecluser
------------
#### Son Baş Seçme Algoritması
Veriyi bir sonundan bir başından seçerek karmaşık sıralar
- Örn abcdef
-   faebdc
------------
- 2 boyutlu dizi tek boyutlu dizeye çevirilir
- AES şifrelemesi uygulanır
- Ekrana çıktı olarak yazılır




   Giriş    =>  Simetri Algoritması => Son Baş Seçim Algoritması   =>        AES Şifrelemesi        =>             Çıktı
   
 resulcelik =>      luserkilec     =>        kilecluser            =>  **AESKEY(0123456789012345)** => B45AF0DCF6FB8A77154C82661369675F

