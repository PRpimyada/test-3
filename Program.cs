using System;
class MainClass {
      static void Main(string[] args) {
    Console.Write("Enter the number of stalls open for rent (n): ");
    int n = int.Parse(Console.ReadLine());
    bool[] stalls = new bool[n];
    for (int i = 0; i < n; i++) {
      stalls[i] = false;
    }
    while (true) {
      Console.Write("Enter stall number(s) to reserve (separate with a space): ");
      string[] input = Console.ReadLine().Split();
      int stall1 = int.Parse(input[0]);
      int stall2 = int.Parse(input[1]);
      if (stall1 <= 0 || stall2 <= 0) {
        if (Math.Max(stall1, stall2) == 0) {
          break;
        } else {
          int stall = Math.Max(stall1, stall2) - 1;
          if (stalls[stall]) {
            Console.WriteLine("The stall is reserved.");
          } else {
            stalls[stall] = true;
            Console.WriteLine("The entrance can't be reserved.");
          }
        }
      } else if (stall1 == stall2) {
        int stall = stall1 - 1;
        if (stalls[stall]) {
          Console.WriteLine("The stall is reserved.");
        } else {
          stalls[stall] = true;
          Console.WriteLine("Reservation successful.");
        }
      } else {
        if (Math.Abs(stall1 - stall2) != 1) {
          Console.WriteLine("The entrance can't be reserved.");
        } else {
          int start = Math.Min(stall1, stall2) - 1;
          int end = Math.Max(stall1, stall2) - 1;
          bool conflict = false;
          for (int i = start; i <= end; i++) {
            if (stalls[i]) {
              Console.WriteLine("The stall is reserved.");
              conflict = true;
              break;
            }
          }
          if (!conflict) {
            for (int i = start; i <= end; i++) {
              stalls[i] = true;
            }
            Console.WriteLine("Reservation successful.");
          }
        }
      }
      Console.WriteLine("Status: " + string.Join(" ", Array.ConvertAll(stalls, x => x ? "X" : "_")));
      if (Array.IndexOf(stalls, false) == -1) {
        Console.WriteLine("All stalls are reserved.");
        break;
      }
    }
  }
}