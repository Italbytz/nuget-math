# nuget-math

`nuget-math` bundles the `Italbytz.Math.*` package family for mathematical education scenarios.

It is intended for developers who need reusable mathematical abstractions, geometry implementations, and teaching-oriented sample applications.

## Which package should I use?

- Use `Italbytz.Math.Abstractions` for contracts such as `ITriangle` and `IRightTriangle`.
- Use `Italbytz.Math` for the ready-to-use implementations, including `RightTriangle` with built-in Pythagorean theorem support.

## Quick Start

```csharp
using Italbytz.Math.Geometry;

// Compute hypotenuse from two legs
var triangle = RightTriangle.FromLegs(3, 4);
Console.WriteLine(triangle.C); // 5

// Verify a set of sides
var check = new RightTriangle(5, 12, 13);
Console.WriteLine(check.Verify()); // True

// Solve for a missing leg
var t = RightTriangle.FromLegAndHypotenuse(leg: 5, hypotenuse: 13);
Console.WriteLine(t.B); // 12
```

## Quality checks

This repository includes:

- a GitHub Actions workflow in `.github/workflows/ci.yml`
- automated `restore`, `build`, `test`, and `pack`

## Local validation

```bash
dotnet restore nuget-math.sln
dotnet test nuget-math.sln -v minimal
dotnet pack nuget-math.sln -c Release -v minimal
```

## Release model

- a pushed tag such as `v1.0.0` triggers the release pipeline in GitHub Actions
- if the repository secret `NUGET_API_KEY` is configured, the workflow publishes `.nupkg` and `.snupkg` to NuGet
