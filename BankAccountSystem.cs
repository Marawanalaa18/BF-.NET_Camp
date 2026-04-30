namespace Day_6
{
    class BankAccount
    {
        private int account_number;
        protected float balance;
        public BankAccount(int account_number, float balance)
        {
            this.account_number = account_number;
            this.balance = balance;
        }

        public void Deposit(float money)
        {
            if (money > 0)
            {
                balance += money;
                Console.WriteLine("Deposit successful. New balance: " + balance);
            }
            else
                Console.WriteLine("Invalid Deposit.");
        }
        public virtual void Withdraw(float money) 
        {
            if(balance <= 0 || balance < money)
                Console.WriteLine("Your balance is not enough to Withdraw\n");            
            else
            {
                balance -= money;
                Console.WriteLine($"Withdraw successful. New balance: {balance}");
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {balance}");
        }
    }

    class SavingsAccount : BankAccount
    {
        public SavingsAccount(int acc_num, float balance) : base(acc_num, balance) 
        {        }
        public override void Withdraw(float money)
        {
            if(balance - money >= 100)
            {
                balance -= money;
                Console.WriteLine($"Savings Withdraw successful. New balance: {balance}");
            }
            else
                Console.WriteLine("Minimum balance of 100 required");
        }
    }

    class CurrentAccount : BankAccount
    {
        public CurrentAccount(int acc_num, float balance) : base(acc_num, balance)
        { }
        public override void Withdraw(float money)
        {
            if(balance - money >= -500)
            {
                balance -= money;
                Console.WriteLine($"Current Withdraw successful. New balance: {balance}");
            }
            else            
                Console.WriteLine("Overdraft limit exceeded.");
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount c1 = new SavingsAccount(1,500);
            BankAccount c2 = new CurrentAccount(2,1000);

            Console.WriteLine("============ Saving balance ============");
            c1.Deposit(100);
            c1.Withdraw(500);
            c1.Withdraw(100);

            Console.WriteLine("\n============ Current balance ============");
            c2.Deposit(100);
            c2.Withdraw(1000);
            c2.Withdraw(600);
            c2.Withdraw(500);
        }
    }
}
