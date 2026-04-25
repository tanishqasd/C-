# 276. Docker Compose for Multi-Container Apps.
# This file (docker-compose.yml) allows you to launch your API, 
# your Database, and your Redis Cache all with one single command.

version: '3.8'
services:
  construction-api:
    build: .
    ports:
      - "5000:80"
    environment:
      - ConnectionStrings__Default=Server=db;Database=SiteDb;User=sa;Password=Pass!
    depends_on:
      - db
      - cache

  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Pass!

  cache:
    image: redis:latest