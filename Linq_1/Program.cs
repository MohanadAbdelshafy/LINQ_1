using static LINQ.DataSources.Source;
namespace LINQ_1

{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            var seafood = ProductList.Where(p => p.Category == "Seafood");

            foreach (var p in seafood)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");
            #endregion

            #region Q2
            var productNames = ProductList.Select(p => p.ProductName).ToList();

            foreach (var name in productNames)
                Console.WriteLine(name);
            #endregion

            #region Q3

            var byPrice = ProductList.OrderBy(p => p.UnitPrice);

            foreach (var p in byPrice)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");
            #endregion

            #region Q4
            var inPriceRange = ProductList.Where(p => p.UnitPrice >= 10m && p.UnitPrice <= 30m);

            foreach (var p in inPriceRange)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice:F2}");
            #endregion

            #region Q5
            var condimentsInStock = ProductList.Where(p => p.Category == "Condiments" && p.UnitsInStock > 0);

            foreach (var p in condimentsInStock)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion

            #region Q6
            var stockReport = ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var item in stockReport)
                Console.WriteLine($"{item.Name} - {item.Price:F2} - {item.StockStatus}");
            #endregion

            #region Q7
            var numberedNames = ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");

            foreach (var line in numberedNames)
                Console.WriteLine(line);
            #endregion

            #region Q8
            var byCategoryAndPrice = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);

            foreach (var p in byCategoryAndPrice)
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice:F2}");
            #endregion

            #region Q9
            var beverages = ProductList.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);

            foreach (var p in beverages)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            #endregion

            #region Q10
            var ordersFrom1997 =
                                    from customer in CustomerList
                                    from order in customer.Orders
                                    where order.OrderDate.Year >= 1997
                                    select new
                                    {
                                        customer.CustomerID,
                                        order.OrderDate
                                    };

            foreach (var item in ordersFrom1997)
                Console.WriteLine($"{item.CustomerID} - {item.OrderDate:yyyy-MM-dd}");
            #endregion

            #region Q11
            var productPositions = ProductList.Select((p, index) => new
            {
                Position = index + 1,
                p.ProductName
            });

            foreach (var item in productPositions)
                Console.WriteLine($"{item.Position}. {item.ProductName}");
            #endregion

            #region Q12
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
                Console.WriteLine(word);
            #endregion

            #region Q13
            string[] digits =
                              {
                               "zero", "one", "two", "three", "four",
                               "five", "six", "seven", "eight", "nine"
                              };

            var reversedDigits = digits
                .Where(word => word[1] == 'i')
                .Reverse()
                .ToList();

            foreach (var digit in reversedDigits)
                Console.WriteLine(digit); 
            #endregion
        }
    }
}

