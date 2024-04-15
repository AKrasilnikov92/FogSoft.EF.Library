using FogSoft.EF.Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Task = FogSoft.EF.Library.Entities.Task;

namespace FogSoft.EF.Library
{
    public class Program
    {
        public static void Main()
        {

            //using ApplicationContext context = new();
            //User tom = new() { Name = "Tom" };
            //User pete = new() { Name = "Pete" };
            //User jack = new() { Name = "Jack" };
            //User nick = new() { Name = "Nick" };
            //context.Users.AddRange(tom, pete, jack, nick);


            //Task swim = new() { Subject = "Плавание", Description = "Плавай" };
            //Task run = new() { Subject = "Бег", Description = "Бегай" };
            //context.Tasks.AddRange(swim, run);
            //context.SaveChanges();

            TaskManager taskManager = new();
            
            taskManager.AssignUser(2,2);
            taskManager.AssignUser(1,2);

        }
    }
}
