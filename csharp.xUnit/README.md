# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

# Test Strategy

## Testing Approach

### 1. Unit Tests (GildedRoseTest.cs)
We test each item type separately:

- **Normal Items**: Basic quality decrease
- **Aged Brie**: Quality increases with age
- **Sulfuras**: Never changes
- **Backstage Passes**: Quality changes based on concert date

We use [Theory] with [InlineData] for common rules across items:
- SellIn decrease
- Quality limits (0-50)

### 2. Approval Tests (ApprovalTest.cs)
Maintains a "snapshot" of system behavior over 30 days to catch unexpected changes during refactoring

## Challenges
- Handling many item/day combinations

# Refactoring Improvements
### Isolate Responsibilities
Each item type (Aged Brie, Backstage Pass, Sulfuras, etc.) has unique aging rules. 
We place those rules into separate “strategy” classes. This reduces the deep nested if blocks and makes the code easier to follow.

### Use the Strategy Pattern
The UpdateQuality method now delegates to specialized update strategies instead of handling every case in one place. This makes it simpler to add new item types later without changing existing logic.

### Simplify the Main Loop
he main UpdateQuality loop focuses only on iterating through items and calling the correct update strategy. This single responsibility makes the GildedRose class more maintainable.

