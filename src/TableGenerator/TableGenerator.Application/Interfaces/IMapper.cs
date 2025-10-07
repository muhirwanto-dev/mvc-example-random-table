namespace TableGenerator.Application.Interfaces
{
    public interface IMapper
    {
        TTarget Map<TSource, TTarget>(TSource source);
    }
}
