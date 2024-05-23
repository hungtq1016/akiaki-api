public static class QueryableExtensions
{
    public static Task<decimal> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector)
    {
        return EntityFrameworkQueryableExtensions.SumAsync(source, selector);
    }

    public static Task<double> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, double>> selector)
    {
        return EntityFrameworkQueryableExtensions.SumAsync(source, selector);
    }

    public static Task<float> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, float>> selector)
    {
        return EntityFrameworkQueryableExtensions.SumAsync(source, selector);
    }

    public static Task<int> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, int>> selector)
    {
        return EntityFrameworkQueryableExtensions.SumAsync(source, selector);
    }

    public static Task<long> SumAsync<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, long>> selector)
    {
        return EntityFrameworkQueryableExtensions.SumAsync(source, selector);
    }
}
