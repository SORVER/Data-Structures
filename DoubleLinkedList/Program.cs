using System;
namespace DoubleLinkedList
{
    class node
    {
        public int data;

        public node next;
        public node prev;

        public node(int d)
        {
            data = d;
            next = prev = null;
        }

    }
    class doubleLinkedList
    {
        node head;

        public void insertAtFornt(int d)
        {
            if (head == null)
            {
                head = new node(d);
                return;
            };

            node temp = new node(d);
            temp.next = head;
            head.prev = temp;
            head = temp;

        }

        public void insertAtEnd(int d)
        {
            if (head == null)
            {
                head = new node(d);
                return;
            }

            node p = head;
            node temp = new node(d);

            while (p.next != null)
            {
                p = p.next;
            }
            p.next = temp;
            temp.prev = p.next;

        }

        public void createList(int num, int min, int max)
        {

            Random randomItem = new Random();
            int item;
            for (int i = 0; i < num; i++)
            {
                item = randomItem.Next(min, max);
                this.insertAtEnd(item);

            }

        }

        public void printList()
        {
            node p = head;
            while (p != null)
            {
                Console.WriteLine(p.data);
                p = p.next;
            }
        }
        public int count()
        {
            node p = head;
            int co = 0;
            while (p != null)
            {
                co++;
                p = p.next;

            }
            return co;
        }

        public int search(int d)
        {
            node p = head;
            int co = 0;
            while (p != null)
            {
                if (p.data == d)
                {
                    return co + 1;
                }
                co++;
                p = p.next;

            }
            return -1;

        }

        public void insertBefore(int nodeData, int d)
        {
            node p = head;

            if (head.data == d)
            {
                this.insertAtFornt(nodeData);
                return;
            }
            node newNode = new node(nodeData);
            while (p.next != null)
            {
                if (p.next.data == d)
                {
                    newNode.next = p.next;
                    newNode.prev = p;
                    p.next.prev = newNode;
                    p.next = newNode;

                    return;
                }
                p = p.next;
            }
            Console.WriteLine($"I cant find node with {d} data");

        }

        public void insertAfter(int nodeData, int d)
        {
            node p = head;
            node newNode = new node(nodeData);

            while (p != null)
            {
                if (p.data == d)
                {
                    newNode.next = p.next;
                    newNode.prev = p;
                    p.next = newNode;
                    return;
                }
                p = p.next;
            }
            Console.WriteLine($"there's no node with data to insert after it {d}");

        }

        public void insertAtPos(int nodeData, int pos)
        {
            node newNode = new node(nodeData);
            node p = head;
            int co = 1;
            while (co != pos)
            {
                p = p.next;
                if (p == null)
                {
                    Console.WriteLine($"I can't find the pos {pos}");
                    return;
                }
                co++;
            }
            p.data = nodeData;
        }
        public void deleteNode(int d)
        {
            if (this.search(d) != -1)
            {
                node p = head;

                if (head.data == d)
                {
                    head = head.next;
                    return;
                }
                while (p != null)
                {
                    if (p.next == null)
                    {
                        p.prev.next = null;
                        return;
                    }
                    if (p.data == d)
                    {
                        p.next.prev = p.prev;
                        p.prev.next = p.next;
                        return;

                    }
                    p = p.next;
                }
            }
        }
        public void reverseList()
        {
            node p1 = head, p2 = head.next;
            p1.prev = p2;
            p1.next = null;
            while (p2 != null)
            {
                p2.prev = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p2.prev;

            }
            head = p1;

        }
    }
    class program
    {
        public static void Main()
        {

            doubleLinkedList list = new doubleLinkedList();
            while (true)
            {
                Console.WriteLine("1.Create List");
                Console.WriteLine("2.Display List");
                Console.WriteLine("3.Count");
                Console.WriteLine("4.Search");
                Console.WriteLine("5.Add to empty list / Add at beginning");
                Console.WriteLine("6.Add at end");
                Console.WriteLine("7.Add after node");
                Console.WriteLine("8.Add before node");
                Console.WriteLine("9.Add at position");
                Console.WriteLine("10.Delete");
                Console.WriteLine("11.Reverse");
                Console.WriteLine("12.Quit\n");

                Console.Write("Enter your choice : ");

                int choice = int.Parse(Console.ReadLine());
                int data = 0;
                int item;
                int pos;
                switch (choice)
                {
                    case 1:
                        list.createList(10, 1, 100);
                        break;
                    case 2:
                        list.printList();
                        break;
                    case 3:
                        Console.WriteLine(list.count());
                        break;
                    case 4:
                        Console.Write("Enter the element to be searched: ");
                        data = int.Parse(Console.ReadLine());
                        int res = list.search(data);
                        if (res == -1)
                        {
                            Console.WriteLine("not found");
                        }
                        else
                        {
                            Console.WriteLine($"it's found at pos {res}");
                        }

                        break;
                    case 5:
                        Console.Write("Enter the element to be inserted: ");
                        data = int.Parse(Console.ReadLine());
                        list.insertAtFornt(data);
                        break;
                    case 6:
                        Console.Write("Enter the element to be inserted: ");
                        data = int.Parse(Console.ReadLine());
                        list.insertAtEnd(data);
                        break;
                    case 7:
                        Console.Write("Enter the element to be inserted: ");
                        data = int.Parse(Console.ReadLine());
                        Console.Write("Enter the element after which to insert: ");
                        item = int.Parse(Console.ReadLine());
                        list.insertAfter(data, item);
                        break;
                    case 8:
                        Console.Write("Enter the element to be inserted: ");
                        data = int.Parse(Console.ReadLine());
                        Console.Write("Enter the element before which to insert: ");
                        item = int.Parse(Console.ReadLine());
                        list.insertBefore(data, item);
                        break;
                    case 9:
                        Console.Write("Enter the element to be inserted: ");
                        data = int.Parse(Console.ReadLine());
                        Console.Write("Enter the position at which to insert: ");
                        pos = int.Parse(Console.ReadLine());
                        list.insertAtPos(data, pos);
                        break;
                    case 10:
                        Console.Write("Enter the element to be deleted: ");
                        data = int.Parse(Console.ReadLine());
                        list.deleteNode(data);
                        break;
                    case 11:
                        list.reverseList();
                        break;
                    case 12:
                        return;

                }
            }
        }
    }
}