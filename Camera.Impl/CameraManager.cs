using Camera.Api;

namespace Camera.Impl;

    public class CameraManager : ICameraOperations
    {
        private Dictionary<int, Camera.Api.Camera> cameras = new Dictionary<int, Camera.Api.Camera>();

        private static int counter = 0 ;

        public int Create(string name, double price)
        {
            Camera.Api.Camera newCamera = new Camera.Api.Camera();
            newCamera.Id = counter++;
            newCamera.name = name;
            newCamera.price = price;
            cameras.Add((int)newCamera.Id, newCamera);
            return counter;
        }

        public Camera.Api.Camera FindById(int id)
        {
            return cameras[id];
        }

        public List<Camera.Api.Camera> FindAll()
        {
            return cameras.Select(x => x.Value).ToList();
        }

        public void Update(Camera.Api.Camera entity)
        {
            cameras[(int)entity.Id] = entity;
        }

        public void DeleteById(int id)
        {
            cameras.Remove(id);
        }
    }