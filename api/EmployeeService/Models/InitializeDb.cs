using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Models
{
    public class InitializeDb
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Position>().HasData(
                new Position() { Id = 1, Name = "Инженер", SurplusFactor = 1.2 },
                new Position() { Id = 2, Name = "Младший инженер", SurplusFactor = 1.0 },
                new Position() { Id = 3, Name = "Главный инженер", SurplusFactor = 1.5 },
                new Position() { Id = 4, Name = "Бухгалтер", SurplusFactor = 1.0 }
                );

            builder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "Произодственный" },
                new Department() { Id = 2, Name = "Финансовый" }
            );

            builder.Entity<Person>().HasData(
                new Person() { Id = 1, Firstname = "Михаил", Lastname = "Соколов", Surname = "Викторович", DateOfBirth = new DateTime(1987, 6, 12) },
                new Person() { Id = 2, Firstname = "Геннадий ", Lastname = "Овчинников ", Surname = "Рубенович", DateOfBirth = new DateTime(1999, 3, 1) },
                new Person() { Id = 3, Firstname = "Илья ", Lastname = "Голубев ", Surname = "Натанович", DateOfBirth = new DateTime(1996, 4, 12) },
                new Person() { Id = 4, Firstname = "Михаил", Lastname = "Фролов", DateOfBirth = new DateTime(1977, 5, 23) },
                new Person() { Id = 5, Firstname = "Владлена", Lastname = "Богданова", Surname = "Олеговна", DateOfBirth = new DateTime(1979, 9, 22) },
                new Person() { Id = 6, Firstname = "Алевтина", Lastname = "Пономарёва", Surname = "Альбертовна", DateOfBirth = new DateTime(1997, 4, 25) }
                );

            builder.Entity<Employee>().HasData(
                new Employee() { Id = 1, TariffRate = 35000, DateOfEmployment = new DateTime(2020, 5, 10), DepartmentId = 1, PersonId = 1, PositionId = 1 },
                new Employee() { Id = 2, TariffRate = 31000, DateOfEmployment = new DateTime(2021, 1, 9), DepartmentId = 1, PersonId = 2, PositionId = 2 },
                new Employee() { Id = 3, TariffRate = 32000, DateOfEmployment = new DateTime(2022, 2, 22), DepartmentId = 1, PersonId = 3, PositionId = 1 },
                new Employee() { Id = 4, TariffRate = 34000, DateOfEmployment = new DateTime(2019, 7, 21), DepartmentId = 2, PersonId = 6, PositionId = 4 },
                new Employee() { Id = 5, TariffRate = 35000, DateOfEmployment = new DateTime(2022, 8, 14), DepartmentId = 2, PersonId = 5, PositionId = 4 },
                new Employee() { Id = 6, TariffRate = 37000, DateOfEmployment = new DateTime(2021, 11, 15), DepartmentId = 1, PersonId = 4, PositionId = 3 }
                );
        }
    }
}
