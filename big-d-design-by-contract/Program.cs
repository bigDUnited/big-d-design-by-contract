namespace big_d_design_by_contract
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var acc = new Account(-20);
            acc.Deposit(-1);
            acc.Withdraw(-30);
        }
    }
}