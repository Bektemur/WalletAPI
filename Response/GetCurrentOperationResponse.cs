namespace WalletAPI
{
    public class GetCurrentOperationResponse : Response
    {
        public int Count { get; set; }
        public double Amount { get; set; }
    }
}
