﻿/*
Challenge 1. Given a jagged array of integers (two dimensions).
Find the common elements in the nested arrays.
Example: int[][] arr = { new int[] {1, 2}, new int[] {2, 1, 5}}
Expected result: int[] {1,2} since 1 and 2 are both available in sub arrays.
*/

int[] CommonItems(int[][] jaggedArray)
{
  HashSet<int> duplicates = new HashSet<int>(jaggedArray[0]);
  for (int i = 1; i < jaggedArray.Length; i++)
  {
    duplicates.IntersectWith(jaggedArray[i]);
  }
  return duplicates.ToArray();
}
int[][] arr1 = { new int[] { 1, 2 }, new int[] { 2, 1, 5 } };
int[] arr1Common = CommonItems(arr1);
/* write method to print arr1Common */
Console.WriteLine("1st task:");
for (int i = 0; i < arr1Common.Length; i++)
{
  Console.Write("{0} ", arr1Common[i]);
}
Console.WriteLine();

/* 
Challenge 2. Inverse the elements of a jagged array.
For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
Expected result: int[][] arr = {new int[]{2, 1}, new int[]{3, 2, 1}}
*/
void InverseJagged(int[][] jaggedArray)
{
  for (int i = 0; i < jaggedArray.Length; i++)
  {
    Array.Reverse(jaggedArray[i]);
  }
}
int[][] arr2 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
InverseJagged(arr2);
/* write method to print arr2 */
Console.WriteLine("2nd task:");
for (int i = 0; i < arr2.Length; i++)
{
  for (int j = 0; j < arr2[i].Length; j++)
  {
    Console.Write("{0} ", arr2[i][j]);
  }
  Console.WriteLine();
}

// /* 
// Challenge 3.Find the difference between 2 consecutive elements of an array.
// For example, int[][] arr = {new int[] {1,2}, new int[]{1,2,3}} 
// Expected result: int[][] arr = {new int[] {-1}, new int[]{-1, -1}}
//  */
void CalculateDiff(int[][] jaggedArray)
{
  for (int i = 0; i < jaggedArray.Length; i++)
  {
    for (int j = 0; j < jaggedArray[i].Length - 1; j++)
    {
      jaggedArray[i][j] = jaggedArray[i][j] - jaggedArray[i][j + 1];
    }
    jaggedArray[i] = jaggedArray[i].Take(jaggedArray[i].Length - 1).ToArray();
  }
}
int[][] arr3 = { new int[] { 1, 2 }, new int[] { 1, 2, 3 } };
CalculateDiff(arr3);
// /* write method to print arr3 */
Console.WriteLine("3rd task:");
for (int i = 0; i < arr3.Length; i++)
{
  for (int j = 0; j < arr3[i].Length; j++)
  {
    Console.Write("{0} ", arr3[i][j]);
  }
  Console.WriteLine();
}

// /* 
// Challenge 4. Inverse column/row of a rectangular array.
// For example, given: int[,] arr = {{1,2,3}, {4,5,6}}
// Expected result: {{1,4},{2,5},{3,6}}
//  */
int[,] InverseRec(int[,] recArray)
{
  int rows = recArray.GetLength(0);
  int columns = recArray.GetLength(1);
  int[,] inversedArr = new int[columns, rows];

  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    {
      inversedArr[j, i] = recArray[i, j];
    }
  }
  return inversedArr;
}
int[,] arr4 = { { 1, 2, 3 }, { 4, 5, 6 } };
int[,] arr4Inverse = InverseRec(arr4);
// /* write method to print arr4Inverse */
Console.WriteLine("4nd task:");
int rows = arr4Inverse.GetLength(0);
int columns = arr4Inverse.GetLength(1);

for (int i = 0; i < rows; i++)
{
  for (int j = 0; j < columns; j++)
  {
    Console.Write("{0} ", arr4Inverse[i, j]);
  }
  Console.WriteLine();
}

// /* 
// Challenge 5. Write a function that accepts a variable number of params of any of these types: 
// string, number. 
// - For strings, join them in a sentence. 
// - For numbers then sum them up. 
// - Finally print everything out. 
// Example: Demo("hello", 1, 2, "world") 
// Expected result: hello world; 3 */
void Demo(params object[] values)
{
  string sentence = "";
  int sum = 0;

  foreach (object value in values)
  {
    if (value is string)
    {
      sentence += value + " ";
    }
    else if (value is int)
    {
      sum += (int)value;
    }
  }

  Console.WriteLine($"{sentence.TrimEnd()}; {sum}");
}
Console.WriteLine("5th Task:");
Demo("hello", 1, 2, "world"); //should print out "hello world; 3"
Demo("My", 2, 3, "daughter", true, "is");//should print put "My daughter is; 5"


// /* Challenge 6. Write a function to swap 2 objects but only if they are of the same type 
// and if they’re string, lengths have to be more than 5. 
// If they’re numbers, they have to be more than 18. */
void SwapTwo(ref object obj1, ref object obj2)
{
  if (obj1.GetType() == obj2.GetType())
  {
    if (obj1 is string && obj2 is string && ((string)obj1).Length > 5 && ((string)obj2).Length > 5)
    {
      object temp = obj1;
      obj1 = obj2;
      obj2 = temp;
    }
    else if (obj1 is int && obj2 is int && ((int)obj1 > 18) && ((int)obj2 > 18))
    {
      object temp = obj1;
      obj1 = obj2;
      obj2 = temp;
    }
  }
}
object testString1 = "Initially first";
object testString2 = "Initially second";
object testNum1 = 19;
object testNum2 = 20;
SwapTwo(ref testString1, ref testString2);
SwapTwo(ref testNum1, ref testNum2);
Console.WriteLine(testString1 + ", " + testString2);
Console.WriteLine(testNum1 + " " + testNum2);

// /* Challenge 7. Write a function that does the guessing game. 
// The function will think of a random integer number (lets say within 100) 
// and ask the user to input a guess. 
// It’ll repeat the asking until the user puts the correct answer. */
void GuessingGame()
{
  Random random = new Random();
  int targetNumber = random.Next(1, 101);
  int guess = 0;

  while (guess != targetNumber)
  {
    Console.Write("Enter your guess: ");
    string input = Console.ReadLine();

    if (int.TryParse(input, out guess))
    {
      if (guess == targetNumber)
      {
        Console.WriteLine("You won!");
      }
      else if (guess < targetNumber)
      {
        Console.WriteLine("Too low. Try again.");
      }
      else
      {
        Console.WriteLine("Too high. Try again.");
      }
    }
    else
    {
      Console.WriteLine("Invalid input.");
    }
  }
}
GuessingGame();

/* Challenge 8. Provide class Product, OrderItem, Cart, which make a feature of a store
Complete the required features in OrderItem and Cart, so that the test codes are error-free */

var product1 = new Product(1, 30);
var product2 = new Product(2, 50);
var product3 = new Product(3, 40);
var product4 = new Product(4, 35);
var product5 = new Product(5, 75);

var orderItem1 = new OrderItem(product1, 2);
var orderItem2 = new OrderItem(product2, 1);
var orderItem3 = new OrderItem(product3, 3);
var orderItem4 = new OrderItem(product4, 2);
var orderItem5 = new OrderItem(product5, 5);
var orderItem6 = new OrderItem(product2, 2);

var cart = new Cart();
cart.AddToCart(orderItem1, orderItem2, orderItem3, orderItem4, orderItem5, orderItem6);

//get 1st item in cart
var firstItem = cart[0];
Console.WriteLine(firstItem);

//Get cart info
cart.GetCartInfo(out int totalPrice, out int totalQuantity);
Console.WriteLine("Total Quantity: {0}, Total Price: {1}", totalQuantity, totalPrice);

//get sub array from a range
var subCart = cart[1, 3];
foreach (var item in subCart)
{
  Console.WriteLine(item);
}

class Product
{
  public int Id { get; set; }
  public int Price { get; set; }

  public Product(int id, int price)
  {
    this.Id = id;
    this.Price = price;
  }
}

class OrderItem : Product
{
  public int Quantity { get; set; }

  public OrderItem(Product product, int quantity) : base(product.Id, product.Price)
  {
    this.Quantity = quantity;
  }

  public override string ToString()
  {
    return $"Id: {Id}, Price: {Price}, Quantity: {Quantity}";
  }
}

class Cart
{
  private List<OrderItem> _cart { get; set; } = new List<OrderItem>();

  public OrderItem this[int index]
  {
    get { return _cart[index]; }
  }

  public List<OrderItem> this[int start, int end]
  {
    get { return _cart.GetRange(start, end - start + 1); }
  }

  public void AddToCart(params OrderItem[] items)
  {
    /* this method should check if each item exists --> increase value / or else, add item to cart */
    foreach (var item in items)
    {
      bool itemExists = false;
      foreach (var cartItem in _cart)
      {
        if (cartItem.Id == item.Id)
        {
          cartItem.Quantity += item.Quantity;
          itemExists = true;
          break;
        }
      }
      if (!itemExists)
      {
        _cart.Add(item);
      }
    }
  }
  public int Index(OrderItem item)
  {
    return _cart.IndexOf(item);
  }

  public void GetCartInfo(out int totalPrice, out int totalQuantity)
  {
    totalPrice = 0;
    totalQuantity = 0;
    foreach (var item in _cart)
    {
      totalPrice += item.Price * item.Quantity;
      totalQuantity += item.Quantity;
    }
  }

  public override string ToString()
  {
    string cartInfo = "";
    foreach (var item in _cart)
    {
      cartInfo += item.ToString() + "\n";
    }
    return cartInfo;
  }

}