# EShopMicroservices

## Building Blocks
Building blocks is a place for common nuget packages / libraries and common abstractions that will be used across multiple microservices. 

## Catalog
Catalog is a microservice using vertical slice architecture. 


### Spin up docker
docker compose -f compose.yaml -f compose.override.yaml up -d catalog.api

# For checking logs
- For logs: "docker logs -f catalogdb"


# 1. Stop containers and destroy the volume
docker compose -f compose.yaml -f compose.override.yaml down -v

# 2. Prune any lingering broken volumes
docker volume prune -f


### Connect to db
1. docker ps
2. docker exec -it <container id> bash
3. psql -U <username>
4. \l 
5. \c <db name>