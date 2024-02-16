using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API___AZURE_TABLES.Models;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;

namespace API___AZURE_TABLES.Contacts
{   
    [ApiController]
    [Route("[Controller]")]
    public class ContactController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly string _tableName;

        public ContactController(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("SaConnectionString");
            _tableName = configuration.GetValue<string>("AzureTableName");
        }

        private TableClient GetTableClient()
        {
            var clientService = new TableServiceClient(_connectionString);
            var clientTable = clientService.GetTableClient(_tableName);

            clientTable.CreateIfNotExists();
            return clientTable;
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            var tableClient = GetTableClient();

            contact.RowKey = Guid.NewGuid().ToString();
            contact.PartitionKey = contact.RowKey;

            tableClient.UpsertEntity(contact);

            return Ok(contact);
        }        

        [HttpPut("{id}")]
        public IActionResult Update(string id, Contact contact)
        {
            var tableClient = GetTableClient();
            var contactTable = tableClient.GetEntity<Contact>(id, id).Value;

            contactTable.Name = contact.Name;
            contactTable.Phone = contact.Phone;
            contactTable.Email = contact.Email;

            tableClient.UpsertEntity(contact);
            return Ok();
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var tableClient = GetTableClient();
            var contacts = tableClient.Query<Contact>().ToList();
            return Ok(contacts);
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var tableClient = GetTableClient();
            var contacts = tableClient.Query<Contact>(contact => contact.Name == name).ToList();
            return Ok(contacts);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var tableClient = GetTableClient();
            tableClient.DeleteEntity(id, id);
            return NoContent();
        }
    }

}