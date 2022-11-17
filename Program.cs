using WireMockDemo.StorageApp.Data;

namespace WireMockDemo.Entities
{
    class Program
    {
        static void Main(string[] args)
        {

            ItemAdded<Employee> itemAdded = new ItemAdded<Employee>(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(), EmployeeAdded);

            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            IWriteRepository<Manager> repo = new SqlRepository<Employee>(new StorageAppDbContext());


            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
            WriteAllToConsole(organizationRepository);
        }

        private static void EmployeeAdded(object item)
        {
            var employee = (Employee) item;
            Console.WriteLine($"Employee Added {employee.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> MangerRepository)
        {
            var JohnManager = new Manager { FirstName = "John" };
            //var JohnManagerCopy = JohnManager.Copy();
            MangerRepository.Add(JohnManager);

            if(JohnManager is not null)
            {
                JohnManager.FirstName+="_Copy";
                //MangerRepository.Add(JohnManagerCopy);
            }

            MangerRepository.Add(new Manager { FirstName = "Jane" });
            MangerRepository.save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }


        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee {FirstName = "John"},
                new Employee {FirstName = "Jane"},
                new Employee {FirstName = "Jack"}
            };
            employeeRepository.AddBatch(employees);
        }
        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            //var employee = employeeRepository.GetById(2);
            Console.WriteLine("$Employee with id 2: {employee.FirstName}");
        }


        private static void AddOrganization(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization {Name = "Microsoft"},
                new Organization {Name = "Google"},
                new Organization {Name = "Apple"},
            };
            organizationRepository.AddBatch(organizations);
        }

        private class ItemAdded<T>
        {
            private Action<object> employeeAdded;

            public ItemAdded(Action<object> employeeAdded)
            {
                this.employeeAdded = employeeAdded;
            }
        }
    }
}

