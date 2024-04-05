using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Welcome to this solution of Assignment 3.");

            string testFile = @"..\..\testUser.bin";

            List<User> userList = new List<User>();

            SLL linkedList= new SLL();

            //Prepend an item to the beginning of the linked list.
            linkedList.AddFirst(new User(1, "Miranda Jeffeson", "mirandajefferson@gmail.com", "passmiranda"));
            linkedList.AddFirst(new User(2, "Mark Cuban", "markcuban@gmail.com", "passmark"));
            linkedList.AddFirst(new User(3, "Dani Fernandez", "danifernandez@gmail.com", "passdani"));

            Console.WriteLine("Three Users suceessfully added to LinkedList");
            linkedList.DisplayList();

            //Append an item to the end of the linked list.
            linkedList.AddLast(new User(4, "Juan smith", "juansmith@gmail.com", "passjuan"));
            Console.WriteLine("LinkedList Appended, Juan Added");
            linkedList.DisplayList();

            //Remove an item at an index in the linked list.
            linkedList.Remove(3);
            Console.WriteLine($"\nSize of the linked list after removal of node 3 user is {linkedList.Count()}");

            //Remove an item from the start of the linked list
            linkedList.RemoveFirst();
            Console.WriteLine($"\nSize of the linked list after the removal of user at first node is {linkedList.Count()}");

            //Remove an item from the end of the linked list
            linkedList.RemoveLast();
            Console.WriteLine($"\nSize of the linked list after the removal of user at last node is {linkedList.Count()}");

            //Insert an item at a specific index in the linked list
            linkedList.Add(new User(1, "Brent Williams", "brentwilliams@gmail.com", "passbrent"), 1);
            Console.WriteLine("LinkedList Updated, Brent added at the 1st node");
            linkedList.DisplayList();

            //Replace an item in the linked list.
            linkedList.Replace(new User(6, "Valentine Cutler", "valentinecutler@gmail.com", "passvalentine"), 3);
            Console.WriteLine("Replace Test completed, Valentine replaced Dani at the third node");
            linkedList.DisplayList();

            //Get an item at an index in the linked list.
            User UserDetailbyIndex = (User)linkedList.GetValue(1);
            Console.WriteLine($"\nUser at index 2 is {UserDetailbyIndex.Name}");

            //Get the index of an item in the linked list.
            int index = linkedList.IndexOf(UserDetailbyIndex);
            Console.WriteLine($"\nIndex of {UserDetailbyIndex.Name} is {index}");

            //Check if the linked list has an item.
            bool DoesContainUSer = linkedList.Contains(UserDetailbyIndex);
            Console.WriteLine($"\nList Contains {UserDetailbyIndex.Name}: {DoesContainUSer}");

            //Clear all items in the linked list.
            linkedList.Clear();
            Console.WriteLine($"Size of the linked list after clearance is {linkedList.Count()}");

            //Get the number of items in the linked list.
            Console.WriteLine($"\nCurrent size of the linked list is {linkedList.Count()}");

            //Reverse the order of the nodes in the linked list.
            linkedList.Reverse();
            linkedList.DisplayList();


            //Serialization Test
            Console.WriteLine("Serialization Test...");
            linkedList.serializeUser(testFile);


            //Deserialization Test
            Console.WriteLine("User Deserialization Test...");
            linkedList.deserializeUser(testFile);
            Console.WriteLine($"Size of the linked list after deserializing objects from file is {linkedList.Count()}\n");

            linkedList.DisplayList();

            Console.WriteLine("\nPress any key to end the test.");

            Console.ReadKey();

        }
    }
}
