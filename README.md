# Seth Miller - Red Rover Code Puzzle

This simple set of projects contains two variations of an answer to the Red Rover developer code puzzle. 

Each is essentially the same approach, just ported to a different language.

## TypeScript

The directory `SethMiller-TypeScript` contains a small TypeScript application. 

This application uses some very basic bootstrapping for test execution and TypeScript handling, based on the examples provided by [Vitest](https://vitest.dev/guide/) and [TypeScript](https://www.typescriptlang.org/tsconfig/).

To execute, use one of the following options (after first running `npm ci`):

* `npm run dev` - Simple execution of primary code to see the requested result
* `npm run test` - A quick execution of a handful of tests
* `npm run test:watch` - A "watch mode" execution of those same tests
* `npm run build` - Compile the application into JavaScript

## C#

The directory `SethMiller-CSharp` contains a small .Net 8 C# application.

To execute, use one of the following options (from the base directory):

* `dotnet run --project ./source/SethMiller-CSharp.csproj` - Simple execution of primary code to see the requested result
* `dotnet test "./tests/SethMiller-CSharp.Tests.csproj"` - A quick execution of a handful of tests
