namespace ConsoleApp4
{
    public interface ComponentsQuery<T> : Query where T : struct
    { }

    public interface ComponentsQuery<T1, T2> : Query
        where T1 : struct
        where T2 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3, T4> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3, T4, T5> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3, T4, T5, T6> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3, T4, T5, T6, T7> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T7 : struct
    { }

    public interface ComponentsQuery<T1, T2, T3, T4, T5, T6, T7, T8> : Query
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T7 : struct
        where T8 : struct
    { }
}
