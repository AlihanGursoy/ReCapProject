using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
            new Car{Id=1,BrandId=1,ModelYear=2015,ColorId=2,DailyPrice=420,Description="Müessesemiz tarafından bakımları yapılmıştır. İyi seyirler."},
            new Car{Id=2,BrandId=2,ModelYear=2012,ColorId=1,DailyPrice=350,Description="Müessesemiz tarafından bakımları yapılmıştır. Tekrardan bekleriz."},
            new Car{Id=3,BrandId=1,ModelYear=2010,ColorId=3,DailyPrice=320,Description="Müessesemiz tarafından bakımları yapılmıştır. Önemli olan sağlık."},
            new Car{Id=4,BrandId=3,ModelYear=2019,ColorId=2,DailyPrice=560,Description="Müessesemiz tarafından bakımları yapılmıştır. Dikkatli kullanınız."},
            new Car{Id=5,BrandId=2,ModelYear=2016,ColorId=1,DailyPrice=450,Description="Müessesemiz tarafından bakımları yapılmıştır. İyi seyirler"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll(Car car)
        {
            return _cars;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.Id == car.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
