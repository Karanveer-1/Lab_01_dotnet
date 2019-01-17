using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lab1.Controllers
{
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string[] files = Directory.GetFiles(webRootPath + "\\TextFiles");
            return View(files);
        }

        public IActionResult Content(String id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            string fileName = id;
            string path = webRootPath + "\\TextFiles\\" + fileName;
            string content = System.IO.File.ReadAllText(path);
            ViewData["content"] = content;
            return View();
        }
    }
}
