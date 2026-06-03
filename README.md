# ToPageAsync() selects OrderBy properties missing from the projected DTO

Reproduces a `QueryHelpers.EnsureOrderPropsAreSelected` error in `GreenDonut.Data` on
Hot Chocolate `16.0.14-p.1`. See https://github.com/ChilliCream/graphql-platform/issues/8262.

No external database is required — the app uses the Entity Framework Core in-memory
provider and seeds data on startup.

1. `dotnet run`
2. Open http://localhost:5095/graphql and run the following GraphQL query:

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

The same exception is thrown by the `speakers2` field (which uses `[UsePaging]` instead of
`[UseConnection]`).
