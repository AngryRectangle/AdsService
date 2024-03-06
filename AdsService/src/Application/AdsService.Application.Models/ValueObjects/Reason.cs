namespace AdsService.Application.Models.ValueObjects;

public readonly struct Reason 
{
    public decimal Result { get; }
    public string Comment { get; }
    
    public Reason(decimal result, string comment)
    {
        Result = result;
        if (result == CheckResult.Approved && !string.IsNullOrEmpty(comment)) 
            throw new ArgumentException("Result error.");

        if (string.IsNullOrEmpty(comment))
            Comment = string.Empty;
        else if (comment.Length > 100)
            throw new ArgumentException("Comment length should be less than or equal to 100 characters.");
        else
            Comment = comment;
    }
}

public enum CheckResult
{
    Approved,
    Rejected
}
