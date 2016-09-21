using Microsoft.Azure.WebJobs;

namespace CodeBlacks.WebJob
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }
    }
}
