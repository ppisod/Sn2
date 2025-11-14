namespace ppiLib.Types._Interfaces;

public interface IBase <out T> where T : IBase<T> {
    static abstract T Identity { get; }
    static abstract T Zero { get; } 
    static abstract T One { get; }
}