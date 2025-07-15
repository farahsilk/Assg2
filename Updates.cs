using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using UniApp1.Contexts;
using UniApp1.Entities;
using static System.Formats.Asn1.AsnWriter;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public static class Updates
{
    public static void Editing()
    {
        using (var context = new UniApp1DbContext())
        {
            var user = context.Users.Where(s => s.Role=="Student" ).ToList();
            foreach (var s in user)
            {
                s.Role = "Teacher";
            }

            context.SaveChanges();



            //Delete a specific comment

            var comment = context.Comments.FirstOrDefault();

            context.Comments.Remove(comment);
            context.SaveChanges();
            Console.WriteLine($"Comment 1 has been deleted.");




        }
    }
}