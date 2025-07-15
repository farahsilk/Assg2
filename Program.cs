using UniApp1.Contexts;

using (var context = new UniApp1DbContext())
{
    AddData.InsertUsers(context);

    //I only ran the functions for ID = 1

    Updates.Editing();

    Queries.Listing();
    Queries.ListAssignments();
    Queries.ListAllStudents();
    Queries.ShowAssignments();
    Queries.ShowComments();
    Queries.ShowGrades();
    Queries.ShowAverageGrade();
    Queries.GetLetterGrade();
    Queries.CalculateGPA();

}