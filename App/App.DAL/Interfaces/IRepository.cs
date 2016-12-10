using System;
using System.Collections.Generic;

namespace App.DAL.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        void Create(T item);

        void Update(T item);
        
    }
}