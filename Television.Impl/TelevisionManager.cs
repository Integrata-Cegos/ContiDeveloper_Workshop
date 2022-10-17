using Television.Api;

namespace Television.Impl;

    public class TelevisionManager : ITelevisionOperations
    {
        private Dictionary<int, Television.Api.Television> televisions = new Dictionary<int, Television.Api.Television>();

        private static int counter = 0 ;

        public int Create(string name, double price)
        {
            Television.Api.Television newTelevision = new Television.Api.Television();
            newTelevision.Id = counter++;
            newTelevision.name = name;
            newTelevision.price = price;
            televisions.Add((int)newTelevision.Id, newTelevision);
            return counter;
        }

        public Television.Api.Television FindById(int id)
        {
            return televisions[id];
        }

        public List<Television.Api.Television> FindAll()
        {
            return televisions.Select(x => x.Value).ToList();
        }

        public void Update(Television.Api.Television entity)
        {
            televisions[(int)entity.Id] = entity;
        }

        public void DeleteById(int id)
        {
            televisions.Remove(id);
        }
    }