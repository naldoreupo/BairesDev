FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["BairesDev.Exam.Domain.Entity/BairesDev.Exam.Domain.Entity.csproj", "BairesDev.Exam.Domain.Entity/"]
COPY ["BairesDev.Exam.Domain/BairesDev.Exam.Domain.csproj", "BairesDev.Exam.Domain/"]
COPY ["BairesDev.Exam.Repository.Entity/BairesDev.Exam.Infraestructure.Entity.csproj", "BairesDev.Exam.Repository.Entity/"]
COPY ["BairesDev.Exam.Repository/BairesDev.Exam.Infraestructure.csproj", "BairesDev.Exam.Repository/"]
COPY ["BairesDev.Exam.Service.Entity/BairesDev.Exam.Service.Entity.csproj", "BairesDev.Exam.Service.Entity/"]
COPY ["BairesDev.Exam.Service/BairesDev.Exam.Service.csproj", "BairesDev.Exam.Service/"]
COPY ["BairesDev.Exam.Transversal/BairesDev.Exam.Transversal.csproj", "BairesDev.Exam.Transversal/"]

RUN dotnet restore "BairesDev.Exam.Service/BairesDev.Exam.Service.csproj"
COPY . .
WORKDIR "/src/BairesDev.Exam.Service"
RUN dotnet build "BairesDev.Exam.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BairesDev.Exam.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BairesDev.Exam.Service.dll"]