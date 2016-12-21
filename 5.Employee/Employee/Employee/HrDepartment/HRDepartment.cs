namespace Employee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using Entities;

    public class HrDepartment : IHrDepartment
    {
        public const string INPUT = "../../TextFiles/input.txt";
        public const string OUTPUT = "../../TextFiles/output.txt";
        public IList<Employee> Employees { get; set; }
        public IList<string> InvalidInput { get; set; }
        public int InputCounter { get; set; }



        public HrDepartment()
        {
            Employees = new List<Employee>();
            InvalidInput = new List<string>();
            InputCounter = 0;
        }



        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var e in Employees)
            {
                sb.Append($"{e}{Environment.NewLine}");
            }

            return sb.ToString();
        }



        public void SortByAverageSalary()
        {
            Employees = Employees.OrderByDescending(e => e.CalculateAverageSalary()).ThenBy(e => e.Name).ToList();
        }



        public IList<Employee> GetFirst5Employees()
        {
            return Employees.Take(5).ToList();
        }



        public IList<int> GetLast3Id()
        {
            return Employees.Skip(Math.Max(0, Employees.Count() - 3)).Select(e => e.Id).ToList();
        }


        
        public void ReadFromFile(string path)
        {
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string line = string.Empty;
                    try
                    {
                        line = sr.ReadLine();
                        createEmployee(line);
                        InputCounter++;
                    }
                    catch (ArgumentNullException e)
                    {
                        InvalidInput.Add($"{InputCounter}) Input is null ({line}). {e.Message}");
                    }
                    catch (FormatException e)
                    {
                        InvalidInput.Add($"{InputCounter}) Input format is invalid ({line}). {e.Message}");
                    }
                    catch (OverflowException e)
                    {
                        InvalidInput.Add($"{InputCounter}) Input is overflowed ({line}). {e.Message}");
                    }
                    catch (IOException e)
                    {
                        InvalidInput.Add($"{InputCounter}) The file reading has failed ({line}). {e.Message}");
                    }
                    catch (Exception e)
                    {
                        InvalidInput.Add($"{InputCounter}) The application has failed ({line}). {e.Message}");
                    }
                }
            }

        }



        private void createEmployee(string line)
        {
            string[] data = line.Split(',');
            if (data.Length != 4)
            {
                throw new FormatException();
            }

            int salaryType = int.Parse(data[2]);
            if (salaryType == (int)SalaryType.Month)
            {
                Employees.Add(new MonthEmployee
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    MonthRate = double.Parse(data[3])
                });
            }
            else
            {
                Employees.Add(new HourEmployee()
                {
                    Id = int.Parse(data[0]),
                    Name = data[1],
                    HourRate = double.Parse(data[3])
                });
            }
        }



        public void WriteEmployeesToFile(string path, IList<Employee> employeesList, bool isAppend)
        {
            using (var sw = new StreamWriter(path, isAppend))
            {
                foreach (var employee in employeesList)
                {
                    sw.Write(employee.ToString());
                    sw.Write(Environment.NewLine);
                }

                sw.Write(Environment.NewLine);
            }
        }



        public void WriteIdToFile(string path, IList<int> idList, bool isAppend)
        {
            using (var sw = new StreamWriter(path, isAppend))
            {
                sw.Write($"Last 3 id: ");
                foreach (int id in idList)
                {
                    sw.Write($"{id}, ");
                }

                sw.Write(Environment.NewLine);
            }
        }



        public void WriteInvalidInputsToFile(string path, IList<string> invalidInputs, bool isAppend)
        {
            using (var sw = new StreamWriter(path, isAppend))
            {
                sw.Write($"   Invalid inputs: {Environment.NewLine}");
                foreach (string message in invalidInputs)
                {
                    sw.Write($"{message}{Environment.NewLine}");
                }

                sw.Write(Environment.NewLine);
            }
        }
    }
}
