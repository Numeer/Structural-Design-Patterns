/*The Bridge pattern decouples an abstraction from its implementation, 
so that the two can vary independently. A household switch controlling 
lights, ceiling fans, etc. is an example of the Bridge. The purpose of 
the switch is to turn a device on or off. The actual switch can be 
implemented as a pull chain, simple two position switch, or a variety of dimmer switches.
Video and Video Processing are two different abstractions and they can
be configured independently. Video can be configured to use different
implementations of Video Processing and vice versa.*/
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{

    // Implementor interface
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int channel);
    }

    // Concrete Implementor 1
    public class TV : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("TV is turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is turned off");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine("TV channel set to " + channel);
        }
    }

    // Concrete Implementor 2
    public class Radio : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Radio is turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Radio is turned off");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine("Radio channel set to " + channel);
        }
    }

    // Abstraction
    public abstract class RemoteControl
    {
        protected IDevice device;

        public RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract void SetChannel(int channel);
    }

    // Refined Abstraction 1
    public class BasicRemoteControl : RemoteControl
    {
        public BasicRemoteControl(IDevice device) : base(device) { }

        public override void TurnOn()
        {
            device.TurnOn();
        }

        public override void TurnOff()
        {
            device.TurnOff();
        }

        public override void SetChannel(int channel)
        {
            device.SetChannel(channel);
        }
    }
    // Implementor interface
    public interface IColor
    {
        void ApplyColor();
    }

    // Concrete Implementor 1
    public class RedColor : IColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Applying red color");
        }
    }

    // Concrete Implementor 2
    public class BlueColor : IColor
    {
        public void ApplyColor()
        {
            Console.WriteLine("Applying blue color");
        }
    }

    // Abstraction
    public abstract class Shape
    {
        protected IColor color;

        protected Shape(IColor color)
        {
            this.color = color;
        }

        public abstract void Draw();
    }

    // Refined Abstraction 1
    public class Circle : Shape
    {
        public Circle(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.Write("Drawing Circle: ");
            color.ApplyColor();
        }
    }

    // Refined Abstraction 2
    public class Square : Shape
    {
        public Square(IColor color) : base(color) { }

        public override void Draw()
        {
            Console.Write("Drawing Square: ");
            color.ApplyColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------EXAMPLE 1---------------------------------");

            IDevice tv = new TV();
            RemoteControl remoteControl = new BasicRemoteControl(tv);

            remoteControl.TurnOn();
            remoteControl.SetChannel(5);
            remoteControl.TurnOff();

            IDevice radio = new Radio();
            remoteControl = new BasicRemoteControl(radio);

            remoteControl.TurnOn();
            remoteControl.SetChannel(102);
            remoteControl.TurnOff();
            Console.WriteLine("---------------------------------EXAMPLE 2---------------------------------");
            IColor red = new RedColor();
            Shape circle = new Circle(red);
            circle.Draw();

            IColor blue = new BlueColor();
            Shape square = new Square(blue);
            square.Draw();
        }
    }

}

