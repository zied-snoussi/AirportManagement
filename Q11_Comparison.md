# Q11 - Weekly Flight Count Implementation Comparison

## Overview
Three different approaches to count flights within a 7-day period starting from a given date.

---

## ? Original Approach (Verbose)
```csharp
public int GetWeeklyFlightCount(DateTime startDate)
{
    DateTime endDate = startDate.AddDays(7);

    return Flights
        .Where(f => f.FlightDate >= startDate && f.FlightDate < endDate)
        .Count();
}
```
**Issues:**
- Extra variable `endDate`
- Two LINQ methods chained (Where + Count)
- More verbose

---

## ? Q11: Lambda Expression with Count Predicate (Recommended)
```csharp
public int GetWeeklyFlightCount(DateTime startDate)
{
    // Lambda expression approach - inline calculation
    return Flights.Count(f => f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7));
}
```
**Advantages:**
- Single LINQ method call
- Inline date calculation (no extra variable)
- More concise and readable
- Uses `Count()` with predicate lambda

---

## ? Q11.2: LINQ Query Syntax
```csharp
public int GetWeeklyFlightCountQuery(DateTime startDate)
{
    return (from f in Flights
            where f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7)
            select f).Count();
}
```
**Advantages:**
- SQL-like syntax (familiar to database developers)
- More readable for complex queries with multiple clauses
- Uses `from...where...select` pattern

---

## Comparison Table

| Approach | Lines of Code | Readability | Performance | Best For |
|----------|--------------|-------------|-------------|----------|
| Original | 6 lines | Medium | Same | N/A |
| Lambda (Q11) | 1 line | High | Same | Most cases |
| Query Syntax (Q11.2) | 3 lines | High | Same | Complex queries |

---

## Test Results
Both methods return the same result:
```
Q11: Testing GetWeeklyFlightCount()
Number of flights in the week starting 2024-06-15: 2

Q11.2: Testing GetWeeklyFlightCountQuery() - LINQ Query Syntax
Number of flights in the week starting 2024-06-15: 2
```

---

## Key Concepts Demonstrated

### Lambda Expression
- Inline anonymous function: `f => expression`
- Used directly in LINQ method: `Count(f => ...)`
- Concise and modern C# style

### LINQ Query Syntax
- SQL-like declarative syntax
- Uses keywords: `from`, `where`, `select`
- Transformed to method syntax by compiler

### Count() Overloads
1. `Count()` - no parameters (counts all)
2. `Count(predicate)` - with lambda predicate (filters + counts in one call)

---

## Recommendation
? Use **Lambda with Count(predicate)** (Q11) for:
- Simple filtering + counting
- Cleaner, more concise code
- Modern C# style

? Use **Query Syntax** (Q11.2) for:
- Complex queries with multiple joins/groupings
- Team preference for SQL-like syntax
- Teaching/learning LINQ fundamentals
