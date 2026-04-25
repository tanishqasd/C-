namespace AdvancedTesting
{
    // 286. Mutation Testing (Stryker).
    // Standard tests check your code. Mutation testing checks your TESTS. 
    // It changes your code (e.g., changes > to <) and sees if your tests fail. 
    // If your tests still pass, it means your test suite is weak.
    
    public class SafetyCalculator
    {
        // If a mutation test changes ">=" to ">", does your test catch it?
        public bool IsLoadSafe(double load, double limit) => load <= limit;
    }
}