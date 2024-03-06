namespace AdsService.Application.Models.ValueObjects;

using AdsService.Application.Models.Entities;

public readonly struct Reason 
{
    public CheckResult Result { get; }
    public string Comment { get; }
    
    public Reason(CheckResult result, string comment)
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
