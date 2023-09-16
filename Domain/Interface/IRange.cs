namespace Domain.Interfaces;

public interface IRange<T>
{
    T Start { get; }
    T End { get; }
}