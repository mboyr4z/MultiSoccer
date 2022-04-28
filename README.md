<h2>PUN(Photon Unity Networking) ile Çin Kalesi Oyunu <h2>
<h4>İlgili Modül kullanılarak oluşturduğum Oyun Linki (<a href = "#">APK</a> veya <a  href = "#">EXE</a> )</h4>
  
 PUN, multiplayer oyun geliştirme yapmak isteyenleri çin tasarlanmış kolay, hızlı ve uyumlı bir ağ için bileşenler oluşturmaya yarayan bir modüldür.
  <h1><a href = "#kurulum">Kurulum<a/></h1>
  <h1><a href = "#server">Server ve Lobby'e bağlanma<a/></h1>
  <h1><a href = "#UIYönetimi">UI Yönetimi<a/></h1>
  <h1><a href = "#OyunaBaslama">Oyun<a/></h1>
  <h1><a href = "#OyundaKarsilasilanHatalarveCozumler">Oyunda Karşılaşılan Hatalar ve Çözümleri<a/></h1>
    
    
<h2 id ="kurulum" >PUN KURULUM</h2>
  <p>Editörümüze kurmak için Assetstore linklerimiz <a href= "https://assetstore.unity.com/packages/tools/network/photon-pun-2-120838#reviews">Ücretli Sürüm</a> ve <a href= "https://assetstore.unity.com/packages/tools/network/pun-2-free-119922#description">Ücretsiz Sürüm</a><p>
  
  (Ben bu oyunu tasarlarken ücretsiz olan sürümden yararlandım. Ücretsiz sürüm, bize oyunda aynı anda maximum 20 kişi olabilecek şekilde server veriyor. Oyun denemeleri için gayet iyi.)
  
  Kurulumuzu yaptıktan sonra karşımıza PUN Wizard ekranı geliyor ve bizden bir app ID istiyor.
  
 <p align="center">
  <img src="https://user-images.githubusercontent.com/82450697/159863548-113b7e27-67d7-496f-84ed-26ebb961b445.png"  width="537px" height="319px" title="hover text">
</p>


  
  İlgili App ID için Photon sitesinde oturum açıp, uygulama oluşturmamız gerek. Create new App kısmına gidip Photon-Type seçeneğini PUN yapıyoruz. Sonra uygulama ismi ve açıklama girdikten sonra uygulamamızı oluşturuyoruz (Photon Website : https://dashboard.photonengine.com/en-US/)
  
  Uygulamamız oluştuktan sonra, dashboardda oluşturduğumuz tüm photon uygulamaları listeleniyor. Görüntü aşağıdaki gibi olur. Burada App_ID yazan kısma tıklayarak ID'nin tamamını kopyalıyoruz. Daha sonra unity'de istenilen kısma yapıştırıyoruz. (Eğer Setup Wizardı yanlışlıkla kapatyısanız "Window > Photon Unity Networkin > Pun Wizard > Setup Project" konumundan tekrar açabilirsiniz..)
    
  <br>
    
<h2 id ="server" >Server ve Lobby</h2>
Server ve lobby işlemlerini "Launcher" isimli classta yaptım. Link : https://github.com/mboyr4z/MultiSoccer/blob/main/Scripts/Launcher.cs
Callback ve bağlanma ile ilgili fonksiyonları mümkün olduğunca sürekli aktif olan bir objede yapmak mantıklı oluyor. Ayriyeten bağlanma olayı esnasında yükleniyor ekranı gibi ekranların açılıp kapatılması da burada. Oyun esnasında saniyede kaç kez diğer objelerle iletişim kurulması da burada start fonksiyonun içerisinde belirtildi.

<h2 id ="UIYönetimi" >UI Yönetimi</h2>
Farklı görevi olan her bir panel objesi, buton ya da listeItem scriptleri burada oluşturuldu. SOLID'e uygun dinamik yapılar için bu gerekli. Burada bağlanana kadar loading ekranı, bağlandıktan sonra Title ekranı, ilgili butonlara tıklanınca da diğer paneller aktif ya da pasif oluyor. Menü yönetimi kolaylığı açısından MenuManager adında script oluşturuldu. İçerisinde liste barındırıyor. Liste tipleri ise "Menu" tipindeki objeler oluyor. Her bir panel de bu menü classını component olarak taşıyor. Menüler kendi içinde açılma ya da kapanma olaylarını barındırıyor. MenuManager ise biri açıldığında diğerini kapatan ve menü isimleri ile menü açıp kapama yapabilen dinamikliğe sahip. Oyun başlayana kadar ki her türlü UI scriptleri aşağıdaki linktedir.<br>
Link : https://github.com/mboyr4z/MultiSoccer/tree/main/Scripts/UI

      
<h2 id ="#OyunaBaslama" >Oyuna Başlama</h2>
    
RoomPanel'inde odayı kuran masterda startGame butonu aktif oluyor ve tüm oyuncular sahne değiştiriyor. Burada her kişinin kendi spawneri önce player üretimi yapıyor. Daha sonra her oyuncu nesnesi kale üretiyor ve sadece master top üretiyor. Oyun maximum 4 kişilik oynanıyor. Deneme amaçlı şu anlık 1 kişiyi de kabul ediyor. Her kişi 3 gol yiyince playeri yok oluyor. Maçı bu esnada izlemeye devam edebilir ya da oyundan ayrılabilir. En sona kalan kişi ise oyunu kazanıyor. Ayriyeten oyunda iken kişide oyundan ayrılabilir. Oyun ise hızlı deneme yapabilmek amacıyla 640*320 olarak windowsta denenebilir. Yönteimleri joystick değil WASD + Space tuşları olur . Oyun esnasında kullanılan tüm classlar aşağıdadır: 
    
Link : https://github.com/mboyr4z/MultiSoccer/tree/main/Scripts/Game

<h2 id ="OyundaKarsilasilanHatalarveCozumler" >Oyunda Karşılaşılan Hatalar ve Çözümleri</h2>

1-) <i>MonobehaviourPunCallBack modülünün Callback fonksiyonları bazen farklı classta tetiklenmiyor.</i>
<br>
Ç:) Tüm callback fonksiyonları "Launcher" isimli classta yazdım.
<br><br>
    
2-) <i>Photon.Instantinate çalışmıyor.<br></i>
Ç:) İlgili prefabın resources klasöründe olduğundan ve prefabın PhotonView componentine sahip olduğundan emin olun.
<br><br>
    
3-) <i>Benim hareket ettirdiğim karakter, diğer cihazlarda hareket etmiyor.</i>
<br>
Ç:) Karakter prefabına eğer transform üzerinden hareket ettiriyorsanız PhotonTransformView, velocity ile hareket ettiriyorsanız PhotonRigidbodyView componenti ekleyin.
<br><br>
    
4-) <i>Hareket tuşuna bastığımda benim ekrandaki tüm objeler hareket ediyor. Ama diğer kullanıcılarda sadece benimkisi hareket ediyor.</i>
<br>
Ç:) Bunun nedeni hareket scriptinin hiyerarşinizdeki tüm playerlarda olması. Bunu engellemenin yolu hareket scriptini ilk başta prefabta pasif kılın. Photon.Instantinate ile üretim yaparken dönen gameObject değerini değişkene atayın. Sonra gameObject değişkeni üzerinden hareket scriptini aktifleştirin. Bu sayede hareket eden tek karakter sizin bizzat ürettiğiniz karakter olmuş olur. Hem de Update içerisinde sürekli IsMine'dan kurtulmuş olursunuz.
<br><br>

5-)<i>(RPC method 'SetScoreGlobal(Int32, String)' not found on object with PhotonView 1001.)  gibisinden hatalar.</i>
<br>
Ç:) Set Score Global isminde bir metol olmayabilir. Varsa o metodun hemen üzerinde [PunRPC] ibaresi olmayabilir.
<br><br>

    
6-) <i>OnRoomListUpdate(List<RoomInfo> roomList) fonksiyonu oyuna girerken tüm oda listesini döndürürken, daha sonra hepsini döndürmüyor. Sürekli güncel oda listesini alamıyorum.</i>
<br>
Ç:) Photon sanıyorum ki veri optimizasyonundan ötürü böyle bir yöntem kullanıyor. Yöntem ise lobbye bağlandıktan sonra ilgili fonkisyon tüm oda listesini alır. Daha sonra ise o listede olan herhangi bir değişiklikte, sadece değişiklik yapılan odayı döndürür. Örneğin lobbye bağlandık ve 5 oda bizlere döndü. Odanın birinde hiç oyuncu kalmadığından ilgili oda kapandı. Bu sefer bu kapanma olayının hemen ardından OnRoomListUpdate() fonksiyonu tetiklenir ve bizlere sadece değişiklik olan, yani kapanan odayı döndürür. Kalan 4 kişiyi döndürmez. İlgili kullanım "findRoom" adlı classtadır.<br>
Link : https://github.com/mboyr4z/MultiSoccer/blob/main/Scripts/UI/FindRoom.cs.<br><br>

7-) <i>OnCollider ile tetiklenen bir RPC fonksiyon olmuş olsun. Her hiyerarşide ilgili collider çalıştığından bir kere tüm kişilerde çalışması gereken fonksiyon, kişisayisi^2 kadar çalışıyor. </i>
<br>
Ç:)Bunu engellemenin yolu, ilgili collidera sahip olan obje eğer Photon.Instantinate ile üretilmiş ise PhotonView().IsMine koşulu ile sadece üreten kişi RPC'yi çalıştırır ve her cihazda sadece birer kez tetiklenmiş olur.
<br><br>
    

8-) <i>Ping Problemi</i><br>
Ç-) Bir kaç yöntem mevcut. Birincisi, serverdan saniyede gelen veri sayısını artırmak. 
    
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
        // Launcher classında yazıldı
Buna rağmen hala pingler oluyorsa, hareket etme olayınız Transform ile mi yoksa Rigidbody ile mi emin olun. Ona göre Photon componenti ekleyin. Transform için PhotonTransformView, Rigidbody için PhotonRigidBodyView. Eğer buna rağmen de kasıyorsa. Hareket halindeki gameObject için <a href="https://youtu.be/5lS9XNgPSDQ">OnPhotonSerializeView</a> kullanın. Her obje, diğerlerine veri gönderir. Diğerleri de güncellemeyi gelen veriye bakar ve Vector3.Lerp() gibi hareket yumuşatan fonksiyonlardan yararlanarak uygular. 
<br><br>

9-) <i>RPC bir cihazda çalışıyor diğer cihazda ise hata veriyor.</i>
    1-) Kullandığınız uygulamanın biri son derlemenizin ürünü, diğeri ise bir önceki derlemenin ürünü olabilir. Yani birinde diğrek o fonksiyon olmayabilir.

10-) <i>RPC için dikkat edilmesi gereken kurallar.</i>
    
    1-) Mümkünse deneme yaptığınız 2 uygulama da aynı derleme ile çalışıyor olsun.. Biri önceki sürümden kalır ve bu yüzden de RPC'ler birinde henüz olmamış olabilir
    2-) [PunRPC] ifadesini ilgili RPC fonksiyonun üzerine eklememiş olabilirsiniz.
    3-) İlgili fonksiyon GetComponent<PhotonView>().RPC("func_name",RPCTarget.All,null) şeklinde çağırırsanız "func_name" stringini düzgün yazamamış olabilirsiniz. Burada önerim nameof(func) şeklinde kullanırsanız hata yapma imkanınız 0'a iner. nameof(func), içine aldığı fonksiyonun stringsel olarak adını döndürür.
    4-) Sizin sahnenizde PhotonView ID'si neyse, diğer sahnelerde de aynı PhotonViewID li elemanda tetiklenir. Scripti kullanan her objede çalışmaz!!! Buna dikkat.
  
