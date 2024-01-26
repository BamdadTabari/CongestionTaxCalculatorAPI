namespace Calculator.Shared.Models;
public abstract class BaseDataTransferObject<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public abstract class BaseDataTransferObject : BaseDataTransferObject<int> { }