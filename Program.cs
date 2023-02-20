List<string> TaskList = new List<string>();

    int menuSelected = 0;
    do
    {
        menuSelected = ShowMainMenu();

        if ((Menu)menuSelected == Menu.Add)
        {
            ShowMenuAdd();
        }
        else if ((Menu)menuSelected == Menu.Remove)
        {
            ShowMenuRemove();
        }
        else if ((Menu)menuSelected == Menu.List)
        {
            ShowMenuTaskList();
        }
    } while ((Menu)menuSelected != Menu.Exit);
    
    /// <summary>
    /// Show the main menu 
    /// </summary>
    /// <returns>Returns option indicated by user</returns>
    int ShowMainMenu()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Ingrese la opción a realizar: ");
        Console.WriteLine("1. Nueva tarea");
        Console.WriteLine("2. Remover tarea");
        Console.WriteLine("3. Tareas pendientes");
        Console.WriteLine("4. Salir");

        // Read line
        string userInput = Console.ReadLine();
        return Convert.ToInt32(userInput);
    }

    void ShowMenuRemove()
    {
        try
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");

            // Show current taks
            ShowTaskList();

            string userInput = Console.ReadLine();
            // Remove one position
            int indexToRemove = Convert.ToInt32(userInput) - 1;

            if (indexToRemove <= (TaskList.Count - 1) && indexToRemove >= 0)
            {
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string taskToRemove = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {taskToRemove} eliminada");
                }
            }
            else
            {
                Console.WriteLine("El valor que ha ingresado es invalido");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
        }
    }

    void ShowMenuAdd()
    {
        try
        {
            Console.WriteLine("Ingrese el nombre de la tarea: ");
            string taskToShow = Console.ReadLine();
            TaskList.Add(taskToShow);
            Console.WriteLine("Tarea registrada");
        }
        catch (Exception)
        {
        }
    }

    void ShowMenuTaskList()
    {
        if (TaskList?.Count > 0)
        {
            Console.WriteLine("No hay tareas por realizar");
        }
        else
        {
            ShowTaskList();
        }
    }

    void ShowTaskList()
    {
        var indexTask = 1;
        TaskList.ForEach(taskListItem => Console.WriteLine($"{indexTask++} .  {taskListItem}"));
        Console.WriteLine("----------------------------------------");
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
