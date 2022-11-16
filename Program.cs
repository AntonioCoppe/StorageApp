namespace WireMockDemo.Entities{
    class Program{
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganization(organizationRepository);
        }

      
        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Jane" });
            employeeRepository.Add(new Employee { FirstName = "Joe" });
            employeeRepository.save();

        }
          private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine("$Employee with id 2: {employee.FirstName}");
        }


        private static void AddOrganization(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Microsoft" });
            organizationRepository.Add(new Organization { Name = "Google" });
            organizationRepository.Add(new Organization { Name = "Apple" });
            organizationRepository.save();
        }
    }
}
    
