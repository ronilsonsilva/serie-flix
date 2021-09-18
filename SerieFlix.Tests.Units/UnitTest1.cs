//using Moq;
//using System;
//using System.Collections.Generic;
//using Xunit;

//namespace SerieFlix.Tests.Units
//{
//    public class UnitTestExample
//    {

//        [Fact]
//        public void UnitTestExample1()
//        {
//            var myClassInterfaceMock = new Mock<IInterface<MyClass>>();
//            var instance = myClassInterfaceMock.Object;
//            var myList = new List<MyClass>()
//            {
//                new MyClass() { Attribute = 1 }
//            };

//            myClassInterfaceMock.Setup(_ => _.SomeMethod()).Returns(instance);
//            myClassInterfaceMock.Setup(_ => _.SomeSecondMethod()).Returns(instance);
//            myClassInterfaceMock.Setup(_ => _.GetData()).Returns(myList);

//            var myDependentClass = new MyDependentClass(instance);
//            var result = myDependentClass.DoTheThing();

//            Assert.True(result.Count.Equals(1));
//        }
//    }

//    public interface IInterface<T>
//    {
//        IInterface<T> SomeMethod();
//        IInterface<T> SomeSecondMethod();
//        List<T> GetData();
//    }

//    public class MyClass
//    {
//        public int Attribute { get; set; }
//    }

//    public class MyDependentClass
//    {
//        private readonly IInterface<MyClass> _test;

//        public MyDependentClass(IInterface<MyClass> test)
//        {
//            _test = test;
//        }

//        public List<MyClass> DoTheThing()
//        {
//            return _test.SomeMethod().SomeSecondMethod().GetData();
//        }
        
//    }

//}
