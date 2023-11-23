using System;
// Libreria para usar las listas
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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

// Definicion para el control de entradas de nummeros
public class Controladores
{
    public double NumerosDecimales( string text)
    {
        bool justNumber;
        double number;
        do
        {
            Console.Write(text);
            // Comprobamos si el salario ingresado es un numero ya sea entero o decimal
            justNumber = double.TryParse(Console.ReadLine(), out number);

            if (!justNumber)
            {
                Console.WriteLine("Error: Por favor, ingrese un valor entero para el salario.");
            }

        } while (!justNumber);
        return number;
    }

    public int NumeroEntero ( string text)
    {
        int number = 0;
        bool esNumero;
        do
        {
            Console.Write(text);
            esNumero = int.TryParse(Console.ReadLine(), out number);

            if (!esNumero)
            {
                Console.WriteLine("Error: Por favor, ingrese una opcion valida....");

                // Esperamos a que el usuario presione una tecla
                Console.ReadKey();

                // Borrar la consola
                Console.Clear();
            }

        } while (!esNumero);
        return number;
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

        // Declaramos un array dinamico para tener una lista de gerente
        List<Gerente> listaGerentes = new List<Gerente>();

        // Instanciamos el controlador para comprobar numeros decimales
        Controladores controlador = new Controladores();


        do
        {
            Console.WriteLine("********Bienvenidos al sistema de gestion de empleados");
            Console.WriteLine("1.- Agregar Empleado");
            Console.WriteLine("2.- Agregar Gerente");
            Console.WriteLine("3.- Mostrar Empleados");
            Console.WriteLine("4.- Mostrar Gerentes");
            Console.WriteLine("5.- Salir");
            // Nos aseguramos de que sea un numero entero
            opcion = controlador.NumeroEntero("Ingrese la opcion que desea: ");
            // Borrar la consola
            Console.Clear();
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("**********Ingreso de nuevo empleado**************");
                    Console.WriteLine("Ingrese el nombre del nuevo empleado: ");
                    string nombre = Console.ReadLine();

                    // Comprobamos si el salario es un numero entero o decimal
                    double salario = controlador.NumerosDecimales("Ingrese el salario del empleado: ");
                    
                    // Instanciamos un nuevo empleado y lo agregamos a la lista
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
                    Console.WriteLine("**********Ingreso de nuevo Gerente**************");
                    Console.WriteLine("Ingrese el nombre del nuevo gerente: ");
                    nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el departamento del gerente: ");
                    string departamento = Console.ReadLine();

                    // Comprobamos si el salario es un numero entero o decimal
                    salario = controlador.NumerosDecimales("Ingrese el salario del gerente: ");

                    // Instanciamos un nuevo empleado y lo agregamos a la lista
                    Gerente nuevoGerente = new Gerente(nombre, salario, departamento);
                    listaEmpleados.Add(nuevoGerente);

                    Console.WriteLine($"Gerente agregado: Nombre: {nuevoGerente.Nombre}, Salario: {nuevoGerente.Salario}, Departamento: {nuevoGerente.Departamento}");
                    Console.WriteLine("Pulse cualquier tecla para regresar al menu principal");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    // Borrar la consola
                    Console.Clear();
                    break;
                case 3:
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
                case 4:
                    // Mostrar lista de empleados
                    Console.WriteLine("**************** Lista de gerentes ******************");
                    flag = 1;
                    foreach (IMostrarInformacion gerente in listaGerentes)
                    {
                        Console.Write($"{flag++}.- ");
                        gerente.MostrarInformacion();
                    }
                    Console.WriteLine("Pulse cualquier tecla para regresar al menu principal");
                    // Esperamos a que el usuario presione una tecla
                    Console.ReadKey();
                    // Borrar la consola
                    Console.Clear();
                    break;
                case 5:
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
        } while (opcion != 5);

    }
}

