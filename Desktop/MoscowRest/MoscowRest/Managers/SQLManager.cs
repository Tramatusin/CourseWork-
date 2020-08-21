using System;
using System.Collections.Generic;
using MoscowRest.Models;
using SQLite;

namespace MoscowRest.Managers
{
    public class SQLManager
    {
        public EventHandler<Place> Added;
        public EventHandler<Place> Deleted;
        SQLiteConnection connection;
        public SQLManager(string path)
        {
            connection = new SQLiteConnection(path);
            connection.CreateTable<Place>();
        }
        /// <summary>
        /// Добавить новое место в таблицу.
        /// </summary>
        /// <param name="item">Новый элемент.</param>
        public void Add(Place item)
        {
            connection.Insert(item);
            Added?.Invoke(this, item);
        }
        /// <summary>
        /// Удалить переданное место.
        /// </summary>
        /// <param name="item">Элемент для удаления.</param>
        public void DeleteItem(Place item)
        {
            connection.Delete(item);
            Deleted?.Invoke(this, item);
        }
        /// <summary>
        /// Проверяет содержится ли место.
        /// </summary>
        public bool Contains(Place item)
        {
            return connection.Find<Place>(item.Id) != null;
        }
        /// <summary>
        /// Дает все места из таблицы.
        /// </summary>
        /// <returns>Список мест.</returns>
        public List<Place> GetPlaces()
        {
            try
            {
                return connection.Table<Place>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Place>();
        }
    }
}