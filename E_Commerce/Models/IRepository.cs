using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(object id);
        List<T> GetPaging(int page, int row);
        List<T> Search(int page, int row, string keyWord);
        int Create(T newItem);
        int Update(T updateItem);
        int Delete(object id);
    }
}