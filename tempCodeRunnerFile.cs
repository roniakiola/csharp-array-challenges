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
for (int i = 0; i < arr1Common.Length; i++)
{
  Console.WriteLine(arr1Common[i]);
}