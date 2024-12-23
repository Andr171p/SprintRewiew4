namespace SprintRewiew4
{
    internal class Program
    {
		public interface IEntity
		{
			decimal GetCost();
		}

		public interface ISupplier : IEntity
		{
			string GetName();
			string SupplierType { get; set; }
		}

		public interface IEmployee : IEntity
		{
			string GetFullName();
			string Position { get; set; }
			decimal GetSalary();
		}


		public class Enterprise
		{
			private readonly List<ISupplier> _suppliers = new List<ISupplier>();
			private readonly List<IEmployee> _employees = new List<IEmployee>();

			public void AddSupplier(ISupplier supplier) => _suppliers.Add(supplier);
			public void AddEmployee(IEmployee employee) => _employees.Add(employee);
			public List<ISupplier> GetSuppliers() => _suppliers;
			public List<IEmployee> GetEmployees() => _employees;
			public decimal CalculateTotalCost() => _suppliers.Sum(s => s.GetCost()) + _employees.Sum(e => e.GetCost());
		}

		public class Supplier : ISupplier
		{
			public string Name { get; }
			public decimal Cost { get; }
			public string SupplierType { get; set; }

			public Supplier(string name, decimal cost, string supplierType)
			{
				Name = name;
				Cost = cost;
				SupplierType = supplierType;
			}

			public string GetName() => Name;
			public decimal GetCost() => Cost;
		}

		public class Employee : IEmployee
		{
			public string FullName { get; }
			public string Position { get; set; }
			public decimal Salary { get; }

			public Employee(string fullName, string position, decimal salary)
			{
				FullName = fullName;
				Position = position;
				Salary = salary;
			}

			public string GetFullName() => FullName;
			public decimal GetCost() => Salary;
			public decimal GetSalary() => Salary;
		}

		static void Main(string[] args)
        {
			var enterprise = new Enterprise();

			enterprise.AddSupplier(new Supplier("Logistic Provider", 500000, "Logistics"));
			enterprise.AddSupplier(new Supplier("Office Furniture", 876000, "Furniture"));

			enterprise.AddEmployee(new Employee("Иван Петров", "Manager", 45000));
			enterprise.AddEmployee(new Employee("Лёха Петров", "Developer", 17000));

			Console.WriteLine("Список поставщиков:");
			foreach (var supplier in enterprise.GetSuppliers())
			{
				Console.WriteLine($"- {supplier.GetName()}: Тип - {supplier.SupplierType}, Стоимость услуг: {supplier.GetCost()}");
			}

			Console.WriteLine("\nСписок сотрудников:");
			foreach (var employee in enterprise.GetEmployees())
			{
				Console.WriteLine($"- {employee.GetFullName()}: Должность - {employee.Position}, Зарплата: {employee.GetSalary()}");
			}

			var totalCost = enterprise.CalculateTotalCost();
			Console.WriteLine($"\nОбщие расходы: {totalCost}");
			Console.ReadKey();
		}
    }
}
