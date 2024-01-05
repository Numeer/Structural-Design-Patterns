/*The Decorator attaches additional responsibilities to an object dynamically. 
assault gun is a deadly weapon on it's own. But you can apply certain "decorations" to make it more accurate, silent and devastating.
Simple pizza, with cheese ,with pepperoni*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{

    // Component interface
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetCost()
        {
            return 1.0;
        }
    }

    // Decorator
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee decoratedCoffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.decoratedCoffee = coffee;
        }

        public virtual string GetDescription()
        {
            return decoratedCoffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedCoffee.GetCost();
        }
    }

    // Concrete Decorator 1
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.5;
        }
    }

    // Concrete Decorator 2
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.2;
        }
    }
    // Component interface
    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete Component
    public class PlainPizza : IPizza
    {
        public string GetDescription()
        {
            return "Plain Pizza";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }

    // Decorator
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza decoratedPizza;

        public PizzaDecorator(IPizza pizza)
        {
            this.decoratedPizza = pizza;
        }

        public virtual string GetDescription()
        {
            return decoratedPizza.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedPizza.GetCost();
        }
    }

    // Concrete Decorator 1
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with Extra Cheese";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.5;
        }
    }

    // Concrete Decorator 2
    public class PepperoniDecorator : PizzaDecorator
    {
        public PepperoniDecorator(IPizza pizza) : base(pizza) { }

        public override string GetDescription()
        {
            return base.GetDescription() + ", with Pepperoni";
        }

        public override double GetCost()
        {
            return base.GetCost() + 2.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine("Cost: " + coffee.GetCost() + "; Description: " + coffee.GetDescription());

            coffee = new MilkDecorator(coffee);
            Console.WriteLine("Cost: " + coffee.GetCost() + "; Description: " + coffee.GetDescription());

            coffee = new SugarDecorator(coffee);
            Console.WriteLine("Cost: " + coffee.GetCost() + "; Description: " + coffee.GetDescription());

            Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
            IPizza pizza = new PlainPizza();
            Console.WriteLine("Cost: " + pizza.GetCost() + "; Description: " + pizza.GetDescription());

            pizza = new CheeseDecorator(pizza);
            Console.WriteLine("Cost: " + pizza.GetCost() + "; Description: " + pizza.GetDescription());

            pizza = new PepperoniDecorator(pizza);
            Console.WriteLine("Cost: " + pizza.GetCost() + "; Description: " + pizza.GetDescription());
        }
    }

}

