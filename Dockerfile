# Etapa 1: Constru��o da aplica��o
# Usa uma imagem oficial do SDK .NET 8 para a constru��o da aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diret�rio de trabalho
WORKDIR /src

# Copia os arquivos de solu��o e todos os arquivos de projeto
COPY *.sln ./
COPY LivrariaFiap.Api/LivrariaFiap.Api.csproj ./LivrariaFiap.Api/
COPY LivrariaFiap.Application/LivrariaFiap.Application.csproj ./LivrariaFiap.Application/
COPY LivrariaFiap.Domain/LivrariaFiap.Domain.csproj ./LivrariaFiap.Domain/
COPY LivrariaFiap.Infrastructure/LivrariaFiap.Infrastructure.csproj ./LivrariaFiap.Infrastructure/

# Restaura as depend�ncias do projeto
RUN dotnet restore

# Copia todos os arquivos de c�digo fonte para o cont�iner
COPY . ./

# Define o diret�rio de trabalho para o projeto da Web API
WORKDIR /src/LivrariaFiap.Api

# Compila a aplica��o em modo Release
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Configura��o do ambiente de runtime
# Usa uma imagem oficial do ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diret�rio de trabalho
WORKDIR /app

# Copia a aplica��o compilada da etapa de constru��o
COPY --from=build /app/out .

# Exponha a porta na qual a aplica��o vai rodar
EXPOSE 5000

# Define o comando de entrada para rodar a aplica��o
ENTRYPOINT ["dotnet", "LivrariaFiap.Api.dll"]







