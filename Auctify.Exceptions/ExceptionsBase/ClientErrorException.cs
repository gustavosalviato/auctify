using System.Net;

namespace Auctify.Exceptions.ExceptionsBase;

public class ClientErrorException : ExceptionBase
{
    private readonly string _message;
    
    public ClientErrorException(string errorMessage) : base(errorMessage)
    {
        _message = errorMessage;
    }

    public override List<string> GetErrors()
    {
        return new List<string> { _message };
    }

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}