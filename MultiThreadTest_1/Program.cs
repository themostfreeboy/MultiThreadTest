using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;//多线程使用

namespace MultiThreadTest_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myPro = new Program();

            #region 线程一定义
            Thread one = new Thread(new ThreadStart(myPro.Count));
            one.Name = "myThreadOne";//线程一的名字
            #endregion

            #region 线程二定义
            Thread two = new Thread(new ThreadStart(myPro.Count));
            two.Name = "myThreadTwo";//线程二的名字
            #endregion

            #region 线程三定义
            Thread three = new Thread(new ThreadStart(myPro.Count));
            three.Name = "myThreadThree";//线程三的名字
            #endregion

            one.Start();//线程一启动
            two.Start();//线程二启动
            three.Start();//线程三启动

            Thread.Sleep(500);//线程休眠500毫秒(挂起500毫秒)

            one.Suspend();//线程一挂起

            three.Abort();//线程三终止

            two.Join();//等待线程二被杀，线程二被杀后，此方法返回

            one.Resume();//恢复线程一(之前被挂起)

            Console.ReadKey();
        }

        public void Count()//定义一个方法
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("{0}:{1}", Thread.CurrentThread.Name, i);
                    Thread.Sleep(200);//休眠200毫秒(挂起200毫秒)
                }
            }
            catch (ThreadAbortException ex)//线程终止
            {
                Console.WriteLine(ex.Message);//显示异常信息
                Thread.ResetAbort();//取消异常终止
            }
            Console.WriteLine(Thread.CurrentThread.Name + ":out of for loop");//线程结束循环
        }
    }
}
