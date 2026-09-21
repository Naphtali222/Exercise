using GA.Collections;
using Xunit;

public class PriorityQueueTests
{
    [Fact]
    public void TestEnqueue()
    {
        PriorityQueue<int> queue = new PriorityQueue<int>();

        queue.Enqueue(0);

        Assert.True(queue.Contains(0));
    }

    [Fact]
    public void TestEnqueueOrder()
    {
        PriorityQueue<int> queue = new PriorityQueue<int>();

        queue.Enqueue(75);
        queue.Enqueue(55);
        queue.Enqueue(78);
        queue.Enqueue(140);
        queue.Enqueue(36);
        queue.Enqueue(78);

        Assert.Equal(36, queue.Peek());
    }

    [Fact]
    public void TestDequeue()
    {
        PriorityQueue<int> queue = new PriorityQueue<int>();

        queue.Enqueue(75);
        queue.Enqueue(140);
        queue.Enqueue(78);

        Assert.Equal(3, queue.Count);
        Assert.Equal(75, queue.Dequeue());
        Assert.Equal(78, queue.Dequeue());
        Assert.Equal(140, queue.Dequeue());
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void TestClear()
    {
        PriorityQueue<int> queue = new PriorityQueue<int>();

        queue.Enqueue(75);
        queue.Enqueue(55);
        queue.Enqueue(78);

        Assert.Equal(3, queue.Count);

        queue.Clear();

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void TestContains()
    {
        PriorityQueue<int> queue = new PriorityQueue<int>();

        Assert.False(queue.Contains(0));

        queue.Enqueue(0);

        Assert.True(queue.Contains(0));
    }
}