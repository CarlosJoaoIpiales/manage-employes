using System;
// Libreria para usar las listas
using System.Collections.Generic;

// Definición de la interfaz
public interface IMostrarInformacion
{
    void MostrarInformacion();
}

// Definición de la clase Empleado
public class Empleado : IMostrarInformacion
{
    // Atributos de la clase
    public string Nombre { get; set; }
    public double Salario { get; set; }

    // Constructor
    public Empleado(string nombre, double salario)
    {
        Nombre = nombre;
        Salario = salario;
    }

    // Método para calcular el salario anual
    public double CalcularSalarioAnual()
    {
        return Salario * 12;
    }

    // Implementación del método de la interfaz
    public void MostrarInformacion()
    {
        Console.WriteLine($"Empleado: {Nombre}, Salario: {Salario:C}, Salario Anual: {CalcularSalarioAnual():C}");
    }
}

// Definición de la clase Gerente que hereda de Empleado
public class Gerente : Empleado, IMostrarInformacion
{
    // Nuevo atributo para el departamento
    public string Departamento { get; set; }

    // Constructor
    public Gerente(string nombre, double salario, string departamento)
        : base(nombre, salario)
    {
        Departamento = departamento;
    }

    // Implementación del método de la interfaz
    public new void MostrarInformacion()
    {
        Console.WriteLine($"Gerente: {Nombre}, Salario: {Salario:C}, Salario Anual: {CalcularSalarioAnual():C}, Departamento: {Departamento}");
    }
}

class Program
{
    static void Main()
    {
        // Bucle para mostrar las opciones
        int opcion = 0;

        // Declaramos un array dinamico para tener una lista de empleados
        List<Empleado> listaEmpleados = new List<Empleado>();


        do
        {
            bool esNumero;
            Console.WriteLine("********Bienvenidos al sistema de gestion de empleados");
            Console.WriteLine("1.- Agregar Empleado");
            Console.WriteLine("2.- Mostrar Empleados");
            Console.WriteLine("3.- Salir");
            do
            {
                Console.Write("Ingrese la opcion que desea: ");
                esNumero = int.TryParse(Console.ReadLine(), out opcion);

                if (!esNumero)
                {
                    Console.WriteLine("Error: Por favor, ingrese una opcion valida....");

                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();

                    // Borrar la consola
                    Console.Clear();
                }

            } while (!esNumero);
            // Borrar la consola
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("**********Ingreso de nuevo empleado**************");
                    Console.WriteLine("Ingrese el nombre del nuevo empleado: ");
                    string nombre = Console.ReadLine();

                    double salario;
                    bool justNumber;

                    do
                    {
                        Console.Write("Ingrese el salario del empleado: ");
                        // Comprobamos si el salario ingresado es un numero ya sea entero o decimal
                        justNumber = double.TryParse(Console.ReadLine(), out salario);

                        if (!justNumber)
                        {
                            Console.WriteLine("Error: Por favor, ingrese un valor entero para el salario.");
                        }

                    } while (!justNumber);

                    Empleado nuevoEmpleado = new Empleado(nombre, salario);
                    listaEmpleados.Add(nuevoEmpleado);

                    Console.WriteLine($"Empleado agregado: Nombre: {nuevoEmpleado.Nombre}, Salario: {nuevoEmpleado.Salario}");
                    Console.WriteLine("Pulse cualquier tecla para regresar al menu principal");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    // Borrar la consola
                    Console.Clear();
                    break;
                case 2:
                    // Mostrar lista de empleados
                    Console.WriteLine("**************** Lista de empleados ******************");
                    int flag = 1;
                    foreach (IMostrarInformacion empleado in listaEmpleados)
                    {
                        Console.Write($"{flag++}.- ");
                        empleado.MostrarInformacion();
                    }
                    Console.WriteLine("Pulse cualquier tecla para regresar al menu principal");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    // Borrar la consola
                    Console.Clear();
                    break;
                case 3:
                    Console.WriteLine("Gracias por preferirnos :)");
                    Console.WriteLine("Pulse cualquier tecla para salir");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Gracias por preferirnos :)");
                    Console.WriteLine("Pulse cualquier tecla para salir");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 3);

    }
}

