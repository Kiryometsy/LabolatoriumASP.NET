namespace Projekt.Models
{
    public interface IPhotoService
    {
        int Add(Photo book);
        void Delete(int id);
        void Update(Photo book);
        List<Photo> FindAll();
        Photo? FindById(int id);
    }
}
