namespace AspNetMVC5Demo.Domian.Model.Services
{
    public interface IValidateTranslateDomianService : IDomianService
    {
        AbortTask Validate(int from, int to, int task);
    }
}