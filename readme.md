  

# BlockChain

Short description
-----------------
Learning project on .NET 10 that demonstrates a simple blockchain structure with a Web API, an application layer, a domain model and infrastructure components.

Solution layout
---------------
- src/BlockChain.Api — Web API to interact with the blockchain implementation
- src/BlockChain.Application — application services and use cases
- src/BlockChain.Infrastructure — infrastructure implementations (storage, helpers)
- src/Blockchain.Domain — domain entities and business rules
- tests/BlockChain.UnitTests — unit tests
- tests/BlockChain.FunctionalTests — functional tests

Requirements
------------
- .NET 10 SDK (for local development and building images)
- PowerShell or Command Prompt (Windows)

Requirements to run (Docker)
---------------------------
- Docker Desktop or Docker Engine installed and running
- docker compose or docker CLI

Build and run API locally
-------------------------
1. Clone the repository:
   git clone <https://github.com/nemuhinvv-collab/BlockChain.git>
2. Change to the solution folder:
   cd BlockChain
3. Build the solution:
   dotnet build BlockChain.slnx
4. Run the API (from src/BlockChain.Api or specify the project):
   dotnet run --project src/BlockChain.Api

Build and run API in containers
-------------------------------
1. Clone the repository:
   git clone <https://github.com/nemuhinvv-collab/BlockChain.git>
2. Change to the solution folder:
   cd BlockChain
3. Run the provided script to build and start containers:
   run.bat

Pre-run actions (Docker environment)
----------------------------------
1. Ensure Docker is installed and the Docker daemon is running (Docker Desktop or engine).
2. Ensure dotnet-ef is installed (if you need to run EF Core migrations locally):
   dotnet tool install --global dotnet-ef
3. Prepare environment variables: copy .env.example to .env and adjust values if needed. The included run.bat will use .env when present.
4. Build and start containers. You can use docker compose (if a compose file exists) or the provided run.bat to build and run the API and Postgres database.
   - With docker compose:
	 docker compose build
	 docker compose up -d
   - Using run.bat (Windows):
	 run.bat
5. Apply database migrations if required (run locally or inside the API container):
   dotnet ef database update

Note: adjust commands if the repository uses a different compose file name (for example docker-compose.yml) or custom scripts.

Testing
-------
Note: start required services (run.bat or docker compose) before running tests.

1. Run all tests:
   dotnet test

Development notes
-----------------
- The project follows Clean Architecture and is organized into layers: API → Application → Domain → Infrastructure.
- Uses an event-store approach: database records are append-only and preserve the history of requests.
- Implements CQRS: separate read and write contexts with corresponding repositories. Each context has its own connection string and can target a read replica in the future.
- Unit of Work (UoW) and Repository patterns are applied where appropriate.
- Swagger is available at /swagger; health checks are available at /health.
- Logging filters and exception handlers are included.
- Pagination is supported for the blockchain history endpoint.
- Postgres Db is running in the container and 5432 port is exposed to be able to test and modify db localy.
- TPC(type per class) entity framework approach is implemented to store different types of inherited objects.  

Contributing
------------
- Pull requests are welcome. Describe changes and include tests when possible.

License
-------
Add a LICENSE file in the repository root or specify the project license (for example, MIT).

Remove containers
-----------------
To stop and remove the containers started by run.bat or docker compose, run the provided stop.bat script from the repository root:

1. Stop and remove containers and related resources (Windows):
   stop.bat

The stop.bat script will use docker compose down if a compose file is present; otherwise it will stop and remove the blockchain-api and blockchain-postgres containers and remove the blockchain network created by run.bat.

