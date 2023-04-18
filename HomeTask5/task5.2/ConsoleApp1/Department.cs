using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Department
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public  List<DepartmentBox> DepartmentBoxes { get; set; }
        public List<Department> Subdepartments { get; set; }
        public Department ParentDepartment { get; set; }

        public Department(string name, List<DepartmentBox> departmentBoxes, List<Department> subdepartments)
        {
            Name= name;
            DepartmentBoxes = departmentBoxes;
            Subdepartments= subdepartments;
            foreach(var s in subdepartments)
            {
                s.ParentDepartment = this;
                s.Level = Level + 1;
            }
            if (ParentDepartment == null)
                Level = 1;
        }
        public Department(string name, List<DepartmentBox> departmentBoxes)
        {
            Name = name;
            DepartmentBoxes = departmentBoxes;
            Subdepartments = new List<Department>();
            if (ParentDepartment == null)
                Level = 1;
            else
                Level = ParentDepartment.Level + 1;
        }

        public Department(string name, Department parentDepartment = null)
        {
            ParentDepartment = parentDepartment;
            Name = name;
            DepartmentBoxes = new List<DepartmentBox>();
            Subdepartments = new List<Department>();
            if (ParentDepartment == null)
                Level = 1;
            else
                Level = ParentDepartment.Level + 1;
        }
        public void AddSubdepartment(Department subdepartment)
        {
            if (Subdepartments.Any(d => d.Name == subdepartment.Name))
                throw new Exception("Department name exists");
            subdepartment.ParentDepartment = this;
            Subdepartments.Add(subdepartment);
        }
        public Department GetSubepartment(string name)
        {
            if (!Subdepartments.Any(d => d.Name == name))
                throw new Exception("name not found");
            return Subdepartments.FirstOrDefault(d => d.Name == name);
        }
        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append($"Level = {Level}, name:{Name}\n");
            
            foreach(var sub in Subdepartments)
            {
                stringBuilder.Append(sub.ToString());
            }
            return stringBuilder.ToString();
        }
    }
}
