using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace WorkStation.Entities {
    class Worker {

        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); 

        public Worker() {

        }

        public Worker(  string name, 
                        WorkerLevel level, 
                        double baseSalary, 
                        Department department) {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Funcao para adicionar contrato a lista de contratos do trabalhador
        public void AddContract(HourContract Contract) {
            Contracts.Add(Contract);
        }

        //Funcao para remover contrato da lista de contratos do trabalhador
        public void RemoveContract(HourContract Contract) {
            Contracts.Remove(Contract);
        }

        //Funcao que faz o filtro por data do calculo de ganhos do trabalhador
        public double Income(int Month, int Year) {
            double sum = BaseSalary;
            foreach (HourContract Contract in Contracts) {
                if (Contract.Date.Year == Year && Contract.Date.Month == Month) {
                    sum = sum + Contract.TotalValue();
                }
            }

            return sum;
        }
    }
}
