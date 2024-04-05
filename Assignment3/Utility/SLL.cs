using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility 
{
    public class SLL : ILinkedListADT
    {
        public Node Head;

        public void Add(User value, int index)
        {
            Node tempNode = Head;
            Node newNode = new Node(value);

            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            if (Head == null)
            {
                // If there are no nodes on the list, add the User as head.
                Head = new Node(value);
                return;
            }

            if (index == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            int currentIndex = 0;

            while (tempNode != null && currentIndex < index - 1)
            {
                tempNode = tempNode.Next;
                currentIndex++;
            }

            if (tempNode == null || tempNode.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            
            newNode.Next = tempNode.Next;
            tempNode.Next = newNode;
        }

        public void AddFirst(User value)
        {  
            Node newNode = new Node(value);

            newNode.Next = Head;
            Head = newNode;

        }

        public void DisplayList()
        {
          
            Node tempNode = Head;
            int count = 0;

            while (tempNode != null)
            {
                count++;
                Console.WriteLine($"{count}. {tempNode.Data.Name}");
                tempNode = tempNode.Next;
            }
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            Node tempNode = Head;

            if(Head == null)
            {
                Head = newNode;
                return;
            }

            while (tempNode.Next != null) 
            {
                tempNode = tempNode.Next;
            }

            tempNode.Next = newNode;
        }

        public void Clear()
        {
            Head = null;
        }

        public bool Contains(User value)
        {
            bool isUserOnList = false;
            Node tempNode = Head;

            while (tempNode != null)
            {
                if (tempNode.Data.Equals(value))
                {
                    isUserOnList = true;
                    break;
                }

                tempNode = tempNode.Next;
            }

            return isUserOnList;
        }

        public int Count()
        {
            int count = 0;
            Node tempNode = Head;

            while (tempNode != null)
            {
                count++;
                tempNode = tempNode.Next;
            }

            return count;
        }

        public User GetValue(int index)
        {
            Node tempNode = Head;
            int currentIndex = 0;
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }
            if(Head == null)
            {
                throw new Exception("This is a Empty List");
            }
            while(tempNode != null)
            {
                if(currentIndex == index)
                {
                    User foundUser = tempNode.Data;
                    Console.WriteLine($"Name: {foundUser.Name}\nEmail: {foundUser.Email}\nId: {foundUser.Id} \n");

                    return foundUser;
                }

                tempNode = tempNode.Next;
                currentIndex++;
            }
            return null;
        }

        public int IndexOf(User value)
        {
            int count = 0;
            Node tempNode = Head;

            while (tempNode != null)
            {
                if (tempNode.Data.Equals(value))
                {
                    return count; 
                }
                count++;
                tempNode = tempNode.Next;
            }

            Console.WriteLine($"The index of {value.Id}. {value.Name} was not found.");
            return -1;
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;

            if (Head != null) { isEmpty = false; }

            return isEmpty;
        }

        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            if (Head == null)
            {
                throw new Exception("This is an empty list");
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            Node tempNode = Head;

            int currentIndex = 0;

            while (tempNode != null && currentIndex < index - 1)
            {
                tempNode = tempNode.Next;
                currentIndex++;
            }

            if (tempNode == null || tempNode.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            tempNode.Next = tempNode.Next.Next;
        }

        public void RemoveFirst()
        {
           if (Head == null)
            {
                throw new Exception("This is an Empty List");
            }
           Node tempNode = Head;
            tempNode = tempNode.Next;
           Head = tempNode;

        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new Exception("This is an empty list");
            }

            Node tempNode = Head;
            Node previousNode = null;
            while(tempNode.Next != null)
            {
                previousNode = tempNode;
                tempNode = tempNode.Next;
            }
            previousNode.Next = null;
        }

        public void Replace(User value, int index)
        {
            Node tempNode = Head;

            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            if (Head == null)
            {
                throw new Exception("This is an empty list");
            }

            if (index == 0)
            {
                Head.Data = value;
                return;
            }

            int currentIndex = 0;

            while (tempNode != null && currentIndex < index - 1)
            {
                tempNode = tempNode.Next;
                currentIndex++;
            }

            if (tempNode == null || tempNode.Next == null)
            {
                throw new IndexOutOfRangeException("Index is out of bounds!");
            }

            tempNode.Next.Data = value;
        }

        public void serializeUser(string FileName)
        {
            Node current = Head;
            List<User> users = new List<User>();
            while (current != null)
            {
                users.Add((User)current.Data);
                current = current.Next;
            }

            SerializationHelper.SerializeUsers(users, FileName);
            Console.WriteLine("Serialization Completed...");
        }

        public void deserializeUser(string FileName)
        {
            this.Clear();

            List<User> users = (List<User>)SerializationHelper.DeserializeUsers(FileName);

            foreach (User user in users)
            {
                this.AddLast(user);
            }
               
            Console.WriteLine("User Deserialization Completed...");
        }

        // Special Method - Reverse List
        public void Reverse() 
        {
            int count = Count();
            int index = 1;
            Node tempNode = Head;

            while (count > 0)
            {
                AddFirst(tempNode.Data);
                Remove(index);
                tempNode = tempNode.Next;
                count--;
                index++;
            }
        }
    }
}
