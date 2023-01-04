namespace AI.Blackboards
{
    public static class BlackboardExtensions
    {
        public static void ReplaceVariable(this IBlackboard it, string key, object value)
        {
            it.RemoveVariable(key);
            it.AddVariable(key, value);
        }
    }
}