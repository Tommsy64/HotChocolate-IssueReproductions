# ToPageAsync() Issue Reproduction

1. `docker compose up -d` to start the ephemeral database (no persistant volume, defaults to port `5433`).
2. `dotnet ef database update`
3. `dotnet run`
4. Run the following GraphQL query:

```graphql
query {
  speakers {
    nodes {
      name
    }
  }
}
```

Exception is thrown:
```text
Property 'System.String Name2' is not defined for type 'HotChocolateIssueReproduction.Types.SpeakerDto' (Parameter 'property')
```
