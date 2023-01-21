namespace WalletAPI.Interface
{
    public interface IHmacValidation
    {
        bool Validation(string userId, string digest);
    }
}
