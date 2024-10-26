using System;
using System.Collections.Generic;


public class ToDoItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
}


public class Program
{
    private static List<ToDoItem> toDoList = new List<ToDoItem>();
    private static int nextId = 1; 

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nToDo List Menu:");
            Console.WriteLine("1. Add ToDo");
            Console.WriteLine("2. List ToDos");
            Console.WriteLine("3. Update ToDo");
            Console.WriteLine("4. Delete ToDo");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddToDo();
                    break;
                case "2":
                    ListToDos();
                    break;
                case "3":
                    UpdateToDo();
                    break;
                case "4":
                    DeleteToDo();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddToDo()
    {
        Console.Write("Enter Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Due Date: ");
        DateTime dueDate = DateTime.Parse(Console.ReadLine());

        ToDoItem newItem = new ToDoItem
        {
            Id = nextId++,
            Description = description,
            DueDate = dueDate,
            IsDone = false
        };

        toDoList.Add(newItem);
        Console.WriteLine("ToDo item added successfully.");
    }

    private static void ListToDos()
    {
        Console.WriteLine("\nToDo List:");
        foreach (var item in toDoList)
        {
            Console.WriteLine($"ID: {item.Id}, Description: {item.Description}, Due Date: {item.DueDate.ToShortDateString()}, Is Done: {item.IsDone}");
        }
    }

    private static void UpdateToDo()
    {
        Console.Write("Enter ToDo ID to update: ");
        int id = int.Parse(Console.ReadLine());

        ToDoItem item = toDoList.Find(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("ToDo item not found.");
            return;
        }

        Console.Write("Enter new description: ");
        item.Description = Console.ReadLine();

        Console.Write("Mark as done? (y/n): ");
        string isDone = Console.ReadLine();
        item.IsDone = isDone.ToLower() == "y";

        Console.WriteLine("ToDo item updated successfully.");
    }

    private static void DeleteToDo()
    {
        Console.Write("Enter ToDo ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        ToDoItem item = toDoList.Find(t => t.Id == id);
        if (item == null)
        {
            Console.WriteLine("ToDo item not found.");
            return;
        }

        toDoList.Remove(item);
        Console.WriteLine("ToDo item deleted successfully.");
    }
}