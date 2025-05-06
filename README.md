# CI_CD_TEST – Todo Yönetim API ve CI/CD Deneyimi

Basit bir .NET 9 Web API ile in-memory Todo CRUD, Swagger UI, Docker ve GitHub Actions tabanlı CI/CD sürecinin uygulandığı örnek proje.

## Öğrendiklerim & Katkılar
- GitHub Actions ile çok aşamalı pipeline tasarımı:
  - `build-and-test`: `dotnet restore` → `dotnet build` → `dotnet test`
  - `docker-build-and-push`: multi-stage Docker image oluşturma, etiketleme ve Docker Hub’a gönderme
  - `deploy`: SSH üzerinden uzak sunucuya bağlanıp `docker-compose up` ile servisi ayağa kaldırma  
- Secrets yönetimi:
  - `DOCKERHUB_USERNAME`/`DOCKERHUB_PASSWORD`
  - `SSH_PRIVATE_KEY`/`SSH_USER`/`SSH_HOST`  
- Containerizasyon:
  - Çok aşamalı `Dockerfile` optimizasyonu
  - `docker-compose.yaml` ile hızlı yerel geliştirme ve test  
- Otomatik test entegrasyonu ve kod kalitesi takibi  

## Kurulum & Çalıştırma

1. Depoyu klonlayın  
   ```bash
   git clone https://github.com/<org>/CI_CD_TEST.git
   cd CI_CD_TEST
   ```
2. Lokal:
   ```bash
   dotnet run --project CI_CD_TEST/CI_CD_TEST.csproj
   ```  
   Swagger UI → http://localhost:5133/swagger  
3. Docker:
   ```bash
   docker-compose up --build
   ```  

## API Uç Noktaları
- GET    /api/todos  
- GET    /api/todos/{id}  
- POST   /api/todos  
- PUT    /api/todos  
- DELETE /api/todos/{id}  
- GET    /api/todos/ping  

Detay: `Controllers/TodosController.cs`

## Proje Yapısı
```
CI_CD_TEST/
├─ Controllers/            # API kontrolcüsü
├─ Todo.cs                 # Model tanımı
├─ Program.cs              # Uygulama başlatma ve middleware
├─ Dockerfile              # Multi-stage image
├─ docker-compose.yaml     # Geliştirme/Prod compose
└─ appsettings*.json       # Konfigürasyonlar
.github/
└─ workflows/main.yml      # CI/CD pipeline tanımı
```

## CI/CD Süreci
Pipeline adımları `.github/workflows/main.yml` içinde:
1. build-and-test  
2. build-and-push (Docker Hub)  
3. deploy (SSH + Docker Compose)  

## Lisans
MIT © Siz  
