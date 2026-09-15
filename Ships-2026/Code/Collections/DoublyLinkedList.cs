using System.Collections;
using System.Collections.Generic;

namespace GA.Collections
{
	public class DoublyLinkedList<T> : ICollection<T>
	{
		protected class Node
		{
			public T Value { get; set; }
			public Node Next { get; set; }
			public Node Previous { get; set; }

			public Node() : this(default(T))
			{
			}

			public Node(T value, Node next = null, Node previous = null)
			{
				Value = value;
				Next = next;
				Previous = previous;
			}
		}

		/// <summary>
		/// The head of the linked list. When the list is empty, this will be null.
		/// </summary>
		protected Node Head { get; set; } = null;

		protected Node Tail { get; set; } = null;

		public int Count { get; private set; } = 0;

		public virtual bool IsReadOnly => false;

		public void Add(T item)
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("The collection is read-only.");
			}

			Node node = new Node(item);

			if (Head == null)
			{
				Head = node;
				Tail = node;
			}
			else
			{
				Tail.Next = node;
				node.Previous = Tail;
				Tail = node;
			}

			Count++;
		}

		public void Clear()
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("The collection is read-only.");
			}

			Head = null;
			Tail = null;
			Count = 0;
		}

		public bool Contains(T item)
		{
			Node current = Head;
			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Value, item))
				{
					return true;
				}

				current = current.Next;
			}

			return false;
		}

		public virtual void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotImplementedException("Not nesessary for this example :D");
		}

		public IEnumerator<T> GetEnumerator()
		{
			Node current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		public bool Remove(T item)
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("This collection is read-only");
			}

			Node current = Head;
			Node previous = null;
			Node next = current.Next;

			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Value, item))
				{
					if (previous != null)
					{
						if(next != null)
						{
							previous.Next = current.Next;
							current.Next.Previous = previous;
						}
						else
						{
							Tail = current.Previous;
							Tail.Next = null;
						}
					}
					else
					{
						if (next == null)
						{
							Tail = null;
						}

						Head = current.Next;

						if (Head != null)
						{
							Head.Previous = null;
						}
					}

					Count--;
					return true;
				}

				previous = current;
				current = current.Next;

				if (current != null)
				{
					next = current.Next;
				}
			}

			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}