using System;

namespace org.tsu.famc.ds.stack
{

    public class EStackEmpty : Exception
    {
        public EStackEmpty()
            : this("Stack is empty")
        {
        }

        public EStackEmpty(String message)
            : base(message)
        {
        }
    }

    internal class StackItem
    {
        private object data;
        private StackItem next;
        private StackItem prev;

        public StackItem(object argData)
        {
            data = argData;
        }

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public StackItem Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public StackItem Next
        {
            get { return next; }
            set { next = value; }

        }
            
    }

    public class Stack
    {
        private StackItem head;
        int count;

        public Stack()
        {
            count = 0;
            head = null;
        }

        public Stack(Stack stack)
        {
            count = stack.Count;
            if (count == 0)
            {
                head = null;
                return;
            }
            head = new StackItem(stack.head.Data);
            StackItem i = stack.head.Prev;
            StackItem next = head;
            while (i != null)
            {
                StackItem tmp = new StackItem(i.Data);
                tmp.Next = next;
                next.Prev = tmp;
                next = tmp;
                i = i.Prev;
            }
        }

        public void Push(Object obj)
        {
            StackItem newItem = new StackItem(obj);
            newItem.Prev = head;
            head = newItem;
            count++;
        }

        public Object Pop()
        {
            if (head == null)
            {
                throw new EStackEmpty("Stack is empty");
            }
            object ret = head.Data;
            head = head.Prev;
            if (head != null)
                head.Next = null;
            count--;
            return ret;
        }

        public Object Top()
        {
            if (head == null)
            {
                throw new EStackEmpty("Stack is empty");
            }
            return head.Data;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
