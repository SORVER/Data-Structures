using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    internal class doubleLinkedList
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
}
