using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FilesController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public FilesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("BlobConnectionString");
            _containerName = configuration.GetValue<string>("BlobContainerName");
        
        }

        [HttpPost("Upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(file.FileName);

            using var data = file.OpenReadStream();
            blob.Upload(data, new BlobUploadOptions{
                HttpHeaders = new BlobHttpHeaders {ContentType = file.ContentType}
            });

            return Ok(blob.Uri.ToString());
        }

        [HttpPost("Download/{name}")]
        public IActionResult DownloadFile(string name)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(name);
            
            if(!blob.Exists()) return BadRequest("File Not Found!");

            var result = blob.DownloadContent();
            return File(result.Value.Content.ToArray(), result.Value.Details.ContentType, blob.Name);
        }

        [HttpPost("Delete/{name}")]
        public IActionResult DeleteFile(string name)
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            BlobClient blob = container.GetBlobClient(name);

            blob.DeleteIfExists();
            return NoContent();
        }

        [HttpGet("ListAll")]
        public IActionResult ListAll()
        {
            BlobContainerClient container = new(_connectionString, _containerName);
            List<BlobDto> blobsDto = [];

            foreach(var blob in container.GetBlobs())
            {
                blobsDto.Add(new BlobDto
                {
                    Name = blob.Name,
                    Type = blob.Properties.ContentType,
                    Uri = container.Uri.AbsoluteUri + "/" + blob.Name

                });

            }
            return Ok(blobsDto);
        }
        
    }
}