using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal ıCarDal)
        {
            _carDal = ıCarDal;
        }
        public List<Car> GetAll()
        {
            //job codes

            return _carDal.GetAll();
        }
    }
}
