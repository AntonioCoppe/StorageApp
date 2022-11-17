using WireMockDemo.Entity;
using WireMockDemo.StorageApp.Data;

namespace WireMockDemo.Entities{
    class Program{
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            IWriteRepository<Manager> repo = new SqlRepository<Employee>(new StorageAppDbContext());


            var organizationRepository = new ListRepository<Organization>();
            AddOrganization(organizationRepository);
            WriteAllToConsole(organizationRepository);
        }

        private static void AddManagers(IWriteRepository<Manager> MangerRepository)
        {
            MangerRepository.Add(new Manager {FirstName = "John"});
            MangerRepository.Add(new Manager {FirstName = "Jane"});
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
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Jane" });
            employeeRepository.Add(new Employee { FirstName = "Joe" });
            employeeRepository.save();

        }
          private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            //var employee = employeeRepository.GetById(2);
            Console.WriteLine("$Employee with id 2: {employee.FirstName}");
        }


        private static void AddOrganization(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Google" });
            organizationRepository.Add(new Organization { Name = "Apple" });
            organizationRepository.save();
        }
    }
}
    
