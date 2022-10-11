using Aspose.Words;
using Courses_Center.Models;
using Courses_Center.Repositories.General;
using Courses_Center.Repositories.Generic_repositry.IGenericRepositry;
using Courses_Center.Repositories.SourcesRepository.ISourcesRepository;
using Courses_Center.Services.Generic_Service;
using Courses_Center.ViewModels;
using Courses_Center.ViewModels.Extentsion;
using SautinSoft.Document;

namespace Courses_Center.Services.SourcesService
{
    public class SourceSevice : ISource
    {
        

        private readonly ISourceRepository _sourceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SourceSevice(ISourceRepository sourceRepository, IWebHostEnvironment webHostEnvironment)
        {
            _sourceRepository = sourceRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public List<Source> getallSource(SourceDisplayDTO sourceDisplayDTO)
        {
            return _sourceRepository.GetAllWithCondation(s => s.CrsID == sourceDisplayDTO.CrsID && s.ProfID == sourceDisplayDTO.ProfID && s.Course.DeptID == sourceDisplayDTO.DeptID && s.Course.Department.College.Id == sourceDisplayDTO.ColID && s.Course.Department.College.UniID == sourceDisplayDTO.UniID && s.ISDeleted == false && s.Type == sourceDisplayDTO.SourceType);

        }
        public List<Source> getallSource()
        {
            return _sourceRepository.GetAllWithCondation(s => s.ISDeleted == false);
        }
        public Source AddSource(SourceDto sourceDto, IFormFile file)
        {
            Source source = sourceDto.DTOToSource();

            List<string> urls = new List<string>();
            urls = FileSave(file);
             source.Url = urls[0];
            source.image = urls[1];
            source.CountOfBuy = 0;
            _sourceRepository.Add(source);
            _sourceRepository.SaveChanges();
            return source;


        }
        public Source GetOneSource(int id)
        {
            return _sourceRepository.Get(id);
        }
        public void removeSource(int id)
        {
            Source s = GetOneSource(id);

            s.ISDeleted = true;
            _sourceRepository.Update(s);
            _sourceRepository.SaveChanges();
        }
        public Source Update(SourceDto sourceDto, IFormFile sources)
        {
          
            Source source = GetOneSource(sourceDto.Id);
            source.ProfID = sourceDto.ProfID;
            source.CrsID = sourceDto.CrsID;
            source.Type = sourceDto.Type;
            source.Title = sourceDto.Title;
            source.Price = sourceDto.Price;
            source.Description = sourceDto.Description;
            source.Notes = sourceDto.Notes;
           List<string> urls = new List<string>();
            urls = FileSave(sources);
            source.Url = urls[0];
            source.image = urls[1];
            _sourceRepository.Update(source);
            _sourceRepository.SaveChanges();
            return source;
        }
        public  List<string> FileSave(IFormFile sources)
        {
            Guid obj = Guid.NewGuid();
            Guid obj2 = Guid.NewGuid();
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            string filePath = "";
            string filePath2 = "";
            path = Path.Combine(webRootPath, "resources");
            var path2 = Path.Combine(webRootPath, "imagesPdf");
            List<string> urls = new List<string>();
            if (sources != null)
            {
                string name = obj.ToString() + sources.FileName;

                filePath = Path.Combine(path, name);
                filePath2 = Path.Combine(path2, obj2.ToString() +sources.Name+".png");

                //  await studentDto.Certification_Photo.CopyToAsync(filePath);
                 using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    sources.CopyToAsync(fileStream);

                }


                DocumentCore dc = DocumentCore.Load(filePath);
                DocumentPaginator dp = dc.GetPaginator(new PaginatorOptions());
                dp.Pages[0].Rasterize(800, SautinSoft.Document.Color.White).Save(filePath2);

               
                urls.Add(obj.ToString() + sources.FileName);
                urls.Add(obj2.ToString() + sources.Name+".png");
            }
            //var doc = new Document(sources.FileName);
            return urls;
        }

        public IEnumerable<Source> GetAll()
        {
            return _sourceRepository.GetAll();
        }
        public List<Source> getallSource(int CrsID)
        {
            return _sourceRepository.GetAllWithCondation(s => s.CrsID == CrsID);

        }
        public IEnumerable<dynamic> getallSourceForBuyer(string username)
        {
            return _sourceRepository.getallSourceForBuyer(username);
        }
    }
}
