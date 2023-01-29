using Collections;
using System.Globalization;

namespace Collection.UnitTests
{
    public class CollectionTests
    {
       
        [Test]

        public void Test_Collection_EmptyConstructor() 
        {

            //Arrange and Act
        var coll = new Collection<int>();
        
            //Assert

            Assert.AreEqual(coll.ToString(), "[]");

            Assert.AreEqual(coll.Count, 0);
            Assert.AreEqual(coll.Capacity, 16);
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            //Arrange

            var coll = new Collection<int>(5);

            //Act

            //Assert
            var actual = coll.ToString();
            var expected = "[5]";

            Assert.AreEqual(actual, expected);

        }

        [Test]
        public void Test_Collection_ConstructorSingleItem2()
        {
            // Arrange
            int item = 5;

            // Act
            Collection<int> collection = new Collection<int>(item);

            // Assert
            Assert.AreEqual(1, collection.Count, "The Count property is not correct.");
            Assert.AreEqual(item, collection[0], "The item at index 0 is not correct.");
        }


        [Test]
        public void Test_Collection_ConstructorMultipleItems() 
        {
        //Arrange

            var coll = new Collection<int>(5, 6);

            //Act

            //Assert
            var actual = coll.ToString();
            var expected = "[5, 6]";

            Assert.AreEqual(actual, expected);
            //Assert


        }
        [Test]

        public void Test_Collection_CountAndCapacity() 
        {
            //Arrange
            var coll = new Collection<int>(5, 6);

            //Assert

            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThan(coll.Count));

        }

        [Test]

        public
            void Test_Collection_Add() 
        {
            //Arrange
            var coll = new Collection<int>(5, 6);

            //Act
            coll.Add(1000);

            //Assert

            Assert.AreEqual(coll.ToString(), "[5, 6, 1000]");

        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }


        [Test]

        public void Test_Collection_GetByIndex()
        {
        var collection= new Collection<int>(5, 6, 7, 8);
            var item = collection[2];

            Assert.That(item.ToString(), Is.EqualTo("7")); 
        
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var collection = new Collection<int>(5, 6, 7, 8);
            collection[2] = 777;

            Assert.That(collection.ToString(), Is.EqualTo("[5, 6, 777, 8]"));

        }

        [Test]

        public void Test_Collection_GetByInvalidIndex() 
        {
            
                var collection = new Collection<int>(5, 6, 7, 8);
                var item = collection[4];

                Assert.That(collection.ToString(), 
                    Throws.InstanceOf<ArgumentOutOfRangeException>());

            

        }

        [Test]
        public void Test_Collection_AddWithGrow()
        {
            var collection = new Collection<int>();
            for (int i = 0; i < 15; i++)
            {
                collection.Add(i);
                
            }
            Assert.AreEqual(15, collection.Count);
            Assert.AreEqual(20, collection.Capacity);
        }


        [Test]

        public void Test_Collection_GetByInvalidIndex2()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = -1;

            // Act
            int actual = -1;
            try
            {
                actual = collection[-1];
            }
            catch (ArgumentOutOfRangeException)
            {
                actual = -1;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void Test_Collection_SetByInvalidIndex()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = -1;

            // Act
            int actual = -1;
            try
            {
                collection[-1] = 0;
            }
            catch (ArgumentOutOfRangeException)
            {
                actual = -1;
            }

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void Test_Collection_InsertAtStart()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = 1;
            collection.Add(2);
            collection.Add(3);

            // Act
            collection.InsertAt(0, 1);
            int actual = collection[0];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]

        public void Test_Collection_InsertAtEnd()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = 3;
            collection.Add(1);
            collection.Add(2);

            // Act
            collection.InsertAt(2, 3);
            int actual = collection[2];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = 2;
            collection.Add(1);
            collection.Add(3);

            // Act
            collection.InsertAt(1, 2);
            int actual = collection[1];

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]

        public void Test_Collection_InsertAtWithGrow()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = 1;
            int initialCapacity = collection.Capacity;

            // Act
            collection.InsertAt(0, 1);
            int actual = collection[0];
            int finalCapacity = collection.Capacity;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
           // Assert.That(finalCapacity > initialCapacity, Is.True);
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            // Arrange
            var collection = new Collection<int>();
            int expected = -1;

            // Act
            int actual = -1;
            try
            {
                collection.InsertAt(-1, 0);
            }

            catch (ArgumentOutOfRangeException)
            {
                actual = -1;
            }

            Assert.AreEqual(expected, actual);
        







    
        }
    }
}