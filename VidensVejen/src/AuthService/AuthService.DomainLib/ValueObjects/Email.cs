using System.Globalization;
using VidensVejen.SharedKernelLib.Exceptions;

namespace AuthService.DomainLib.ValueObjects;

/// <summary>
/// 
/// </summary>
public record Email
{
    /// <summary>
    /// 
    /// </summary>
    public string Value { get; init; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="DomainException"></exception>
    public Email(string value)
    {
        if (value.Contains('@') == false)
            throw new DomainException("Email is not valid");

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Email address can not be empty");

        Value = value.ToLower(CultureInfo.CurrentCulture);
    }
}

