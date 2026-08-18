namespace Auctify.Exceptions.ExceptionsBase;

public abstract class ExceptionBase: SystemException
{
  public ExceptionBase(string errorMessage) : base(errorMessage)
  {
  }

  public abstract List<string> GetErrors();
}