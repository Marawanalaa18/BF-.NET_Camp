namespace Employee_Management_System
{
    abstract class Employee
    {
        public string Name { get; set; }
        protected float salary { get; set; }
        public Employee(string n, float s) 
        {
            Name = n;
            salary = s;
        }
        public abstract void CalculateBonus();
        public void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Name: {Name} ,Salary: {salary}");
        }
    }

    class Manager : Employee
    {
        public Manager(string n, float s) : base(n, s)
        { }
        public override void CalculateBonus()
        {
            salary = salary * 1.2f;
            Console.WriteLine($"Salary with Bonus 20% : {salary}");
        }
    }

    class Developer : Employee
    {
        public Developer (string n, float s) : base(n, s)
        { }
        public override void CalculateBonus()
        {
            salary = salary * 1.1f;
            Console.WriteLine($"Salary with Bonus 10% : {salary}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee developer = new Developer("Ali",15000);
            Employee manager = new Manager("Mohamed", 20000);

            Console.WriteLine("============= Developer =============");
            developer.DisplayEmployeeInfo();
            developer.CalculateBonus();

            Console.WriteLine("\n=============  Manager  =============");
            manager.DisplayEmployeeInfo();
            manager.CalculateBonus();
        }
    }
}