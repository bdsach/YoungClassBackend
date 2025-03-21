## Project Structure

1. Domain: ดูแลในเรื่องของ Entity สำหรับการสร้างฐานข้อมูลครับ จะถูกนำไปใช้ที่ Project Core ในการพัฒนา Business Logic และใน Project Infra ในตอนที่สร้าง Entity Framework Database Context

2. Application (Core): เป็น Main Business Logic หลักของระบบครับผม จะมีการกำหนด Interface ในส่วนของ Infra ไว้สำหรับการเชื่อมต่อ Backing Service ภายนอกเช่น Database/Email และจะนำ Interface เหล่านี้มาใช้มีการ Implement ในส่วนของ Business Service Logic ด้วยครับ

3. Infrastructure: ดูแลในเรื่องของการนำ Interface จาก Core มา Implement เพื่อให้ระบบสามารถเชื่อมต่อกับ 3rd Parties Services ต่างๆ ได้ เช่น Database Server, Email Server, SMS Gateway

4. Presentation Layer (API): เป็นช่องทางสำหรับให้ Client มาเชื่อมต่อเพื่อใช้บริการแลกเปลี่ยนข้อมูลในระบบเรา

## Setup Project

### Create Gitignore

```bash
dotnet new gitignore
```

### Create Empty Solution File for Project

```bash
dotnet new sln
```

### Create Project Layers

```bash
dotnet new classlib -n Domain
dotnet new classlib -n Application
dotnet new classlib -n Infrastructure
dotnet new webapi -n API --no-openapi --use-controllers
```

### Add Project to Solution

```bash
dotnet sln add ./Domain/Domain.csproj
dotnet sln add ./Application/Application.csproj
dotnet sln add ./Infrastructure/Infrastructure.csproj
dotnet sln add ./API/API.csproj
```

### Add Reference to Project

```bash
cd Application
dotnet add reference ../Domain/Domain.csproj
```

```bash
cd Infrastructure
dotnet add reference ../Domain/Domain.csproj
dotnet add reference ../Application/Application.csproj
```

```bash
cd API
dotnet add reference ../Application/Application.csproj
dotnet add reference ../Infrastructure/Infrastructure.csproj
```

## Entity framework Migration

### When Clean Architecture

#### Create Migration

```bash
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project API
```

#### Update Database

```bash
dotnet ef database update --project Infrastructure --startup-project API
```

### Common use

#### Create Migration

```bash
dotnet ef migrations add InitialCreate
```

#### Update Database

```bash
dotnet ef database update
```