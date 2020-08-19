using System;
using WorkStation.Entities;
using System.Globalization;


namespace WorkStation {
    class Program {

        /*
         Sistema simples de cadastro de trabalhadores e seus contratos
         */

        static void Main(string[] args) {
            //Captura dos dados do trabalhador e departamento
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine();
            Console.WriteLine("Enter Worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (JUNIOR/MID_LEVEL/SENIOR) ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            Console.Write("How many contracts to this worker: ");
            int quantContracts = int.Parse(Console.ReadLine());

            //Instancias das classes que gerenciam o departamento e o trabalhador respectivamente
            Department departmentEntity = new Department(department);
            Worker workerEntity = new Worker(name, level, baseSalary, departmentEntity);

            for (int i = 1; i <= quantContracts; i++) {

                //Cadastro de cada contrato realizado pelo trabalhador
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (HOURS): ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, duration);

                workerEntity.AddContract(contract);
            }

            //Filtro por data de contrato do trabalhador e calculo dos ganhos
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            Console.WriteLine("Name: " + workerEntity.Name);
            Console.WriteLine("Department: " + workerEntity.Department.Name);
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Income for {monthAndYear}: " + workerEntity.Income(month, year).ToString("F2"));


        }
    }
}
