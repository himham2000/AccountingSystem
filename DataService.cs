using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem {
    public static class DataService {
        public static List<Account> GetAllAccounts() {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    return connection.Query<Account>("SELECT * FROM Accounts ORDER BY Id DESC").ToList();
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في جلب الحسابات: {ex.Message}");
                return new List<Account>();
            }
        }

        public static List<Account> SearchAccounts(string searchTerm) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "SELECT * FROM Accounts WHERE Name LIKE @Search OR Type LIKE @Search ORDER BY Id DESC";
                    var parameters = new { Search = $"%{searchTerm}%" };
                    return connection.Query<Account>(query, parameters).ToList();
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في البحث عن الحسابات: {ex.Message}");
                return new List<Account>();
            }
        }

        public static bool AddAccount(Account account) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "INSERT INTO Accounts (Name, Type, Balance) VALUES (@Name, @Type, @Balance)";
                    var result = connection.Execute(query, account);
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في إضافة الحساب: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateAccount(Account account) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "UPDATE Accounts SET Name = @Name, Type = @Type, Balance = @Balance WHERE Id = @Id";
                    var result = connection.Execute(query, account);
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في تحديث الحساب: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteAccount(int id) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "DELETE FROM Accounts WHERE Id = @Id";
                    var result = connection.Execute(query, new { Id = id });
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في حذف الحساب: {ex.Message}");
                return false;
            }
        }

        public static List<Item> GetAllItems() {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    return connection.Query<Item>("SELECT * FROM Items ORDER BY Id DESC").ToList();
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في جلب الأصناف: {ex.Message}");
                return new List<Item>();
            }
        }

        public static List<Item> SearchItems(string searchTerm) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "SELECT * FROM Items WHERE Name LIKE @Search OR Category LIKE @Search ORDER BY Id DESC";
                    var parameters = new { Search = $"%{searchTerm}%" };
                    return connection.Query<Item>(query, parameters).ToList();
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في البحث عن الأصناف: {ex.Message}");
                return new List<Item>();
            }
        }

        public static bool AddItem(Item item) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "INSERT INTO Items (Name, Category, Price, Stock) VALUES (@Name, @Category, @Price, @Stock)";
                    var result = connection.Execute(query, item);
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في إضافة الصنف: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateItem(Item item) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "UPDATE Items SET Name = @Name, Category = @Category, Price = @Price, Stock = @Stock WHERE Id = @Id";
                    var result = connection.Execute(query, item);
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في تحديث الصنف: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteItem(int id) {
            try {
                using (var connection = new SqliteConnection(Database.GetConnectionString())) {
                    connection.Open();
                    string query = "DELETE FROM Items WHERE Id = @Id";
                    var result = connection.Execute(query, new { Id = id });
                    return result > 0;
                }
            } catch (Exception ex) {
                Console.WriteLine($"خطأ في حذف الصنف: {ex.Message}");
                return false;
            }
        }
    }
}