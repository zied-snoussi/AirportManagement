# Q12 - Average Flight Duration Implementation Comparison

## Overview
Two different approaches to calculate the average flight duration for a given destination with null safety.

---

## ? Original Approach (Verbose)
```csharp
public double GetAverageFlightDuration(string destination)
{
    var destinationFlights = Flights
        .Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));

    if (destinationFlights.Any())
    {
        return destinationFlights.Average(f => f.EstimatedDuration);
    }

    return 0;
}
```
**Issues:**
- Separate variable assignment
- if-else structure (procedural approach)
- More verbose (8 lines)

---

## ? Q12: Lambda Expression with Ternary Operator (Recommended)
```csharp
public double GetAverageFlightDuration(string destination)
{
    // Lambda expression approach - direct Average with predicate
    var destinationFlights = Flights.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
    return destinationFlights.Any() ? destinationFlights.Average(f => f.EstimatedDuration) : 0;
}
```
**Advantages:**
- ? Ternary operator (`? :`) for concise conditional logic
- ? Cleaner return statement
- ? More functional programming style
- ? 3 lines instead of 8

---

## ? Q12.2: LINQ Query Syntax
```csharp
public double GetAverageFlightDurationQuery(string destination)
{
    var result = (from f in Flights
                  where f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)
                  select f.EstimatedDuration);
    return result.Any() ? result.Average() : 0;
}
```
**Advantages:**
- ? SQL-like syntax
- ? Select only the property needed (EstimatedDuration)
- ? Ternary operator for null safety
- ? Clear separation of query and aggregation

---

## Comparison Table

| Aspect | Original | Q12 (Lambda) | Q12.2 (Query) |
|--------|----------|--------------|---------------|
| Lines of Code | 8 | **3** ? | 4 |
| Control Flow | if-else | Ternary | Ternary |
| Query Style | Method syntax | Method syntax | **Query syntax** ? |
| Readability | Medium | **High** ? | High |
| Null Safety | ? Any() | ? Any() | ? Any() |
| Best For | N/A | Most cases | SQL developers |

---

## Test Results
Both methods return identical results:
```
Q12: Testing GetAverageFlightDuration()
Average duration for flights to Paris: 270 minutes
Average duration for flights to Madrid: 240 minutes
Average duration for flights to Lisbonne: 210 minutes

Q12.2: Testing GetAverageFlightDurationQuery() - LINQ Query Syntax
Average duration for flights to Paris: 270 minutes (Query Syntax)
Average duration for flights to Madrid: 240 minutes (Query Syntax)
```

---

## Key Concepts Demonstrated

### Ternary Operator
```csharp
condition ? valueIfTrue : valueIfFalse
```
- Concise replacement for if-else
- Returns value directly
- Perfect for simple conditional returns

### Null Safety Pattern
```csharp
collection.Any() ? collection.Average() : 0
```
- Check if collection has elements before averaging
- Prevents `InvalidOperationException` on empty sequences
- Returns default value (0) when no data exists

### LINQ Average() Method
1. `Average(selector)` - with lambda selector
   ```csharp
   flights.Average(f => f.EstimatedDuration)
   ```

2. `Average()` - no parameters (for numeric sequences)
   ```csharp
   durations.Average()
   ```

### Query Syntax Pattern
```csharp
from item in collection
where condition
select property
```
- Familiar to SQL developers
- Transformed to method syntax by compiler
- More readable for complex queries

---

## Key Differences Between Methods

### Q12 (Method Syntax)
- Filters entire Flight objects
- Selects property in Average lambda
- Pattern: `Where(...).Average(f => f.Property)`

### Q12.2 (Query Syntax)
- Selects only EstimatedDuration property
- Averages the numeric sequence
- Pattern: `(from...select Property).Average()`
- More memory efficient (only projects needed property)

---

## Performance Considerations

| Aspect | Q12 | Q12.2 |
|--------|-----|-------|
| Memory | Materializes flights | **Projects only int** ? |
| LINQ Operations | Where + Average | Where + Select + Average |
| Deferred Execution | ? Yes | ? Yes |
| Performance | Good | **Slightly better** ? |

**Note:** Q12.2 is marginally more efficient because it projects only the integer values instead of keeping entire Flight objects in memory.

---

## Recommendation

? **Use Q12 (Ternary + Lambda)** for:
- Quick implementations
- Consistent method syntax throughout codebase
- When readability is priority

? **Use Q12.2 (Query Syntax)** for:
- Memory-sensitive scenarios (large datasets)
- Teams familiar with SQL
- When you want to emphasize projection before aggregation

---

## Best Practice Pattern

For **both approaches**, the pattern is:
```csharp
var filtered = [filter logic];
return filtered.Any() ? filtered.Aggregate() : defaultValue;
```

This ensures:
1. ? Null safety
2. ? Clear intent
3. ? No runtime exceptions
4. ? Predictable behavior

---

## Common Mistakes to Avoid

? **Don't do this:**
```csharp
return Flights.Average(f => f.EstimatedDuration); // Throws on empty!
```

? **Don't do this:**
```csharp
if (!destinationFlights.Any())
    return 0;
return destinationFlights.Average(f => f.EstimatedDuration);
```
*Reason:* Early return makes code harder to follow. Use ternary instead.

? **Do this:**
```csharp
return destinationFlights.Any() ? destinationFlights.Average(f => f.EstimatedDuration) : 0;
```
