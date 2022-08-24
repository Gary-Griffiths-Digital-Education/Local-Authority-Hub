- dotnet ef migrations add "InitialMigration" --project C:\Projects\Local-Authority-Hub-Migrations\Local-Authority-Hub\LAHub\Infrastructure --startup-project C:\Projects\Local-Authority-Hub-Migrations\Local-Authority-Hub\LAHub\WebAPI --output-dir C:\Projects\Local-Authority-Hub-Migrations\Local-Authority-Hub\LAHub\Infrastructure\Persistence\Migrations

- dotnet ef database update --project C:\Projects\Local-Authority-Hub-Migrations\Local-Authority-Hub\LAHub\Infrastructure --startup-project C:\Projects\Local-Authority-Hub-Migrations\Local-Authority-Hub\LAHub\WebAPI
