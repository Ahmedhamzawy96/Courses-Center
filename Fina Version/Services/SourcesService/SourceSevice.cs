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
        private readonly IHttpContextAccessor _IHttpContext;

        public SourceSevice(ISourceRepository sourceRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor HttpContext)
        {
            _sourceRepository = sourceRepository;
            _webHostEnvironment = webHostEnvironment;
            _IHttpContext = HttpContext;
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

            if(sources != null)
            {
                List<string> urls = new List<string>();
                urls = FileSave(sources);
                source.Url = urls[0];
                source.image = urls[1];

            }
            else
            {
                source.Url = source.Url;
                source.image = source.image;
            }
            _sourceRepository.Update(source);
            _sourceRepository.SaveChanges();
            return source;
        }
        public  List<string> FileSave(IFormFile sources)
        {
            Guid obj = Guid.NewGuid();
            Guid obj2 = Guid.NewGuid();
            string resourcesWebRoot = _webHostEnvironment.WebRootPath;
            string imagesPdfWebRoot = _webHostEnvironment.WebRootPath;
            string pathPdf = "";
            string filePathPdf = "";
            string filePathImg = "";
            pathPdf = Path.Combine(resourcesWebRoot, "resources");
            var pathImg = Path.Combine(imagesPdfWebRoot, "imagesPdf");
            List<string> urls = new List<string>();
            if (sources != null)
            {
                FileInfo pdf = new FileInfo(sources.FileName);

                filePathPdf = Path.Combine(pathPdf, obj.ToString() + pdf.Extension);
                filePathImg = Path.Combine(pathImg, obj2.ToString()+".png");

                //await studentDto.Certification_Photo.CopyToAsync(filePath);
                 using (FileStream fileStream = new FileStream(filePathPdf, FileMode.Create))
                {
                    sources.CopyTo(fileStream);

                }
                //var BaseUrl = _IHttpContext.HttpContext.Request.Scheme + "://" +
                //_IHttpContext.HttpContext.Request.Host + _IHttpContext.HttpContext.Request.PathBase;
                //var imagePath = Path.Combine(BaseUrl, "wwwroot\\resources");
                var filePathPdfImg = Path.Combine(pathPdf, obj.ToString() + pdf.Extension);

                DocumentCore dc = DocumentCore.Load(filePathPdfImg);
                DocumentPaginator dp = dc.GetPaginator(new PaginatorOptions());
                dp.Pages[0].Rasterize(800, SautinSoft.Document.Color.White).Save(filePathImg);

               
                urls.Add(obj.ToString() + pdf.Extension);
                urls.Add(obj2.ToString()+".png");
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
