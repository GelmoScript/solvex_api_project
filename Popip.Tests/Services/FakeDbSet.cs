using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Popip.Model.Entities;

namespace Popip.Tests.Services
{
    public class FakeDbSet<T> : DbSet<T> where T : class
    {
        readonly ObservableCollection<T> _data;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
        }

        public virtual T Find(params object[] keyValues) => throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return _data; }
        }


    }

    public class FakeItemSet : FakeDbSet<Item>
    {
        public override Item Find(params object[] keyValues)
        {
            return this.SingleOrDefault(i => i.Id == (int)keyValues.Single());
        }
    }
}
