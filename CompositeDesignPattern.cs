/*The Composite composes objects into tree structures and 
lets clients treat individual objects and compositions uniformly. 
Although the example is abstract, arithmetic expressions are Composites. 
An arithmetic expression consists of an operand, an operator (+ - * /), 
and another operand. The operand can be a number, or another arithmetic expression. 
Thus, 2 + 3 and (2 + 3) + (4 * 6) are both valid expressions.
Component, Leaf and Composite*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class CompositeDesignPattern
    {
        abstract class Component
        {
            public abstract void PrintStructure();
        }
        class File : Component
        {
            private string name;
            private int size;

            public File(string name, int size)
            {
                this.name = name;
                this.size = size;
            }

            public override void PrintStructure()
            {
                Console.WriteLine("File: " + name + " (" + size + " bytes)");
            }
        }

        class Directory : Component
        {
            private string name;
            private List<Component> children;

            public Directory(string name)
            {
                this.name = name;
                this.children = new List<Component>();
            }

            public override void PrintStructure()
            {
                Console.WriteLine("Directory: " + name);
                foreach (Component child in children)
                {
                    child.PrintStructure();
                }
            }

            public void AddChild(Component child)
            {
                children.Add(child);
            }

            public void RemoveChild(Component child)
            {
                children.Remove(child);
            }
        }

        interface IEmployee
        {
            void DisplayDetails();
        }
        
        class Employee : IEmployee
        {
            private string name;
            private string position;

            public Employee(string name, string position)
            {
                this.name = name;
                this.position = position;
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Employee: {name}, Position: {position}");
            }
        }

        // Composite class representing a team or department
        class Team : IEmployee
        {
            private string name;
            private List<IEmployee> members;

            public Team(string name)
            {
                this.name = name;
                this.members = new List<IEmployee>();
            }

            public void AddMember(IEmployee employee)
            {
                members.Add(employee);
            }

            public void RemoveMember(IEmployee employee)
            {
                members.Remove(employee);
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Team: {name}");
                foreach (var member in members)
                {
                    member.DisplayDetails();
                }
            }
        }
        
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
                Directory rootDirectory = new Directory("Root");

                Directory documentsDirectory = new Directory("Documents");
                File textFile = new File("readme.txt", 100);
                documentsDirectory.AddChild(textFile);

                Directory picturesDirectory = new Directory("Pictures");
                File imageFile = new File("vacation.jpg", 10240);
                picturesDirectory.AddChild(imageFile);

                rootDirectory.AddChild(documentsDirectory);
                rootDirectory.AddChild(picturesDirectory);

                rootDirectory.PrintStructure();

                Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
                // Individual employees
                Employee emp1 = new Employee("John Doe", "Manager");
                Employee emp2 = new Employee("Alice Smith", "Developer");
                Employee emp3 = new Employee("Bob Johnson", "Designer");

                // Creating teams
                Team developmentTeam = new Team("Development Team");
                Team designTeam = new Team("Design Team");

                // Adding employees to teams
                developmentTeam.AddMember(emp1);
                developmentTeam.AddMember(emp2);

                designTeam.AddMember(emp3);

                // Creating a company structure
                Team company = new Team("Company");
                company.AddMember(developmentTeam);
                company.AddMember(designTeam);

                // Displaying the company structure
                company.DisplayDetails();
            }
        }

    }
}
