# Bekra IP & DNS Changer

![C#](https://img.shields.io/badge/C%23-.NET-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/UI-Windows%20Forms-512BD4?style=for-the-badge)
![WMI](https://img.shields.io/badge/Windows-WMI-0078D4?style=for-the-badge)
![Network](https://img.shields.io/badge/Domain-Network%20Configuration-0A66C2?style=for-the-badge)

> Windows ağ adaptörlerinin statik IP, subnet maskesi, varsayılan ağ geçidi ve DNS sunucusu ayarlarını WMI üzerinden değiştirmek için hazırlanmış C# Windows Forms aracı.

## 📌 Proje Hakkında

**Bekra IP & DNS Changer**, Windows üzerindeki `Win32_NetworkAdapterConfiguration` WMI sınıfını kullanarak ağ yapılandırmasını değiştirmeyi amaçlar.

Kaynak koduna göre uygulama iki ana işlem gerçekleştirir:

- Seçilen ağ adaptörüne statik IPv4 adresi, subnet maskesi ve varsayılan gateway uygulamak
- IP etkin ağ adaptöründe DNS server search order değerini değiştirmek

Uygulama ayrıca sistemdeki ağ adaptörlerinin açıklamalarını okuyarak bunları kullanıcı arayüzündeki seçim listesine ekler. fileciteturn255file0

## ✨ Özellikler

- 🌐 Ağ adaptörlerini listeleme
- 🖥️ Adaptör açıklamasını seçme
- 📍 Statik IP adresi ayarlama
- 🔲 Subnet maskesi ayarlama
- 🚪 Varsayılan gateway ayarlama
- 🧭 DNS1 / DNS2 yapılandırma
- 🪟 Windows Forms arayüzü
- ⚙️ WMI (`ManagementClass`) üzerinden Windows ağ yapılandırması

## 🧰 Teknoloji Kartları

| Teknoloji | Kullanım |
|---|---|
| 🟢 **C#** | Ana programlama dili |
| 🪟 **Windows Forms** | Masaüstü arayüzü |
| ⚙️ **System.Management** | WMI erişimi |
| 🌐 **Win32_NetworkAdapterConfiguration** | Ağ yapılandırması |
| 🖥️ **Windows** | Hedef platform |

## 🖼️ Ekran Görselleri

Repository'de bulunan mevcut ekran görüntüleri korunmuştur:

![Ana ekran](https://github.com/ebubekirbastama/ip_and_dns_changer/blob/master/1.png)

![DNS/IP ekranı](https://github.com/ebubekirbastama/ip_and_dns_changer/blob/master/2.png)

## 🚀 Kurulum

```bash
git clone https://github.com/ebubekirbastama/ip_and_dns_changer.git
cd ip_and_dns_changer
```

Projeyi Visual Studio ile açıp derleyin. Eski nesil .NET/Visual Studio ortamı kullanıldığından güncel IDE'de hedef framework ve bağımlılıkların yeniden düzenlenmesi gerekebilir.

## ▶️ Kullanım

1. Uygulamayı Windows üzerinde çalıştırın.
2. Ağ adaptörleri listesinden değiştirmek istediğiniz adaptörü seçin.
3. IP adresi, subnet maskesi ve gateway değerlerini girin.
4. IP değiştirme işlemini çalıştırın.
5. DNS alanlarına DNS1 ve DNS2 değerlerini girin.
6. DNS değiştirme işlemini çalıştırın.

Statik IP/gateway işlemi `EnableStatic` ve `SetGateways`; DNS işlemi `SetDNSServerSearchOrder` WMI metodlarıyla gerçekleştirilmektedir. fileciteturn255file0

## 🔍 Çalışma Akışı

```text
Windows Network Adapters
          │
          ▼
Win32_NetworkAdapterConfiguration
          │
          ▼
Adaptör Listesi
          │
     ┌────┴────┐
     ▼         ▼
   IP/GW      DNS
     │         │
     ▼         ▼
EnableStatic  SetDNSServerSearchOrder
     │         │
     └────┬────┘
          ▼
Windows Ağ Yapılandırması
```

## ⚠️ Önemli Teknik Notlar

Bu proje **legacy / sistem yönetimi yardımcı aracı** niteliğindedir.

Mevcut kaynak kodunda:

- IP ve subnet değerleri için kapsamlı format doğrulaması bulunmamaktadır.
- WMI dönüş kodları ayrıntılı olarak işlenmemektedir.
- IP değiştirme hataları `Console.WriteLine` ile ele alınmaktadır.
- DNS işleminde dönüş kodu alınsa da kullanıcıya ayrıntılı hata raporu verilmemektedir.
- Seçilen adaptörün beklenen adaptör olduğuna dair daha güçlü doğrulama bulunmamaktadır.
- Yönetici yetkisi için uygulama seviyesinde açık bir kontrol bulunmamaktadır.

Yanlış IP, subnet veya gateway değerleri ağ bağlantısını kesebilir.

## 🔐 Güvenli Kullanım

Bu uygulama doğrudan işletim sistemi ağ yapılandırmasını değiştirebilir. **Yalnızca sahibi olduğunuz veya yönetme yetkiniz bulunan Windows bilgisayarlarında kullanın.**

Önerilen yaklaşım:

- Mevcut ağ ayarlarını işlem öncesinde kaydedin.
- Önce test makinesinde deneyin.
- Kurumsal cihazlarda değişiklik öncesi yetkilendirme prosedürlerini uygulayın.
- DNS değerlerini yalnızca güvendiğiniz sunucularla değiştirin.

## 🛠️ Modernizasyon Önerileri

- Modern .NET sürümüne geçiş
- IPv4/IPv6 doğrulaması
- `IPAddress.TryParse` tabanlı input validation
- WMI dönüş kodlarının anlamlı hata mesajlarına dönüştürülmesi
- Administrator privilege kontrolü
- Seçilen adaptörün `IPEnabled` durumunun doğrulanması
- Mevcut ayarları yedekleme/geri yükleme
- İşlem loglarının tutulması
- Otomatik testler

## 📄 Lisans

Repository'deki `LICENSE` dosyasına bakınız.

## 👤 Geliştirici

**Ebubekir Bastama**  
GitHub: [@ebubekirbastama](https://github.com/ebubekirbastama)

---

⭐ Projeyi faydalı bulduysanız repository'ye yıldız bırakabilirsiniz.
