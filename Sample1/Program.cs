// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.ComponentModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Library.ecommerce.services;
using Spring2025_SAMPLES.models;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("welcome to Amazon");
            
            Console.WriteLine("C. Create new inventory item ");
            Console.WriteLine("R. Read all inventory items");
            Console.WriteLine("U. update an inventory item");
            Console.WriteLine("D. delete an inventory item");
            Console.WriteLine("Q: Quit");

            List<Product?> list = ProductServiceProxy.Current.Products;
             
            char choice;
        
            do
            {

                string? input = Console.ReadLine();
                choice = input[0];
                
                switch (choice)
                {
                case 'C':
                case 'c' :      
                    ProductServiceProxy.Current.AddorUpdate(new Product
                    {
                        Name = Console.ReadLine()
                    });
                    list.Add(new Product
                    {
                        Name = Console.ReadLine()
                    });
                    break;
                case 'R':
                case 'r':
                    list.ForEach(Console.WriteLine);
                    break;
                case 'U':
                case 'u':
                    Console.WriteLine("Which product would you like to update");
                    int selection = int.Parse(Console.ReadLine() ?? "-1");
                    var selectedProd = list.FirstOrDefault(p => p.Id == selection);
                   if(selectedProd != null) 
                   { 
                    selectedProd.Name = Console.ReadLine() ?? "Error";
                    ProductServiceProxy.Current.AddorUpdate(selectedProd);
                   } 
                    break;
                case 'D':
                case 'd':
                    Console.WriteLine("Which product would you like to update");
                    selection = int.Parse(Console.ReadLine() ?? "-1");
                    selectedProd = list.FirstOrDefault(p => p.Id == selection);
                   list.Remove(selectedProd);
                   break;
                case 'Q':
                case 'q':
                    break;
                default:
                    Console.WriteLine("Error. unkown command");
                    break;
                }

            } while(choice != 'Q' && choice != 'q');

            Console.ReadLine();   
        }
    }
}