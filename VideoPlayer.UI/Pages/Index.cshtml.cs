using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VideoPlayer.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<IndexModel> _logger;
        public string Video { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
            try
            {
                Video = "/video/SampleVideo.mp4";
            }
            catch
            {

            }
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public IFormFile VideoFile { get; set; }
        public async Task OnPostAsync()
        {
            var file = Path.Combine(_environment.WebRootPath, "video", "SampleVideo.mp4");
            using var fileStream = new FileStream(file, FileMode.OpenOrCreate);
            await VideoFile.CopyToAsync(fileStream);
            Video = "/video/SampleVideo.mp4";
        }
    }
}