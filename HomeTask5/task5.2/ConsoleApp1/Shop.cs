using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shop
    {
        private List<Department> _departments;
        public Shop(List<Department> departments)
        {
            _departments= departments;
           
        }
        public Shop()
        {
            _departments= new List<Department>();
        }
        public void AddDepartment(Department department)
        {
            if (_departments.Any(d => d.Name == department.Name))
                throw new Exception("Department name exists");
            _departments.Add(department);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           foreach(var department in _departments)
            {
                sb.Append(department.ToString()+"\n");
            }
           return sb.ToString();
        }
        public Department GetDepartment(string name)
        {
            if (!_departments.Any(d => d.Name == name))
                throw new Exception("name not found");
            return _departments.FirstOrDefault(d => d.Name == name);
        }
    }
}
