using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

using System.Threading;

namespace LuceneDemo.Code
{
    public class LuceneBackground
    {
        public static readonly LuceneBackground Instance = new LuceneBackground();
        
        //请求队列 解决索引目录同时操作的并发问题
        private Queue<string> TaskQueue = new Queue<string>();
        public void Add(string data)
        {
            TaskQueue.Enqueue(data);
        }


        public void StartTaskListener()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(QueueToIndex));
        }

        //定义一个线程 将队列中的数据取出来 插入索引库中
        private void QueueToIndex(object para) {
            while(true) {
                if (TaskQueue.Count > 0)
                {
                    TaskWork();
                }
                else 
                {
                    Debug.WriteLine("空闲等待……");
                    Thread.Sleep(3000);
                }
            }
        }
        
        private void TaskWork()
        {
            Debug.WriteLine(TaskQueue.Count);
            string data = TaskQueue.Dequeue();
        }

    }

    
}