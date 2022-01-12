# RSCyrptLite
Çift Faktörlü Basit Şifreleme Uygulaması

Faktör 1:Parçalara Böl ve Simetriğini Al
Faktör 2:AES şifrelemesi uygula

# Faktör 1
Adım 1: Girilen veriler Byte dizisine dönüştürülür.
Adım 2: Byte dizisinin uzunluğunun çarpanları hesaplanır.
Adım 3: Çarpanlardan birbirine en yakın olan 2 tane çarpan seçilir.
Adım 4: Seçilen çarpanlardan küçük olan parça sayısı büyük olan parça uzunluğu olarak belirlenir.
Adım 5: Byte dizisi parça sayısı ve parça uzunluğuna göre parçalanıp 2 boyutlu Byte dizisine çevirilir.
Adım 6: 2 boyutlu Byte dizisinin 2 boyutununda simetriği alınır.
Adım 7: 2 boyutlu Byte dizisi tek boyutlu Byte dizisine çevirilir.
Adım 8: Çevirilimiş byte dizisine AES şifrelenmesi uygulanır.
Adım 9: Byte dizisi girilen verinin formatına dönüştürülür.
Adım 10: Girilen veri şifrelenmiş olur.

ÖRNEK:
Encyprt Aşaması

Verimiz resulcelik değerinde bir string veri olsun

resulcelik verisinin uzunluğu 10 byte

10 un çarpanları hesaplanır 1, 2, 5, 10,

birbirine en yakın 2 çarpan seçilir 2 ve 5

2 parça sayısı olur. 5 parça uzunluğu

resul   celik   parça uzunluğu 5
parça1  parça2

byte dizisi 2 boyutlu byte dizisine çevirilir.

örnek olarak şu görünüme kavuşur

byte[0,0] = 'r' byte[0,1] = 'e' byte[0,2] = 's' byte[0,3] = 'u' byte[0,4] = 'l'

byte[1,0] = 'c' byte[1,1] = 'e' byte[1,2] = 'l' byte[0,3] = 'i' byte[0,4] = 'k'

byte dizisinin 2 boyutununda simetriği alınır

1- resulcelik
2- luserkilec
3- kilecluser

2 boyutlu byte dizisi tek boyutlu byte dizisine çevirilir ve AES şifreleme uygulanır

kilecluser => AES Şifreleme(Key:0000000000000000) => BitConverter => Encyrpted Tex => FA3EFBB75DFB23FD5E3A85EFDCE86310

Decyprt Aşaması 
Encypt Aşamasının Tersi :D


